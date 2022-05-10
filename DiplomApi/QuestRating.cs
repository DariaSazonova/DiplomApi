using System;
using System.Collections.Generic;

namespace DiplomApi
{
    public partial class QuestRating
    {
        public int IdApplicant { get; set; }
        public int IdQuest { get; set; }
        public string Result { get; set; } = null!;
        public int Id { get; set; }
        public string? Date { get; set; }
        public string? Answers { get; set; }

        public virtual Applicant IdApplicantNavigation { get; set; } = null!;
        public virtual QuestQuestion IdQuestNavigation { get; set; } = null!;
    }
}
