using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using egz.Models;
using Microsoft.AspNetCore.Mvc;

namespace egz.Controllers
{
    public class HospitalController : ControllerBase
    {
        private readonly HospitalDbContext hospitalDbContext;

        public HospitalController(HospitalDbContext hospitalDbContext)
        {
            this.hospitalDbContext = hospitalDbContext;
        }

        [HttpGet("{id}")]
        public IActionResult GetMedicament(int id)
        {
            if (hospitalDbContext.Medicament.Where(d => d.IdMedicament == id).Any())
            {
                var doctor = hospitalDbContext.Medicament.SingleOrDefault(d => d.IdDoctor == id);
                return Ok(doctor);
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePatient(int id)
        {
            if (hospitalDbContext.Patient.Where(d => d.IdPatient == id).Any())
            {

                var prescription = hospitalDbContext.Prescription.SingleOrDefault(d => d.IdPatient == id);
                var prescriptionMed = hospitalDbContext.Prescription_Medicament.Where(d => d.IdPrescription == prescription.IdPrescription).ToList();
                var patient = hospitalDbContext.Patient.SingleOrDefault(d => d.IdPatient == id);
                foreach (var item in prescriptionMed)
                {
                    hospitalDbContext.Prescription_Medicament.Remove(item);
                }
                hospitalDbContext.Prescription.Remove(prescription);
                hospitalDbContext.Patient.Remove(patient);
                hospitalDbContext.SaveChanges();
                return Ok();
            }
            return NotFound();
        }
    }
}