using dermal.api.Dtos;
using dermal.api.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dermal.api.Services
{
    public class PatientMapper : IPatientMapper
    {
        private readonly IAgeUtilityMethods ageUtilityMethods;

        public PatientMapper(IAgeUtilityMethods ageUtilityMethods)
        {
            this.ageUtilityMethods = ageUtilityMethods;
        }

        public Patient WritePatient(PatientDto patientDto)
        {
            var patient = new Patient
            {
                Id = patientDto.Id,
                Active = patientDto.Active,
                Name = new HumanName
                {
                    Id = patientDto.NameId,
                    Prefix = patientDto.Title,
                    Given = patientDto.GivenNames,
                    Family = patientDto.FamilyName
                },
                Gender = patientDto.Gender,
                BirthDate = patientDto.BirthDate
            };
            var telecom = new List<ContactPoint>();
            if (patientDto.MobilePhone != null)
            {
                telecom.Add(patientDto.MobilePhone);
            }
            if (patientDto.Email != null) {
                telecom.Add(patientDto.Email);
            }
            patient.Telecom = telecom;
            return patient;
        }

        public PatientDto WritePatientDto(Patient patient)
        {
            var patientDto = new PatientDto
            {
                Id = patient.Id,
                NameId = patient.Name.Id,
                Title = patient.Name.Prefix,
                GivenNames = patient.Name.Given,
                FamilyName = patient.Name.Family,
                Gender = patient.Gender,
                BirthDate = patient.BirthDate,
                Active = patient.Active,
                Age = this.ageUtilityMethods.GetAgeString(patient.BirthDate),
                Email = patient.GetEmail(),
                MobilePhone = patient.GetMobilePhone(),
                ResidentialAddress = patient.GetResidentialAddress(),
                PostalAddress = patient.GetPostalAddress()
            };
            return patientDto;
        }
    }
}
