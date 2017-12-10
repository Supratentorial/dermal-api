using dermal.api.Data;
using dermal.api.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using dermal.api.Services;
using dermal.api.Interfaces;

namespace dermal.api.Controllers
{
    [Route("api/[controller]")]
    public class PatientsController : Controller
    {

        private readonly DermalDbContext _context;
        private readonly IPatientMapper _mapper;

        public PatientsController(IPatientMapper mapper, DermalDbContext context)
        {
            this._mapper = mapper;
            this._context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetPatients([FromQuery]string searchTerm)
        {
            IQueryable<Patient> patients = this._context.Patients.Include(p => p.Telecom).Include(p => p.Addresses).Include(p => p.Name).Include(p => p.GeneralPractitioner);
            if (!String.IsNullOrEmpty(searchTerm))
            {
                patients = patients.Where(p => p.Name.Given.Contains(searchTerm) || p.Name.Family.Contains(searchTerm));
            }
            var filteredPatients = await patients.ToListAsync();
            return Ok(filteredPatients);
        }

        [HttpGet("{patientId}")]
        public async Task<IActionResult> GetPatient([FromRoute]int patientId)
        {
            if (patientId == 0) {
                return BadRequest();
            }
            var patient = await this._context.Patients.Include(p => p.Name).Include(p => p.Addresses).Include(p => p.Telecom).SingleOrDefaultAsync(p => p.Id == patientId);
            if (patient == null) {
                return NotFound();
            }
            return Ok(_mapper.WritePatientDto(patient));
        }

        [HttpPut]
        public async Task<IActionResult> PutPatient([FromBody]PatientDto patientDto) {
            if (!ModelState.IsValid) {
                List<string> list = (from modelState in ModelState.Values from error in modelState.Errors select error.ErrorMessage).ToList();
                return new BadRequestObjectResult(list);
            }
            if (patientDto == null)
            {
                return BadRequest();
            }
            if (patientDto.Id == 0) {
                return BadRequest();
            }
            var patient = this._mapper.WritePatient(patientDto);
            this._context.Update(patient);
            return Ok(await this._context.SaveChangesAsync());
        }

        [HttpPost]
        public async Task<IActionResult> PostPatient([FromBody]PatientDto patientDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
             
            if (patientDto == null)
            {
                return BadRequest();
            }
            if (patientDto.Id != 0)
            {
                return BadRequest();
            }
            var patient = this._mapper.WritePatient(patientDto);
            this._context.Patients.Add(patient);
            await this._context.SaveChangesAsync();
            return StatusCode(201);
        }
    }
}