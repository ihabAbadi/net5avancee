﻿using Microsoft.AspNetCore.Http;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Interfaces
{
    public interface IUpload
    {
        Image Upload(IFormFile file);
    }
}
