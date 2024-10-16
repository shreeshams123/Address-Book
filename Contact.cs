﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Address_Book_Project
{
    public class Contact
    {
        public string FirstName {  get; set; }
        public string LastName { get; set; }
        public string Address {  get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zip {  get; set; }
        public long PhoneNumber {  get; set; }
        public string Email { get; set; }
        public Contact(string firstName, string lastName, string address, string city, string state, int zip, long phoneNumber, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            City = city;
            State = state;
            Zip = zip;
            PhoneNumber = phoneNumber;
            Email = email;
        }
        public bool Equal(Object obj)
        {
            if (obj is Contact contact)
            {
                return this.FirstName.Equals(contact.FirstName) && this.LastName.Equals(contact.LastName);
            }
            return false;
        }
    }
}
