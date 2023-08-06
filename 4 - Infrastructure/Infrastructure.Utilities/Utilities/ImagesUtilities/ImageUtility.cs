using Microsoft.AspNetCore.Http;
using Service.Utilities.IUilities.IImageUtility;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Service.Utilities.Utilities.ImagesUtilities
{
    public class ImageUtility : IImageUtility
    {

        private ImageUtility()
        {

        }

        public async Task<List<string>> UploadImages(IFormFile image, string folderName= "ProductImages")
        {
            List<string> imagesNames = new List<string>();
            try
            {
                var directoryPathtemp = Path.Combine(Directory.GetCurrentDirectory());
                var directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "Files/",  folderName);

                if (!File.Exists(directoryPath))
                {
                    Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "Files/", folderName));
                }

                var extention = image.FileName.Split('.');
                if (extention.Length > 1)
                {
                    var imgTempName = Guid.NewGuid().ToString();
                    var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), "Files/",folderName + "\\" + imgTempName + "." + extention[1]);

                    using (var stream = File.Create(pathToSave))
                    {
                        await image.CopyToAsync(stream);
                        imagesNames.Add(imgTempName + "." + extention[1]);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return imagesNames;
        }

        internal static ImageUtility GetInstance()
        {
            return new ImageUtility();
        }
    }
}
