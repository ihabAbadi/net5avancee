using Microsoft.AspNetCore.Http;
using Shop.Interfaces;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Services
{
    public class Upload : IUpload
    {
        Image IUpload.Upload(IFormFile file)
        {
            //Logique d'upload
            //Création d'image avec url
            return new Image() { Url = file.FileName };
        }
    }
}
