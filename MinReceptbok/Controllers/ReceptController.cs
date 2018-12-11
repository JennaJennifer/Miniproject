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
            return View(receptServices.GetAllRecept());
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
            return RedirectToAction(nameof(AllaRecept));
        }


        [HttpGet]
        public IActionResult AllaRecept()
        {
            return View(receptServices.GetAllRecept());
        }

        [HttpGet]
        public IActionResult Uppdatera(int id)
        {
            var viewModel = receptServices.GetReceptForUppdatera(id);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Uppdatera(ReceptUppdateraVM receptUppdateraVM)
        {
            if (!ModelState.IsValid)
                return View(receptUppdateraVM);

            receptServices.UppdateraRecept(receptUppdateraVM);

            return RedirectToAction(nameof(AllaRecept));
        }

        [HttpGet]
        public IActionResult VisaRecept(int id)
        {
            return View(receptServices.GetReceptForVisa(id));

        }

        [HttpPost]
        public IActionResult VisaRecept()
        {
            return RedirectToAction(nameof(Uppdatera));

        }
    }
}