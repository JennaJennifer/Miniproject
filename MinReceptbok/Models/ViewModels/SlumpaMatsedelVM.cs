using Microsoft.AspNetCore.Mvc.Rendering;
using MinReceptbok.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MinReceptbok.Models.ViewModels
{
    public class SlumpaMatsedelVM
    {
        public int Id { get; set; }
        public string Namn { get; set; }
        public string ReceptBeskrivning { get; set; }
        public int? AntalPortioner { get; set; }
        public string AntalPortionerText { get; set; }
        public string ImageRef { get; set; }
        public Images[] ImageRefs { get; set; }


    }
}
