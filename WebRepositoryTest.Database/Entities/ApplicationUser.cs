﻿using Microsoft.AspNetCore.Identity;

namespace WebRepositoryTest.Database
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
