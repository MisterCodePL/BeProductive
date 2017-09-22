using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace BeProductive.Core.Domain
{
    public class User
    {
        private static readonly Regex PasswordRegex = new Regex("^(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9]).{4,20}$");
        private static readonly Regex UsernameRegex = new Regex("^[A-Za-z0-9_-]{3,15}$");
        private static readonly Regex FullNameRegex = new Regex("^[^@#$%^&*!]+$");

        public Guid Id { get; protected set; }
        public string Email { get; protected set; }
        public string Password { get; protected set; }
        public string Salt { get; protected set; }
        public string Username { get; protected set; }
        public string FullName { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }

        public IEnumerable<Event> Events { get; protected set; } 
        
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
            UpdateStatus();
        }

        public void SetUsername(string username)
        {
            if (username == null) throw new ArgumentNullException();
            if (Username == username) return;
            if (username.Length < 4) throw new Exception("Username is shorter than 3 chars.");
            if (username.Length > 20) throw new Exception("Username is longer than 15 chars.");
            if (!UsernameRegex.IsMatch(username))
                throw new Exception("Username contains inappropriate characters.");
            Username = username;
            UpdateStatus();
        }

        public void SetEmail(string email)
        {
            if (email == null) throw new ArgumentNullException();
            if (Email == email.ToLowerInvariant()) return;
            var address = new MailAddress(email);
            if (address == null) throw new Exception("Email address is incorrect.");
            Email = email.ToLowerInvariant();
            UpdateStatus();
        }

        public void SetPassword(string password, string salt)
        {
            if (password == null) throw new ArgumentNullException();
            if (Password == password) return;
            if (password.Length < 4) throw new Exception("Password is shorter than 4 chars.");
            if (password.Length > 20) throw new Exception("Password is longer than 20 chars.");
            if (!PasswordRegex.IsMatch(password))
                throw new Exception("Password do not have one big letter, one small letter or one digit.");
            Password = password;
            Salt = salt;
            UpdateStatus();
        }

        public void SetFullName(string fullName)
        {
            if (fullName == null) throw new ArgumentNullException();
            if (FullName == fullName) return;
            if (!FullNameRegex.IsMatch(fullName))
                throw new Exception("FullName contains inappropriate characters.");
            FullName = fullName;
            UpdateStatus();
        }

        private void UpdateStatus()
        {
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
