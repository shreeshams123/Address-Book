using System;

namespace Address_Book_Project
{
    public class AddressBookMain
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to address book program");
            AddressBook addressBook = new AddressBook();
            Console.WriteLine("Enter firstname");
            string fname=Console.ReadLine();
            Console.WriteLine("Enter lastname");
            string lname=Console.ReadLine();
            Console.WriteLine("Enter Address");
            string address=Console.ReadLine();
            Console.WriteLine("Enter city");
            string city=Console.ReadLine();
            Console.WriteLine("Enter state");
            string state = Console.ReadLine();
            Console.WriteLine("Enter zip");
            int zip=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter phone number");
            long phno=Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("Enter email");
            string email=Console.ReadLine();
            Contact contact = new Contact(fname,lname,address,city,state,zip,phno,email);
            addressBook.AddContact(contact);
            addressBook.EditContact();
        }
    }
}
