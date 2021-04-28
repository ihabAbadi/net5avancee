using exampleMVCApplication.Models;
using exampleMVCApplication.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace exampleMVCApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        ITransientInterface _transientService;
        IScopedInterface _scopedService;
        ISingeletonInterface _singletonService;
        IUpload _uploadService;
        public HomeController(ILogger<HomeController> logger, ITransientInterface transientService, IScopedInterface scopedService, ISingeletonInterface singletonService, IUpload uploadService)
        {
            _logger = logger;
            _transientService = transientService;
            _scopedService = scopedService;
            _singletonService = singletonService;
            _uploadService = uploadService;
        }

        public IActionResult Index()
        {
            ViewBag.TransientGuid = _transientService.GetGuid;
            ViewBag.ScopedGuid = _scopedService.GetGuid;
            ViewBag.SingletonGuid = _singletonService.GetGuid;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult SubmitFiles(IFormFile[] files)
        {
            if(_uploadService.Upload(files))
            {
                return Ok(new { message = "All Ok" });
            }
            else
            {
                return Ok(new { message = "Error upload" });
            }
        }
    }
}
