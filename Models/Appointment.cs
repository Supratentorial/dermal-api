using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dermal.api.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public string Comment { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Practitioner Practitioner { get; set; }
        public Patient Patient { get; set; }
    }
}
