using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dermal.api.Models
{
    public class MedicationRequest
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public DateTime AuthoredOn { get; set; }

        public virtual Encounter Context { get; set; }
        public virtual Patient Subject { get; set; }
    }
}
