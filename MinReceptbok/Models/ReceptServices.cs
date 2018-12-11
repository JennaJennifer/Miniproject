using Microsoft.AspNetCore.Mvc.Rendering;
using MinReceptbok.Models.Entities;
using MinReceptbok.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinReceptbok.Models
{
    public class ReceptServices
    {
        ReceptDBContext context;

        public ReceptServices(ReceptDBContext context)
        {
            this.context = context;
        }

        public ReceptSkapaNyVM CreateViewModel()
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

            return viewModel;
        }


        public void AddRecept(ReceptSkapaNyVM nyttReceptVM)
        {
            Receptbank receptbank = new Receptbank()
            {
                Namn = nyttReceptVM.Namn,
                Recept = nyttReceptVM.ReceptBeskrivning,
                AntalPortioner = nyttReceptVM.ValdaAntalPortioner
            };
            context.Receptbank.Add(receptbank);
            context.SaveChanges();
        }

        public ReceptIndexVM[] GetAllRecept()
        {
            return context.Receptbank
                   .Select(r => new ReceptIndexVM()
                   {
                       Id = r.Id,
                       Namn = r.Namn,
                       AntalPortioner = r.AntalPortioner,
                       ReceptBeskrivning = r.Recept

                   })
                   .ToArray();
        }
    }
}
