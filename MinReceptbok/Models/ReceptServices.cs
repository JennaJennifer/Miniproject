﻿using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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

        SelectListItem[] selectListItems = new SelectListItem[]
        {
            new SelectListItem { Value="0", Text="2 Portioner"},
            new SelectListItem { Value="1", Text="4 Portioner"},
            new SelectListItem { Value="2", Text="6 Portioner"}

        };

        public ReceptSkapaNyVM CreateViewModel()
        {
            ReceptSkapaNyVM viewModel = new ReceptSkapaNyVM
            {
                AntalPortioner = selectListItems
            };

            return viewModel;
        }

        public void ShowAntalPortioner()
        {

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

            Images images = new Images()
            {
                Rid = receptbank.Id,
                ImageRef = nyttReceptVM.ImageRef,
            };

            context.Images.Add(images);
            context.SaveChanges();
        }

        public ReceptIndexVM[] GetAllRecept()
        {
            var temp = context.Receptbank
                   .Include(e => e.Images)
                   .Select(r => new ReceptIndexVM()
                   {
                       Id = r.Id,
                       Namn = r.Namn,
                       AntalPortioner = r.AntalPortioner,
                       ReceptBeskrivning = r.Recept,
                       ImageRefs = r.Images.ToArray()
                   })
                   .ToArray();
            return temp;
        }

        public SlumpaReceptVM SlumpaAllRecept()
        {
            var temp = context.Receptbank
                   .Include(e => e.Images)
                   .Select(r => new SlumpaReceptVM()
                   {
                       Id = r.Id,
                       Namn = r.Namn,
                       AntalPortioner = r.AntalPortioner,
                       ReceptBeskrivning = r.Recept,
                       ImageRefs = r.Images.ToArray()
                   })
                   .ToArray();

            Random random = new Random();
            int randomRecept = random.Next(0, temp.Length);

            var slumpatRecept = temp[randomRecept];

            return slumpatRecept;
        }

        public ReceptUppdateraVM GetReceptForUppdatera(int id)
        {
            Receptbank receptbank = context.Receptbank
                .Include(r => r.Images)
                .SingleOrDefault(r => r.Id == id);

            var urls = receptbank.Images.ToArray();
            var url = urls[0].ImageRef;

            var tmp = new ReceptUppdateraVM()
            {
                Id = receptbank.Id,
                Namn = receptbank.Namn,
                ReceptBeskrivning = receptbank.Recept,
                ValdaAntalPortioner = receptbank.AntalPortioner,
                AntalPortioner = selectListItems,
                ImageRef = url
            };
            return tmp;
        }

        public void UppdateraRecept(ReceptUppdateraVM uppdateraRecept)
        {
            Receptbank receptbank = context.Receptbank.SingleOrDefault(r => r.Id == uppdateraRecept.Id);
           
            receptbank.Namn = uppdateraRecept.Namn;
            receptbank.Recept = uppdateraRecept.ReceptBeskrivning;
            receptbank.AntalPortioner = uppdateraRecept.ValdaAntalPortioner;
            context.SaveChanges();

            Images images = context.Images.SingleOrDefault(r => r.Rid == uppdateraRecept.Id);

            images.ImageRef = uppdateraRecept.ImageRef;
            context.SaveChanges();
        }

        public ReceptVisaVM GetReceptForVisa(int id)
        {
            Receptbank receptbank = context.Receptbank.SingleOrDefault(r => r.Id == id);
            var x = receptbank.AntalPortioner.GetValueOrDefault();
            var y = selectListItems[x].Text;

            return new ReceptVisaVM()
            {
                Id = receptbank.Id,
                Namn = receptbank.Namn,
                ReceptBeskrivning = receptbank.Recept,
                AntalPortioner = receptbank.AntalPortioner,
                AntalPortionerText = y

            };
        }

       
        public SlumpaMatsedelVM[] SlumpaMatsedel()
        {
            var temp = context.Receptbank
                   .Include(e => e.Images)
                   .Select(r => new SlumpaMatsedelVM()
                   {
                       Id = r.Id,
                       Namn = r.Namn,
                       AntalPortioner = r.AntalPortioner,
                       ReceptBeskrivning = r.Recept,
                       ImageRefs = r.Images.ToArray()
                   })
                   .ToArray();

            Random random = new Random();
            int randomRecept;
            SlumpaMatsedelVM[] randomMatsedel = new SlumpaMatsedelVM[5];

            for (int i = 0; i <= 4; i++)
            {
                randomRecept = random.Next(0, temp.Length);
                randomMatsedel[i] = temp[randomRecept];
            }

            return randomMatsedel;
        }
    }
}
