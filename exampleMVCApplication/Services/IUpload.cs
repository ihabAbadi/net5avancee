using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace exampleMVCApplication.Services
{
    public interface IUpload
    {
        bool Upload(IFormFile[] files);
    }
}
