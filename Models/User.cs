using System;

namespace Models
{
    public class User
    {
        public User() : base()
        {
        }

        public int Id { get; set; }
        public string FullName { get; set; }
        public string Username { get; set; }    
        public string Password { get; set; }
    }
}