using CRUD_StoredProcedures.AddressBookProblem;
using System;
namespace CRUD_StoredProcedures
{
    class Program
    {
        public static void Main(string[] args)
        {
            Contact contact = new Contact()
            {
                FirstName = "Deepika",
                LastName = "Sharma",
                Address = "Poorana Bazar",
                City = "Ambala",
                State = "Haryana",
                Zip = 345445,
                PhoneNUmber=8734543452,
                Email = "deepika@gmail.com"
            };
            AddressBook addressBook = new AddressBook();
            Console.WriteLine("Welcome to the CRUD Operations Using Stored Procedures");
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("------------------------------------------------------");
                Console.WriteLine("Select Any Operations From the Following\n1.Add_New_Data_in_AddressBook_Databse\n2.Exit");
                int sel = Convert.ToInt32(Console.ReadLine());
                switch (sel)
                {
                    case 1:
                        addressBook.AddNewContactInDatabase(contact);
                        break;
                    case 2:
                        flag = false;
                        break;                 
                }
            }
        }
    }
}
