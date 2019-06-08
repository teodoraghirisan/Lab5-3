﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Labo2.ViewModels
{
    public class RegisterPostModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [StringLength(100, MinimumLength = 6)]
        public string Password { get; set; }
        public DateTime DataRegistered { get; set; }
    }
}
