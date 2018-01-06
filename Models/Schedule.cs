using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dermal.api.Models
{
    public class Schedule
    {
        public int Id { get; set; }
        public Practitioner Actor { get; set; }
        public TimeSpan DefaultAppointmentDuration { get; set; }
    }
}
