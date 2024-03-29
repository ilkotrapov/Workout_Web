﻿namespace Products_Web.Models.User
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }

        public UserViewModel(string id, string email, string name, string role)
        {
            this.Id = id;
            this.Email = email;
            this.Name = name;
            this.Role = role;
        }
    }
}