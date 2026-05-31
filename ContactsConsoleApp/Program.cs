using System;
using System.Data;
using ContactsBussinessLayer;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsConsoleApp
{
    internal class Program
    {

        static void FindContact(int ID)
        {
            clsContact Contact = clsContact.Find(ID);

            if(Contact != null)
            {
                Console.WriteLine(Contact.FirstName + " " + Contact.LastName);
                Console.WriteLine(Contact.Email);
                Console.WriteLine(Contact.Phone);
                Console.WriteLine(Contact.Address);
                Console.WriteLine(Contact.DateOfBirth);
                Console.WriteLine(Contact.CountryID);
                Console.WriteLine(Contact.ImagePath);
            }
            else
            {
                Console.WriteLine("Contact [" + ID + "] Not Found!");
            }
        }

        static void AddNewContact()
        {
            clsContact Contact = new clsContact();

            Contact.FirstName = "Mohammed";
            Contact.LastName = "Alrehaili";
            Contact.Email = "m.abdullah.re@gmail.com";
            Contact.Phone = "123123123";
            Contact.Address = "address1";
            Contact.DateOfBirth = new DateTime(2003, 1, 3);
            Contact.CountryID = 1;
            Contact.ImagePath = "";

            if(Contact.Save())
            {
                Console.WriteLine("Contact Added Sucessfully with id= "+ Contact.ID);
            }
        }

        static void UpdateContact(int ID)
        {
            clsContact Contact = clsContact.Find(ID);

            if (Contact != null)
            {
                Contact.FirstName = "Mohammed";
                Contact.LastName = "Alrehaili";
                Contact.Email = "m.abdullah@gmail.com";
                Contact.Phone = "5325235234";
                Contact.Address = "address1";
                Contact.DateOfBirth = new DateTime(2003, 1, 3);
                Contact.CountryID = 1;
                Contact.ImagePath = "";

                if(Contact.Save())
                {
                    Console.WriteLine("Contact Updated Successfully");
                }
            }
            else
            {
                Console.WriteLine("Not Found!");
            }
        }
        
        static void DeleteContact(int ID)
        {

            if (clsContact.isContactExisit(ID))
                if (clsContact.DeleteContact(ID))
                {
                    Console.WriteLine("Contact Deleted Sucessfully");
                }
                else
                {
                    Console.WriteLine("Failed to delete contact");
                }
            else
                Console.WriteLine("The Contact with id = " + ID + " is not Found");
        }

        static void ListContacts()
        {
            DataTable dataTable = clsContact.GetAllContact();

            Console.WriteLine("Contacts Data:");

            foreach(DataRow row in dataTable.Rows)
            {
               Console.WriteLine($"{row["ContactID"]}, {row["FirstName"]} {row["LastName"]}");
            }
        }

        static void IsContactExisit(int ID)
        {

            if(clsContact.isContactExisit(ID))
            {
                Console.WriteLine("Yes, Contact is there.");
            }
            else
            {
                Console.WriteLine("No, Contact Is not there.");
            }
        }

        static void Main(string[] args)
        {

            DeleteContact(19);
        }
    }
}