using AutoMapper;
using dermal.api.Data;
using dermal.api.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace dermal.api.Controllers
{
    [Route("api/[controller]")]
    public class PatientsController : Controller
    {

        private readonly IMapper _mapper;
        private readonly DermalDbContext _context;

        public PatientsController(IMapper mapper, DermalDbContext context)
        {
            this._mapper = mapper;
            this._context = context;
        }

        public async Task<IActionResult> GetPatients([FromRoute]string searchTerm)
        {
            var patients = this._context.Patients;
            if (!String.IsNullOrEmpty(searchTerm)) {
                patients = patients.Where(p => p.Hu)
            }
            return Ok(patients);
        }

        [HttpGet("{patientId}")]
        public async Task<IActionResult> GetPatient([FromRoute]int patientId)
        {
            var patient = await this._context.Patients.SingleOrDefaultAsync(p => p.Id == patientId);
            return Ok(patient);
        }


        [HttpPost]
        public async Task<IActionResult> PostPatient([FromBody]PatientDTO patientDTO)
        {
            if (!ModelState.IsValid) {
                return BadRequest();
            }

            if (patientDTO == null)
            {
                return BadRequest();
            }
            if (patientDTO.Id != 0)
            {
                return BadRequest();
            }
            var patient = this._mapper.Map<Patient>(patientDTO);
            patient.Telecom = new List<ContactPoint>();
            patient.Addresses = new List<Address>();
            if (patientDTO.Email != null)
            {
                patient.Telecom.Add(patientDTO.Email);
            }
            if (patientDTO.MobilePhone != null)
            {
                patient.Telecom.Add(patientDTO.MobilePhone);
            }
            if (patientDTO.ResidentialAddress != null)
            {
                patient.Addresses.Add(patientDTO.ResidentialAddress);
            }
            if (patientDTO.PostalAddress != null)
            {
                patient.Addresses.Add(patientDTO.PostalAddress);
            }
            this._context.Patients.Add(patient);
            await this._context.SaveChangesAsync();
            return StatusCode(201);
        }
    }
}