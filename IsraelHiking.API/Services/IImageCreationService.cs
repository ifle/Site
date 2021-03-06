﻿using System.Threading.Tasks;
using IsraelHiking.Common;
using System;

namespace IsraelHiking.API.Services
{
    /// <summary>
    /// This service is responsible for creating images for data container
    /// </summary>
    public interface IImageCreationService
    {
        /// <summary>
        /// Creates an image from the data in <see cref="DataContainer"/>
        /// </summary>
        /// <param name="dataContainer">The data to create the iamge from</param>
        /// <param name="width">Desired image width</param>
        /// <param name="height">Desired image height</param>
        /// <returns>Bitmap image represented as bytes</returns>
        Task<byte[]> Create(DataContainer dataContainer, int width, int height);
    }
}