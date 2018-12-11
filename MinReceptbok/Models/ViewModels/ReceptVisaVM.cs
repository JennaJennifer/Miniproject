using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinReceptbok.Models.ViewModels
{
    public class ReceptVisaVM
    {
        public int Id { get; set; }
        public string Namn { get; set; }
        public string ReceptBeskrivning { get; set; }
        public int? AntalPortioner { get; set; }
    }
}
