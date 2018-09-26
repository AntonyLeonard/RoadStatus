using System;
using log4net;
using RoadStatus.Engine;

namespace RoadStatus
{
    public class Program
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(Program));

        /// <summary>
        /// This Main method passes parameter to an API call
        /// to get road status
        /// </summary>
        /// <param name="args"></param>
        /// <returns>integer as exitcode
        ///          -1: Default value, 0: Valid Road Status
        ///           1: Invalid Road Status, 2: Command Parameter cannot be parsed
        ///           4: Fatal Error like request with Unauthorised credential
        ///              or unable to establish server connection
        ///          </returns>
        public static int Main(string[] args)
        {
            var result = new Tuple<int, string>(-1, string.Empty);
            _log.InfoFormat("Application started successfully");

            if (args.Length == 0)
            {
                result = Tuple.Create(2, "Input is not valid");
            }
            else
            {
                result = ApiRequestProcessor.ProcessApiRequest(args[0]);
            }

            Console.WriteLine(result.Item2);
            _log.InfoFormat("Application returned code: {0}", result.Item1);

            return result.Item1;
        }

    }
}
