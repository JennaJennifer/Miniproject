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

        public ReceptController(ReceptServices receptServices)
        {
            this.receptServices = receptServices;
        }

        [Route("")]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SkapaNy()
        {
            var vm = receptServices.CreateViewModel();

            return View(vm);
        }

        [HttpPost]
        public IActionResult SkapaNy(ReceptSkapaNyVM nyttReceptVM)
        {
            if (!ModelState.IsValid)
                return View(nyttReceptVM);

            receptServices.AddRecept(nyttReceptVM);
            return RedirectToAction(nameof(Index));
        }

    }
}