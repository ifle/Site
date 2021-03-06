﻿using System.IO;
using GeoAPI.Geometries;
using IsraelHiking.Common;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace IsraelHiking.DataAccess.Tests
{
    [TestClass]
    public class WikimediaCommonGatewayTests
    {
        private WikimediaCommonGateway _gateway;

        [TestInitialize]
        public void TestInitialize()
        {
            var options = new NonPublicConfigurationData
            {
                WikiMediaUserName = "WikiMediaUserName",
                WikiMediaPassword = "WikiMediaPassword"
            };
            var optionsContainer = Substitute.For<IOptions<NonPublicConfigurationData>>();
            var logger = Substitute.For<ILogger>();
            optionsContainer.Value.Returns(options);
            _gateway = new WikimediaCommonGateway(optionsContainer, logger);
        }

        [TestMethod]
        public void GetImageUrl()
        {
            try
            {
                _gateway.Initialize().Wait();
            }
            catch
            {
                // login will fail but we still want to proceed...
            }

            var results = _gateway.GetImageUrl("File:Israel_Hiking_Map_עין_מחוללים.jpeg").Result;

            Assert.IsNotNull(results);
        }

        [TestMethod]
        [Ignore]
        public void UploadImage()
        {
            _gateway.Initialize().Wait();

            var restuls = _gateway.UploadImage("ספריית שביל ישראל", "description", "me", "file", new MemoryStream(),
                new Coordinate(0, 0)).Result;

            Assert.IsNotNull(restuls);
        }
    }
}
