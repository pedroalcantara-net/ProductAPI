﻿namespace Products.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public byte[] Password { get; set; }
    }
}
