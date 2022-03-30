using System;
using System.Collections.Generic;

#nullable disable

namespace shoppingAPP_EFDatabaseFirst.Models.EF.Shopping
{
    public partial class Customer
    {
        public int CId { get; set; }
        public string CName { get; set; }
        public string CCity { get; set; }
        public int? CWalletBalance { get; set; }
        public bool? CIsActive { get; set; }
        public string CCustomerType { get; set; }
    }
}
