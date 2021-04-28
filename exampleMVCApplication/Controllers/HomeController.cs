using exampleMVCApplication.Models;
using exampleMVCApplication.Services;
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
        public HomeController(ILogger<HomeController> logger, ITransientInterface transientService, IScopedInterface scopedService, ISingeletonInterface singletonService)
        {
            _logger = logger;
            _transientService = transientService;
            _scopedService = scopedService;
            _singletonService = singletonService;
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
    }
}
