using CRUD_StoredProcedures.AddressBookProblem;
using CRUD_StoredProcedures.EmployeePayrollProblem;
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
            EmployeeCRUD_Operations emp = new EmployeeCRUD_Operations();
            Console.WriteLine("Welcome to the CRUD Operations Using Stored Procedures");
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("------------------------------------------------------");
                Console.WriteLine("Select AnyOne\n1.AddressBook\n2.EmployeePayroll\n3.Exit");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        bool condition = true;
                        while(condition)
                        {
                           Console.WriteLine("--------------------------------------------------");
                           Console.WriteLine("Select Any Operations From the Following\n1.Add_New_Data_in_AddressBook_Databse\n2.Retrieve_Entries_From_AddressBookDB\n3.Update_Data_In_Database\n4.Delete_Data_From_Database\n5.Exit");
                           int sel = Convert.ToInt32(Console.ReadLine());
                            switch (sel)
                            {
                                case 1:
                                    addressBook.AddNewContactInDatabase(contact);
                                    break;
                                case 2:
                                    addressBook.RetrieveEntriesFromAddressBookDB();
                                    break;
                                case 3:
                                    Contact update = new Contact
                                    {
                                        FirstName = "Shubham",
                                        City = "Dehradun",
                                        State = "UK"
                                    };
                                    addressBook.UpdateDataInDatabase(update);
                                    break;
                                case 4:
                                    addressBook.DeleteDataFromDatabase("Yogesh");
                                    break;
                                case 5:
                                    condition = false;
                                    break;
                            }
                        }
                        break;
                    case 2:
                        bool cond = true;
                        while(cond)
                        {
                            Console.WriteLine("---------------------------------------------");
                            Console.WriteLine("Select Any Operations From the Following\n1.Add_New_Data_in_EmployeePay_Database\n2.Retrieve_Entries_From_EmployeeDB\n3.Update_Data_In_Database\n4.Delete_Data_From_Database\n5.Exit");
                            int select = Convert.ToInt32(Console.ReadLine());
                            switch (select)
                            {
                                case 1:
                                    Employee employee = new Employee()
                                    {
                                        EmployeeId = 1,
                                        EmployeeName = "Shubham",
                                        Gender = "M",
                                        PhoneNo = 7564567456,
                                        EmployeeAddress = "Rampuri Colony",
                                        CompanyName = "Crimpson",
                                        StartDate = DateTime.Now
                                    };
                                    emp.AddEmployeeInDB(employee);
                                    break;
                                case 2:
                                    emp.RetrieveEntriesFromEmployeePayDB();
                                    break;
                                case 3:
                                    Employee update = new Employee
                                    {
                                        EmployeeName = "Abhishek",
                                        CompanyName = "HCL",
                                        PhoneNo = 8744775646,
                                    };
                                    emp.UpdateDataInDatabase(update);
                                    break;
                                case 4:
                                    emp.DeleteDataFromDatabase("Shiva");
                                    break;
                                case 5:
                                    cond = false;
                                    break;
                            }                       
                        }
                        break;
                    case 3:
                        flag= false;
                        break;
                }
            }
        }
    }
}
