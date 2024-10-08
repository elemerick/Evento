﻿namespace Domain.Models.User
{
    public class UserCreationDto
    {
        public string Username { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Password { get; set; }

        public int RoleId { get; set; }  // "customer", "organizer", or "admin"
    }
}
