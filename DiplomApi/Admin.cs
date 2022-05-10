using System;
using System.Collections.Generic;

namespace DiplomApi
{
    public partial class Admin
    {
        public int IdAdmin { get; set; }
        public string Surname { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Patronymic { get; set; }
        public string Phone { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }

        public virtual User IdAdminNavigation { get; set; } = null!;
    }
}
