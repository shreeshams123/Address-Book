using System;
using System.Collections.Generic;
using System.Linq;

namespace Address_Book_Project
{
    public class AddressBookMain
    {
        static Dictionary<string, AddressBook> addbookmanager = new Dictionary<string, AddressBook>();
        public static void SearchByCity(string city)
        {
            var results = addbookmanager.Values.SelectMany(addressbook => addressbook.contacts).Where(contact => contact.City.Equals(city));
            foreach (var result in results)
            {
                Console.WriteLine(result.FirstName+" "+result.LastName);
            }
        }
        public static void SearchByState(string state)
        {
            var results = addbookmanager.Values.SelectMany(addressbook => addressbook.contacts).Where(contact => contact.State.Equals(state));
            foreach (var result in results)
            {
                Console.WriteLine(result.FirstName + " " + result.LastName);
            }
        }
        public static void Main(string[] args)
        {
            
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("MENU");
                Console.WriteLine("1.Add Address book\n2.Add contact to existing address book\n3.Delete contact from a address book\n4.Display all address books\n5.Display contacts in a address book\n6.Edit a contact in a address book\n7.Add multiple contacts to a address book\n8.Search by City\n9.Search by State\n10.Exit");
                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        Console.WriteLine("Enter name of address book");
                        string name = Console.ReadLine();
                        if (!addbookmanager.ContainsKey(name))
                        {
                            addbookmanager[name] = new AddressBook();
                        }
                        else
                        {
                            Console.WriteLine("Address book already exist");
                        }
                        break;
                    case 2:
                        Console.WriteLine("Enter the name of the Address Book to add contact:");
                        string existingBookName = Console.ReadLine();

                        if (addbookmanager.ContainsKey(existingBookName))
                        {
                            Console.WriteLine("Enter First Name:");
                            string firstName = Console.ReadLine();
                            Console.WriteLine("Enter Last Name:");
                            string lastName = Console.ReadLine();
                            Console.WriteLine("Enter Address:");
                            string address = Console.ReadLine();
                            Console.WriteLine("Enter City:");
                            string City = Console.ReadLine();
                            Console.WriteLine("Enter State:");
                            string state = Console.ReadLine();
                            Console.WriteLine("Enter Zip:");
                            int zip = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter Phone Number:");
                            long phoneNumber = Convert.ToInt64(Console.ReadLine());
                            Console.WriteLine("Enter Email:");
                            string email = Console.ReadLine();

                            Contact contact = new Contact(firstName, lastName, address, City, state, zip, phoneNumber, email);
                            addbookmanager[existingBookName].AddContact(contact);
                            
                        }
                        else
                        {
                            Console.WriteLine($"Address Book '{existingBookName}' does not exist.");
                        }
                        break;
                    case 3:
                        Console.WriteLine("Enter the name of the address book to delete contact from");
                        string bookname = Console.ReadLine();
                        if (addbookmanager.ContainsKey(bookname))
                        {
                            addbookmanager[bookname].DeleteContact();
                        }
                        else
                        {
                            Console.WriteLine("Address book not found");
                        }
                        break;
                    case 4:foreach(var item in addbookmanager)
                        {
                            Console.WriteLine(item.Key);
                        }
                        break;
                    case 5:Console.WriteLine("Enter the name of the address book");
                        string bname= Console.ReadLine();
                        if (addbookmanager.ContainsKey(bname))
                        {
                            foreach (var item in addbookmanager[bname].contacts)
                            {
                                Console.WriteLine(item.FirstName + " " + item.LastName);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Address book not found");
                        }
                        break;
                    case 6:Console.WriteLine("Enter the address book from which the contact to be edited");
                        string ename= Console.ReadLine();
                        if (addbookmanager.ContainsKey(ename))
                        {
                            addbookmanager[ename].EditContact();
                        }
                        else
                        {
                            Console.WriteLine("Address Book not found");
                        }
                        break;
                    case 7:Console.WriteLine("Enter the name of the address book");
                        string mname= Console.ReadLine();
                        if (addbookmanager.ContainsKey(mname))
                        {
                            addbookmanager[mname].AddMultipleContacts();
                        }
                        else
                        {
                            Console.WriteLine("Address book not found");
                        }
                        break;
                    case 8:Console.WriteLine("Enter the City");
                        string city=Console.ReadLine();
                        SearchByCity(city);
                        break;
                    case 10: flag = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }

            }
        }
    }
}
