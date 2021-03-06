﻿using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;
using ViMusic.Application.Shared.Helper;

namespace ViMusic.Application.Shared.ImageWriter
{
    public class ImageWriter
    {
        private const string _imageFolderRoot = "\\data\\images";
        public async Task<string> UploadImage(IFormFile file)
        {
            if (CheckIfImageFile(file))
            {
                return await WriteFile(file);
            }

            return "Invalid image file";
        }


        /// <summary>
        /// Get root image path
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static string GetImageRootPath(string filePath)
        {
            return Path.Combine(_imageFolderRoot, filePath);
        }

        /// <summary>
        /// Method to write file onto the disk
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public async Task<string> WriteFile(IFormFile file)
        {
            string fileName;
            try
            {
                var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
                fileName = Guid.NewGuid().ToString() + extension; 
                var rootPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
                var path = rootPath + Path.Combine(_imageFolderRoot, fileName);
       
                using (var bits = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(bits);
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }

            return fileName;
        }

        /// <summary>
        /// Method to check if file is image file
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        private bool CheckIfImageFile(IFormFile file)
        {
            byte[] fileBytes;
            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                fileBytes = ms.ToArray();
            }

            return WriterHelper.GetImageFormat(fileBytes) != WriterHelper.ImageFormat.Unknown;
        }
    }
}

