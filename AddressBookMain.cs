using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Transactions;

namespace Address_Book_Project
{
    public class AddressBookMain
    {
        static Dictionary<string, AddressBook> addbookmanager = new Dictionary<string, AddressBook>();
        static Dictionary<string,List<Contact>> viewByCityDict = new Dictionary<string, List<Contact>>();
        static Dictionary<string,List<Contact>> viewByStateDict = new Dictionary<string, List<Contact>>();
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
        public static void AddToStateorCityDictionary(Contact contact)
        {
            if (!viewByCityDict.ContainsKey(contact.City))
            {
                viewByCityDict[contact.City] = new List<Contact>();
            }
            else
            {
                viewByCityDict[contact.City].Add(contact);
            }
        

            if (!viewByStateDict.ContainsKey(contact.State))
            {
                viewByStateDict[contact.State] = new List<Contact>();
            }
            else
            {
                viewByStateDict[contact.State].Add(contact);
            }
        }
        public static void ViewByCity(string city)
        {
            if (!viewByCityDict.ContainsKey(city))
            {
                Console.WriteLine(city);
                viewByCityDict[city].ForEach(contact => Console.WriteLine(contact.FirstName));
            }
            else
            {
                Console.WriteLine("No contacts found");
            }
        }
        public static void ViewByState(string state)
        {
            if (!viewByStateDict.ContainsKey(state))
            {
                Console.WriteLine(state);
                viewByStateDict[state].ForEach(contact => Console.WriteLine(contact.FirstName));
            }
            else
            {
                Console.WriteLine("No contacts found");
            }
        }
        public static void CountByCity(string city)
        {
            if (viewByCityDict.ContainsKey(city))
            {
                Console.WriteLine(city + ":" + viewByCityDict[city].Count);
            }
            else
            {
                Console.WriteLine("City not found");
            }
        }
        public static void CountByState(string state)
        {
            if (viewByStateDict.ContainsKey(state))
            {
                Console.WriteLine(state +":" + viewByStateDict[state].Count);
            }
            else
            {
                Console.WriteLine("State not found");
            }
        }
        public static void Main(string[] args)
        {
            
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("MENU");
                Console.WriteLine("1.Add Address book\n2.Add contact to existing address book\n3.Delete contact from a address book\n4.Display all address books\n5.Display contacts in a address book\n6.Edit a contact in a address book\n7.Add multiple contacts to a address book\n8.Search by City\n9.Search by State\n10.View Contacts by city\n11.View Contacts by state\n12.Count contacts by State\n13.Count contacts by City\n14.Exit");
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
                            string State = Console.ReadLine();
                            Console.WriteLine("Enter Zip:");
                            int zip = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter Phone Number:");
                            long phoneNumber = Convert.ToInt64(Console.ReadLine());
                            Console.WriteLine("Enter Email:");
                            string email = Console.ReadLine();

                            Contact contact = new Contact(firstName, lastName, address, City, State, zip, phoneNumber, email);
                            addbookmanager[existingBookName].AddContact(contact);
                            AddToStateorCityDictionary(contact);


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
                    case 9:Console.WriteLine("Enter the State");
                        string state= Console.ReadLine();
                        SearchByState(state);
                        break;
                    case 10: Console.WriteLine("Enter the city");
                        string City1= Console.ReadLine();
                        ViewByCity(City1);
                        break;
                    case 11: Console.WriteLine("Enter the state");
                        string State1 = Console.ReadLine();
                        ViewByState(State1);
                        break;
                    case 12: Console.WriteLine("Enter city");
                        string City2= Console.ReadLine();
                        CountByCity(City2);
                        break;
                    case 13: Console.WriteLine("Enter state");
                        string State2= Console.ReadLine();
                        CountByState(State2);
                        break;
                    case 14: flag = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }

            }
        }
    }
}
