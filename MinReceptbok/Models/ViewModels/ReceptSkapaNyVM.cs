﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MinReceptbok.Models.ViewModels
{
    public class ReceptSkapaNyVM
    {
        [Required(ErrorMessage ="Du måste ange ett namn!")]
        public string Namn { get; set; }

        [Display(Name = "Recept")]
        public string ReceptBeskrivning { get; set; }

        [Display(Name ="Antal portioner")]
        public SelectListItem[] AntalPortioner { get; set; }

        [Range (0,2)]
        public int ValdaAntalPortioner { get; set; }

        [Display(Name = "Bildlänk")]
        public string ImageRef { get; set; }

    }
}
