﻿using System.ComponentModel.DataAnnotations;

namespace ASP_WebApi_Edu.Models.DTO
{
    public class LoginDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
