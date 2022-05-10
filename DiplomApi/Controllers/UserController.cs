
using Microsoft.AspNetCore.Mvc;

namespace DiplomApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        diplom1Context db = new();
        [HttpGet("{login}/{password}")]
        public User Get(string login, string password)
        {
            return db.Users.Where(u => (u.Login == login) && (u.Password == password)).FirstOrDefault();
        }
        [HttpPost]
        public async Task<ActionResult<int>> Post(string Login, string Password, string Role)
        {
            User user = new()
            {
                Login = Login,
                Password = Password,
                Role = Role
            };

            db.Users.Add(user);
            await db.SaveChangesAsync();
            var id = db.Users.Where(d => d.Login == user.Login).Select(i => i.Id).FirstOrDefault();

            if (!(id == null))
                return id;
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<ActionResult<User>> Put(User User)
        {
            if (User == null)
            {
                return BadRequest();
            }
            if (!db.Users.Any(x => x.Login == User.Login))
            {
                return NotFound();
            }

            db.Update(User);
            await db.SaveChangesAsync();
            return Ok(User);
        }
    }
}