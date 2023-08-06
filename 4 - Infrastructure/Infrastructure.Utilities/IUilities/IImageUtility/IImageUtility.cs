using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Utilities.IUilities.IImageUtility
{
    public interface IImageUtility
    {
        public Task<List<string>> UploadImages(IFormFile image, string folderName= "ProductImages");
    }
}
