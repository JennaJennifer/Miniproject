using System;
using System.Collections.Generic;

namespace MinReceptbok.Models.Entities
{
    public partial class Receptbank
    {
        public int Id { get; set; }
        public string Namn { get; set; }
        public string Recept { get; set; }
        public int? AntalPortioner { get; set; }
    }
}
