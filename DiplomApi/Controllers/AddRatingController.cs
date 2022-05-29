
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
namespace DiplomApi.Controllers
{

    public class AddRating
    {
        public int id { get; set; }
        public int idApplicant { get; set; }
        public string ResultText { get; set; }
        public string Fio { get; set; }
        public string Phone { get; set; }
        public string date { get; set; }
        public string level { get; set; }
    }
    [ApiController]
    [Route("api/[controller]")]
    public class AddRatingController : ControllerBase
    {
        diplom1Context db = new();
        [HttpGet]
        public List<AddRating> Get(int level, int applicantId = 0)
        {
            List<AddRating> list = new();
            var js = db.QuestQuestions.Where(q => q.IdQuest == level).Select(q => q.Questions).FirstOrDefault();


            if (js != null)
            {
                double forParse;
                var countQuestions = JArray.Parse(js).Count();
                //string t = db.QuestRatings.Where(l => l.IdQuest == level).Select(s => s.Result).FirstOrDefault();
                //bool t1= double.TryParse(t, out forParse);
                //if(t1)
                if (applicantId == 0 && level != 0)
                {
                    list = db.QuestRatings.Where(l => l.IdQuest == level).OrderByDescending(a => a.Result).Join(db.Applicants, q => q.IdApplicant, a => a.IdApplicants, (q, a) => new AddRating
                    {
                        id = q.Id,
                        idApplicant = q.IdApplicant,
                        Fio = $"{a.Surname} {a.Name} {a.Patronymic}",
                        Phone = a.Phone,
                        ResultText = q.Result,//double.TryParse(q.Result, out forParse) ? $"{Math.Round((Convert.ToDouble(c) * countQuestions), 0, MidpointRounding.ToEven)} из {countQuestions} " : q.Result,
                        level = q.IdQuest.ToString(),
                        date = q.Date
                    }).ToList();

                    foreach (var el in list.Where(s=>s.ResultText=="Нет данных").ToList())
                    {
                        list.Remove(el);
                    }

                    foreach (var item in list)
                    {
                        bool t1= double.TryParse(item.ResultText, out forParse);
                        if (t1)
                        {
                            item.ResultText = $"{Math.Round((Convert.ToDouble(item.ResultText) * countQuestions), 0, MidpointRounding.ToEven)} из {countQuestions} ";
                        }
                    }
                    for (var i = 0; i < list.Count; i++)
                    {
                        var item = list.Where(f => f.Phone == list[i].Phone).ToList().ElementAt(0);

                        foreach (var el in list.Where(f => f.Phone == list[i].Phone).ToList())
                        {
                            list.Remove(el);
                        }
                        list.Add(item);

                    }
                }
                else if (applicantId != 0)
                {
                    list = db.QuestRatings.Where(l => l.IdQuest == level && l.IdApplicant == applicantId).OrderByDescending(a => a.Result).Join(db.Applicants, q => q.IdApplicant, a => a.IdApplicants, (q, a) => new AddRating
                    {
                        id = q.Id,
                        idApplicant = q.IdApplicant,
                        Fio = $"{a.Surname} {a.Name} {a.Patronymic}",
                        Phone = $"Уровень {q.IdQuest}",
                        ResultText = q.Result,//double.TryParse(q.Result, out forParse) ? $"{Math.Round((Convert.ToDouble(q.Result) * countQuestions), 0, MidpointRounding.ToEven)} из {countQuestions} " : q.Result,
                        level = q.IdQuest.ToString(),
                        date = q.Date
                    }).ToList();
                    foreach (var item in list)
                    {
                        bool t1 = double.TryParse(item.ResultText, out forParse);
                        if (t1)
                        {
                            item.ResultText = $"{Math.Round((Convert.ToDouble(item.ResultText) * countQuestions), 0, MidpointRounding.ToEven)} из {countQuestions} ";
                        }
                    }
                }
                else list = null;
                list = list.OrderByDescending(d => d.date).ToList();
                return list;
            }
            else return null;
        }

    }
}
