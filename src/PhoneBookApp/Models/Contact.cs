﻿namespace PhoneBookApp.Models
{
    public class Contact
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public Address Address { get; set; }
    }
}
