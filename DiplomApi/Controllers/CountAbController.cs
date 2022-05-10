
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace DiplomApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountAbController : ControllerBase
    {
        diplom1Context db = new();
        [HttpGet]
        public IEnumerable<countRating> Get(string month)
        {
            var checkmonth = db.QuestRatings.ToList();
            List<countRating> list = new();
            countRating item = new();
            var lastDate = "";
            foreach (var check in checkmonth)
            {
                var Month = (check.Date.ElementAt(3) == '0' ? "" : check.Date.ElementAt(3)) + "" + check.Date.ElementAt(4);
                if (Month == month)
                {
                    if (check.Date.Substring(0, 10) == lastDate)
                    {
                        item.count++;
                    }
                    else
                    {
                        lastDate = check.Date.Substring(0, 10);
                        if (item.date != null)
                            list.Add(item);
                        item = new countRating
                        {
                            date = lastDate,
                            count = 1
                        };
                    }
                }
            }
            if (item.date != null)
                list.Add(item);
            return list;
        }
        public class countRating
        {
            public string date { get; set; }
            public int count { get; set; }
        }
    }
}
