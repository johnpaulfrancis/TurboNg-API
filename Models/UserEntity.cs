﻿namespace TurboNg_API.Models
{
    public class UserEntity
    {
        public int UserId { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public bool IsActive { get; set; }
    }
}