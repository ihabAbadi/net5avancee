using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace exampleMVCApplication.Services
{
    public class UploadService : IUpload
    {
        private IWebHostEnvironment _env;

        public UploadService(IWebHostEnvironment env)
        {
            _env = env;
        }
        public bool Upload(IFormFile[] files)
        {
            foreach(IFormFile file in files)
            {
                string path = Path.Combine(_env.WebRootPath, file.FileName);
                Stream stream = File.Create(path);
                file.CopyTo(stream);
                stream.Close();
            }
            return true;
        }
    }
}
