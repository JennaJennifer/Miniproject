using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MinReceptbok.Controllers
{
    public class ReceptController : Controller
    {
        [Route("")]
        public IActionResult Index()
        {

            return View();
        }
    }
}