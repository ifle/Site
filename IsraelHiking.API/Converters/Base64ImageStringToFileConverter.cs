﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using IsraelHiking.Common;

namespace IsraelHiking.API.Converters
{
    /// <inheritdoc />
    public class Base64ImageStringToFileConverter : IBase64ImageStringToFileConverter
    {
        /// <inheritdoc />
        public RemoteFileFetcherGatewayResponse ConvertToFile(string url, string fileNameWithoutExtension = "file")
        {
            var match = Regex.Match(url, @"data:image/(?<type>.+?);base64,(?<data>.+)");
            if (!match.Success)
            {
                return null;
            }

            return new RemoteFileFetcherGatewayResponse
            {
                FileName = fileNameWithoutExtension + "." + match.Groups["type"].Value,
                Content = Convert.FromBase64String(match.Groups["data"].Value)
            };
        }
    }
}
