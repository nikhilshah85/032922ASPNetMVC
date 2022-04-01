using System;
using System.Collections.Generic;

#nullable disable

namespace Dataannotation_demo.Models.EF.Shopping
{
    public partial class DeptInfo
    {
        public DeptInfo()
        {
            EmployeeInfos = new HashSet<EmployeeInfo>();
        }

        public int DeptNo { get; set; }
        public string DeptName { get; set; }
        public string DeptLocation { get; set; }
        public string DeptHead { get; set; }

        public virtual ICollection<EmployeeInfo> EmployeeInfos { get; set; }
    }
}
