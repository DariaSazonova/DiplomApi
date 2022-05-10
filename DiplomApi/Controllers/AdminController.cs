
using Microsoft.AspNetCore.Mvc;

namespace DiplomApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        diplom1Context db = new();

        [HttpGet("{email}")]
        public Admin Get(string email)
        {
            return db.Admins.Where(u => (u.Email == email)).FirstOrDefault();
        }
        [HttpPost]
        public async Task<ActionResult<Admin>> Post(Admin Admin)
        {
            if (Admin == null)
            {
                return BadRequest();
            }

            db.Admins.Add(Admin);
            await db.SaveChangesAsync();
            return Ok(Admin);
        }

        [HttpPut]
        public async Task<ActionResult<Admin>> Put(Admin Admin)
        {
            if (Admin == null)
            {
                return BadRequest();
            }
            if (!db.Admins.Any(x => x.IdAdmin == Admin.IdAdmin))
            {
                return NotFound();
            }

            db.Update(Admin);
            await db.SaveChangesAsync();
            return Ok(Admin);
        }
    }
}
