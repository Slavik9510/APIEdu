﻿namespace ASP_WebApi_Edu.Models.DTO
{
    public class UserAccountDto
    {
        public string Username { get; set; }

        public string Token { get; set; }
        public string? PhotoUrl { get; set; }

        public string KnownAs { get; set; }
    }
}
