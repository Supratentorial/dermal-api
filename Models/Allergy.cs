using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dermal.api.Models
{
    public class Allergy
    {
        public int Id { get; set; }
        //active | inactive |resolved
        public string ClinicalStatus { get; set; }
        //unconfirmed | confirmed |refuted | entered-in-error
        public string VerificationStatus { get; set; }
        //allergy | intolerance
        public string Type { get; set; }
        //Food | medication | environment | biologic
        public string Category { get; set; }
        //low | high | unable-to-assess
        public string Criticality { get; set; }
        public Patient Patient { get; set; }
        //Date the record was believed accurate
        public DateTime AssertedDate { get; set; }
        public Practitioner Recorder { get; set; }
        public DateTime LastOccurence { get; set; }

    }
}
