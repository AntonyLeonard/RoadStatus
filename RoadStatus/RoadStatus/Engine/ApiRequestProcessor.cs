using System;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Text;
using log4net;
using Newtonsoft.Json;

namespace RoadStatus.Engine
{
    public static class ApiRequestProcessor
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(ApiRequestProcessor));

        static string ApiId = null;
        static string ApiKey = null;
        static string ApiUrl = null;

        /// <summary>
        /// Assigns values from config to local variables
        /// </summary>
        private static void Init()
        {
            var appSettings = ConfigurationManager.AppSettings;
            ApiId = appSettings["ApiId"];
            ApiKey = appSettings["ApiKey"];
            ApiUrl = appSettings["ApiUrl"];
        }

        /// <summary>
        /// Request API with given road name to get the road status
        /// </summary>
        /// <param name="road"></param>
        /// <returns>-1: Default Return Code,  
        ///           0: Valid Road Status
        ///           1: Invalid Road Status,  
        ///           4: Fatal Error like request with Unauthorised credential
        ///              or unable to establish server connection
        /// </returns>
        public static Tuple<int, string> ProcessApiRequest(string road)
        {
            Init();

            int rtnCode = -1;
            StringBuilder strBuilder = new StringBuilder();
            string result = string.Empty;

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    using (var response = client.GetAsync(
                        string.Format(ApiUrl, road, ApiId, ApiKey)).Result)
                    {
                        _log.Info($"API Response for {road} is {response.ToString()}");

                        var content = response.Content.ReadAsStringAsync();
                        result = content.Result;
                        _log.InfoFormat("API Response Content: {0}", result);

                        if (response.IsSuccessStatusCode)
                        {
                            dynamic jsonArray = JsonConvert.DeserializeObject(result);
                            var json = jsonArray[0];

                            strBuilder.AppendFormat("{0}\n\t{1}\n\t{2}", 
                                $"The status of the {json.displayName} is as follows",
                                $"Road Status is {json.statusSeverity}",
                                $"Road Status Description is {json.statusSeverityDescription}" );

                            rtnCode = 0;
                        }
                        else if (response.StatusCode == HttpStatusCode.NotFound)
                        {
                            strBuilder.Append($"{road} is not a valid road.");
                            rtnCode = 1;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                rtnCode = 4;

                strBuilder.AppendFormat(@"Error: {0}. {1}",
                    ex.GetBaseException().Message, 
                    string.IsNullOrEmpty(result) == true? string.Empty:
                    $"Server response { result }");

                _log.Error($@"Error occured in ProcessApiRequest due to 
                            {ex.GetBaseException().Message}. Server response {result}", ex);
            }

            return Tuple.Create(rtnCode, strBuilder.ToString());
        }

    }
}
