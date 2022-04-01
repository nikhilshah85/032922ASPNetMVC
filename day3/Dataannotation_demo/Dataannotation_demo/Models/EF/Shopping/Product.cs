using System;
using System.Collections.Generic;

#nullable disable

namespace Dataannotation_demo.Models.EF.Shopping
{
    public partial class Product
    {
        public int PId { get; set; }
        public string PName { get; set; }
        public string PCategory { get; set; }
        public int? PPrice { get; set; }
        public bool? PIsInStock { get; set; }
        public int? PDiscount { get; set; }
    }
}
