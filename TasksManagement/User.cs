﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TasksManagement.Domain
{
    public class User : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
        public virtual ICollection<UserUseCase> UserUserCases { get; set; }
       public virtual ICollection<Assignment> Assignments { get; set; }
    }
}
