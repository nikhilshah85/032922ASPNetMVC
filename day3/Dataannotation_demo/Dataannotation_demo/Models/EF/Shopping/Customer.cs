using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
#nullable disable

namespace Dataannotation_demo.Models.EF.Shopping
{
    public partial class Customer
    {
        public int CId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage ="Name cannot be left blank")]
        [StringLength(20,MinimumLength =5,ErrorMessage ="Name needs to be between 5 and 20 characters")]
        [System.ComponentModel.DataAnnotations.Display(Name ="Customer Name")]
        public string CName { get; set; }

        [System.ComponentModel.DataAnnotations.]
        [Display(Name ="City")]
         public string CCity { get; set; }

        [Display(Name ="Wallet Balance")]
        [Range(1000,15000,ErrorMessage ="Balance needs to be between 1K and 15K only")]
        [Required(ErrorMessage ="Wallet Balance is Mandatory")]
        public int? CWalletBalance { get; set; }
        public bool? CIsActive { get; set; }
        public string CCustomerType { get; set; }
    }
}
