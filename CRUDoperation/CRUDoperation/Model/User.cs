﻿namespace CRUDoperation.Model
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }

    }
}
