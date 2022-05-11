using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace GameyMcThingy.WebAPI.Controllers
{
    [Route("[controller]")]
    public class CatergoryController : Controller
    {
        private readonly ILogger<CatergoryController> _logger;

        public CatergoryController(ILogger<CatergoryController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}