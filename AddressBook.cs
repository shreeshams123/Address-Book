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
        public void AddContact(Contact contact)
        {
            contacts.Add(contact);
        }
        public void EditContact()
        {
            Console.WriteLine("Enter firstname");
            string fname=Console.ReadLine();

            Console.WriteLine("Enter lastname");
            string lname=Console.ReadLine();
            Contact contactToEdit = null; ;
            foreach (var contact in contacts)
            {
                if (contact.FirstName == fname && contact.LastName == lname)
                {
                   contactToEdit = contact;
                    break;
                }
            }
            if (contactToEdit != null)
            {
                Console.WriteLine("Enter new address");
                contactToEdit.Address = Console.ReadLine();
                Console.WriteLine("Enter city");
                contactToEdit.City=Console.ReadLine();
                Console.WriteLine("Enter state");
                contactToEdit.State=Console.ReadLine();
                Console.WriteLine("Enter zip");
                contactToEdit.Zip=Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter phone number");
                contactToEdit.PhoneNumber=Convert.ToInt64(Console.ReadLine());
                Console.WriteLine("Enter email");
                contactToEdit.Email=Console.ReadLine();
                Console.WriteLine("Contact updated successfully");

            }
            else
            {
                Console.WriteLine("Contact not found");
            }
        }
        public void DeleteContact()
        {
            Console.WriteLine("Enter the first name and last name of the contact to be deleted");
            string fname=Console.ReadLine() ;
            string lname=Console.ReadLine();
            foreach (var contact in contacts)
            {
                if (contact.FirstName == fname && contact.LastName == lname)
                {
                    contacts.Remove(contact);
                    Console.WriteLine("Deleted contact successfully");
                    return;
                }
            }
                
        Console.WriteLine("Contact not found");
                
            
        }
    }
}
