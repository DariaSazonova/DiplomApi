using System;
using System.Collections.Generic;

namespace DiplomApi
{
    public partial class User
    {
        public int Id { get; set; }
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Role { get; set; } = null!;

        public virtual Admin Admin { get; set; } = null!;
        public virtual Applicant Applicant { get; set; } = null!;
    }
}
