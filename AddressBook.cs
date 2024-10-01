using System;
using System.Collections.Generic;
using System.Text;

namespace Address_Book_Project
{
    public class AddressBook
    {
        public List<Contact> contacts;
        public AddressBook()
        {
            contacts=new List<Contact>();
        }
        public void addContact(Contact contact)
        {
            contacts.Add(contact);
        }
    }
}
