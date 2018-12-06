using Microsoft.AspNetCore.Mvc.Rendering;
using MinReceptbok.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinReceptbok.Models
{
    public class ReceptServices
    {
        ReceptSkapaNyVM viewModel = new ReceptSkapaNyVM
        {
            AntalPortioner = new SelectListItem[]
            {
                new SelectListItem { Value="1", Text="2 Portioner"},
                new SelectListItem { Value="2", Text="4 Portioner", Selected=true},
                new SelectListItem { Value="3", Text="6 Portioner"}

            }
        };
    }
}
