﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinReceptbok.Models.ViewModels
{
    public class ReceptIndexVM
    {
        public string Namn { get; set; }
        public string ReceptBeskrivning { get; set; }
        public int AntalPortioner { get; set; }
    }
}