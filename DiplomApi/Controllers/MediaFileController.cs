
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DiplomApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MediaFileController : ControllerBase
    {
        diplom1Context db = new();
        [HttpGet]
        public IEnumerable<MediaFile> Get(string type = "file")
        {
            return db.MediaFiles.Where(a => a.Midiatype == type).ToList();
        }

        //[HttpGet("{type}")]
        //public IEnumerable<MediaFile> Get(string type= "SpecialityInformation")
        //{
        //    return db.MediaFiles.Where(a => a.Midiatype == type).ToList();
        //}

        //[HttpPut("{type}")]
        //public async Task<ActionResult<MediaFile>> Put(string type = "SpecialityInformation")
        //{

        //    var list = db.MediaFiles.Where(a => a.Midiatype == type).ToList();
        //    foreach (var item in list)
        //    {
        //        item.Path.Replace("\r", "\n");
        //        db.Update(item);
        //        await db.SaveChangesAsync();
        //    }
        //    return Ok();
        //}
        [HttpPut]
        public async Task<ActionResult<MediaFile>> Put(MediaFile MediaFile)
        {
            if (MediaFile == null)
            {
                return BadRequest();
            }
            if (!db.MediaFiles.Any(x => x.Id == MediaFile.Id))
            {
                return NotFound();
            }

            db.MediaFiles.Update(MediaFile);
            await db.SaveChangesAsync();
            return Ok(MediaFile);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<MediaFile>> Delete(string id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            else
            {
                var forDelete = db.MediaFiles.Where(file => file.Id == Convert.ToInt32(id)).FirstOrDefault();
                if (forDelete != null)
                {
                    db.MediaFiles.Remove(forDelete);
                    await db.SaveChangesAsync();
                    return Ok(forDelete);
                }
                else { return BadRequest(); }
            }
        }

        [HttpPost]
        public async Task<ActionResult<MediaFile>> Post(MediaFile MediaFile)
        {
            if (MediaFile == null)
            {
                return BadRequest();
            }
            db.MediaFiles.Add(MediaFile);
            await db.SaveChangesAsync();
            return Ok(MediaFile);
        }
    }
}
