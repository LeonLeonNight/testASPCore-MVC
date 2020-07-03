using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace testCore.Models.Account
{
    public class ApplicationUser : IdentityUser
    {
        [MaxLength(70)]
        [Required]
        public string FirstName { get; set; }

        [MaxLength(70)]
        public string LastName { get; set; }
    }
}
