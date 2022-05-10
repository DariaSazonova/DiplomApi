
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DiplomApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicantController : ControllerBase
    {
        diplom1Context db = new();
        [HttpGet]
        public IEnumerable<Applicant> Get()
        {
            return db.Applicants.ToList();
        }

        [HttpGet("{email}")]
        public Applicant Get(string email)
        {
            return db.Applicants.Where(u => (u.Email == email)).FirstOrDefault();
        }
        [HttpPost]
        public async Task<ActionResult<Applicant>> Post(int IdApplicants, string Surname, string Name, string? Patronymic, string Phone, string Email, string DateOfBirth)
        {
            Applicant applicant = new()
            {
                IdApplicants = IdApplicants,
                Name = Name,
                Patronymic = Patronymic,
                Phone = Phone,
                Email = Email,
                DateOfBirth = DateOfBirth,
                Surname = Surname
            };

            db.Applicants.Add(applicant);
            await db.SaveChangesAsync();
            return Ok(IdApplicants);
        }

        [HttpPut]
        public async Task<ActionResult<Applicant>> Put(Applicant Applicant)
        {
            if (Applicant == null)
            {
                return BadRequest();
            }
            if (!db.Applicants.Any(x => x.IdApplicants == Applicant.IdApplicants))
            {
                return NotFound();
            }

            db.Update(Applicant);
            await db.SaveChangesAsync();
            return Ok(Applicant);
        }
    }
}
