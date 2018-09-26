using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoadStatus.Engine;
using System;
using System.Configuration;

namespace RoadStatus.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        /// <summary>
        /// Test for valid road input
        /// Should return road status and return code 0
        /// </summary>
        [TestMethod()]
        public void GetValidRoadStatusTest()
        {
            //Arrange 
            var road = "A2";

            //Act
            var result = ApiRequestProcessor.ProcessApiRequest(road);

            //Assert
            Assert.AreEqual(0, result.Item1);
            Assert.IsTrue(result.Item2.Contains($"The status of the {road} is as follows"));
            Assert.IsTrue(result.Item2.Contains("Road Status is"));
            Assert.IsTrue(result.Item2.Contains("Road Status Description is"));

            Console.WriteLine(result.Item2);
        }

        /// <summary>
        /// Test for invalid road input
        /// Output return code 1 and descriptive error message
        /// </summary>
        [TestMethod()]
        public void GetInvalidRoadStatusTest()
        {
            //Arrange 
            var road = "A455";

            //Act
            var result = ApiRequestProcessor.ProcessApiRequest(road);

            //Assert
            Assert.AreEqual(1, result.Item1);
            Assert.IsTrue(result.Item2.Contains($"{road} is not a valid road."));

            Console.WriteLine(result.Item2);
        }

        [TestMethod()]
        public void MainMethodTest()
        {
            //Arrange 
            var road = "A2";

            //Act
            var result = Program.Main(new string[]{ road });

            //Assert
            Assert.AreEqual(0, result);
        }

        /// <summary>
        /// Test of invalid API credential
        /// Output descriptive error message and return code 4
        /// </summary>
        [TestMethod()]
        public void GetUnauthorisedResponeTest()
        {
            //Arrange 
            var road = "A2";
            var appSettings = ConfigurationManager.AppSettings;
            appSettings["ApiId"] = "invalidApiId";  //Invalid ApiId
            
            //Act
            var result = ApiRequestProcessor.ProcessApiRequest(road);

            //Assert
            Assert.AreEqual(4, result.Item1);
            Assert.IsTrue(result.Item2.Contains("Error"));

            Console.WriteLine(result.Item2);
        }


        [TestMethod()]
        public void GetInvalidURLResponeTest()
        {
            //Arrange 
            var road = "A2";
            var appSettings = ConfigurationManager.AppSettings;
            appSettings["ApiURL"] = "invalidApiURL";  //Invalid ApiURL

            //Act
            var result = ApiRequestProcessor.ProcessApiRequest(road);

            //Assert
            Assert.AreEqual(4, result.Item1);
            Assert.IsTrue(result.Item2.Contains("Error"));

            Console.WriteLine(result.Item2);
        }


    }
}