﻿using System;

namespace dermal.api.Dtos
{
    public class PatientDto
    {
        public int Id { get; set; }
        public ContactPoint MobilePhone { get; set; }
        public ContactPoint Email { get; set; }
        public int NameId { get; set; }
        public string Title { get; set; }
        public string GivenNames { get; set; }
        public string FamilyName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public bool Active { get; set; }
        public Address ResidentialAddress { get; set; }
        public Address PostalAddress { get; set; }
        public Practitioner GeneralPractitioner { get; set; }
    }
}
