﻿namespace JWTtoken.Models
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public User(string _username , string _password)
        {
            Username = _username;
            Password = _password;
        }


    }

}
