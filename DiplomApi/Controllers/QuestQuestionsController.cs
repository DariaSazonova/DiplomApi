
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DiplomApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuestQuestionsController : ControllerBase
    {
        diplom1Context db = new();
        [HttpGet]
        public IEnumerable<QuestQuestion> Get()
        {
            return db.QuestQuestions.ToList();
        }
        [HttpGet("{id}")]
        public QuestQuestion Get(int id)
        {
            return db.QuestQuestions.Where(u => (u.IdQuest == id)).FirstOrDefault();
        }
        [HttpPost]
        public async Task<ActionResult<QuestQuestion>> Post(QuestQuestion QuestQuestion)
        {
            if (QuestQuestion == null)
            {
                return BadRequest();
            }

            db.QuestQuestions.Add(QuestQuestion);
            await db.SaveChangesAsync();
            return Ok(QuestQuestion);
        }


        [HttpPut]
        public async Task<ActionResult<QuestQuestion>> Put(QuestQuestion QuestQuestion)
        {
            if (QuestQuestion == null)
            {
                return BadRequest();
            }
            if (!db.QuestQuestions.Any(x => x.IdQuest == QuestQuestion.IdQuest))
            {
                return NotFound();
            }

            db.Update(QuestQuestion);
            await db.SaveChangesAsync();
            return Ok(QuestQuestion);
        }
    }
}
