using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindFunder.Infra.Domain.Entities
{
    public class Audit
    {
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set;}
        //public string CreatedBy { get; set; }
        //public string UpdatedBy { get; set;}
        public bool IsActive { get; set; }
    }
}
