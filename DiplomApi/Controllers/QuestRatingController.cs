
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace DiplomApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class QuestRatingController : ControllerBase
    {
        diplom1Context db = new();
        [HttpGet]
        public IEnumerable<QuestRating> Get()
        {
            return db.QuestRatings.OrderBy(o => o.IdQuest).OrderByDescending(o => o.Result).ToList();
        }



        [HttpGet("{idApplicant}")]
        public List<QuestRating> Get(int idApplicant, int idTest = 0)
        {
            if (idTest == 0)
                return db.QuestRatings.Where(u => (u.IdApplicant == idApplicant)).OrderBy(i => i.Id).ToList();
            else
                return db.QuestRatings.Where(u => (u.IdApplicant == idApplicant && u.Id == idTest)).OrderBy(i => i.Id).ToList();
        }
        [HttpPost]
        public async Task<ActionResult<QuestRating>> Post(int idquest, int idapplicatn, double res, string date, List<Answers> answers)
        {
            QuestRating QuestRating = new()
            {
                IdQuest = idquest,
                IdApplicant = idapplicatn,
                Result = res.ToString(),
                Date = date,
                Answers = JsonConvert.SerializeObject(answers)
            };
            if (QuestRating == null)
            {
                return BadRequest();
            }

            db.QuestRatings.Add(QuestRating);

            await db.SaveChangesAsync();
            return Ok(QuestRating);
        }

        [HttpPut]
        public async Task<ActionResult<QuestRating>> Put(QuestRating QuestRating)
        {
            if (QuestRating == null)
            {
                return BadRequest();
            }
            if (!db.QuestRatings.Any(x => x.IdApplicant == QuestRating.IdApplicant && x.IdQuest == QuestRating.IdQuest))
            {
                return NotFound();
            }

            db.Update(QuestRating);
            await db.SaveChangesAsync();
            return Ok(QuestRating);
        }
        public class Answers
        {
            public int id { get; set; }
            public string yourAnswer { get; set; }
            public string trueAnswer { get; set; }

        }

    }
}
