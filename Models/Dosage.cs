using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dermal.api.Models
{
    public class Dosage
    {
        public int Id { get; set; }

        public string AdditionalInstruction { get; set; }
        public bool AsNeeded { get; set; }
    }
}
