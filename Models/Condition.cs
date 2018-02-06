using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dermal.api.Models
{
    public class Condition
    {
        public int Id { get; set; }
        public string ClinicalStatus { get; set; }
        //public virtual Practitioner Asserter { get; set; }
        public string Code { get; set; }
        public string BodySite { get; set; }
        public DateTime? Onset  { get; set; }
        public DateTime? Abatement { get; set; }
        public DateTime AssertedDate { get; set; }
        public string Comment { get; set; }
    }
}
