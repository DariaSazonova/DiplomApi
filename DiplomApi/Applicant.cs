using System;
using System.Collections.Generic;

namespace DiplomApi
{
    public partial class Applicant
    {
        public Applicant()
        {
            QuestRatings = new HashSet<QuestRating>();
        }

        public int IdApplicants { get; set; }
        public string Surname { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Patronymic { get; set; }
        public string Phone { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string DateOfBirth { get; set; } = null!;

        public virtual User IdApplicantsNavigation { get; set; } = null!;
        public virtual ICollection<QuestRating> QuestRatings { get; set; }
    }
}
