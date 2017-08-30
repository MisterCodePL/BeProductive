using System;
using System.Collections.Generic;
using System.Net.Mail;

namespace BeProductive.Core.Domain
{
    class User
    {
        public Guid Id { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string Salt { get; private set; }
        public string Username { get; private set; }
        public string FullName { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public IEnumerable<Event> Events { get; private set; } 
        
        protected User()
        {
        }

        public User(string email, string username, string password, string salt)
        {
            Id = Guid.NewGuid();
            SetEmail(email);
            SetUsername(username);
            SetPassword(password, salt);
            CreatedAt = DateTime.UtcNow;
        }

        public void SetUsername(string username)
        {
            if (username != null) Username = username;
            else throw new NullReferenceException();
        }

        public void SetEmail(string email)
        {
            var address = new MailAddress(email);
            if (address != null) Email = email;
            else throw new Exception("Email address is incorrect.");
        }

        public void SetPassword(string password, string salt)
        {
            if (password == null) throw new NullReferenceException();
            if (password.Length >= 8)
            {
                Password = password;
                Salt = salt;
            }
            else throw new Exception("Password is too short.");
        }
    }
}
