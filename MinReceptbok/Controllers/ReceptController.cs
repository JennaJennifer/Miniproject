using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MinReceptbok.Models;
using MinReceptbok.Models.ViewModels;

namespace MinReceptbok.Controllers
{
    public class ReceptController : Controller
    {
        ReceptServices receptServices;

        [Route("")]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SkapaNy()
        {
            
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult SkapaNy(ReceptSkapaNyVM nyttReceptVM)
        {
            return View();
        }

    }
}