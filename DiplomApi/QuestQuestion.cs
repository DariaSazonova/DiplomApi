using System;
using System.Collections.Generic;

namespace DiplomApi
{
    public partial class QuestQuestion
    {
        public QuestQuestion()
        {
            QuestRatings = new HashSet<QuestRating>();
        }

        public int IdQuest { get; set; }
        public string? Questions { get; set; }

        public virtual ICollection<QuestRating> QuestRatings { get; set; }
    }
}
