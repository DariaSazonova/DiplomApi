using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace DiplomApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PhotosController : ControllerBase
    {
        public string photoColledge = "https://общее-дело.рф/wp-content/uploads/2013/04/n_1.jpg.jpg";
        [HttpGet("getColledgePhoto")]
        public string getColledgePhoto()
        {
            return photoColledge;
        }
    }
}
