using System;
using System.Collections.Generic;

namespace MinReceptbok.Models.Entities
{
    public partial class Images
    {
        public int Id { get; set; }
        public int Rid { get; set; }
        public string ImageRef { get; set; }

        public Receptbank R { get; set; }
    }
}
