﻿using System.ComponentModel.DataAnnotations;

namespace Laba4.Models
{


    public class Contacts
    {
        [Key]
        public string Nickname { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public DateTime Birthday { get; set; }

    }
}