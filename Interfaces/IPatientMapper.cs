using dermal.api.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dermal.api.Interfaces
{
    public interface IPatientMapper
    {
        PatientDto WritePatientDto(Patient patient);
        Patient WritePatient(PatientDto patientDto);
    }
}
