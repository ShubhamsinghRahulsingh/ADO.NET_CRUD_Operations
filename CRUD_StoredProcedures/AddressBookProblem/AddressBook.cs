using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CRUD_StoredProcedures.AddressBookProblem
{
    public class AddressBook
    {
        public static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AddressBook;Integrated Security=true;";
        public void AddNewContactInDatabase(Contact contact)
        {
            SqlConnection sqlconnection = new SqlConnection(connectionString);
            try
            {
                using (sqlconnection)
                {
                    sqlconnection.Open();
                    SqlCommand command = new SqlCommand("SPAddingNewData", sqlconnection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@FirstName", contact.FirstName);
                    command.Parameters.AddWithValue("@LastName", contact.LastName);
                    command.Parameters.AddWithValue("@Address", contact.Address);
                    command.Parameters.AddWithValue("@City", contact.City);
                    command.Parameters.AddWithValue("@State", contact.State);
                    command.Parameters.AddWithValue("@ZIP", contact.Zip);
                    command.Parameters.AddWithValue("@PhoneNumber", contact.PhoneNUmber);
                    command.Parameters.AddWithValue("@Email", contact.Email);
                    int result = command.ExecuteNonQuery();
                    sqlconnection.Close();
                    if (result >= 1)
                    {
                        Console.WriteLine("New Contact Added Successfully");
                    }
                    else
                        Console.WriteLine("No DataBase found");
                }
            }
            catch (Exception ex)
            {
                // handle exception here
                Console.WriteLine(ex.Message);
            }
        }
        public void RetrieveEntriesFromAddressBookDB()
        {
            SqlConnection sqlconnection = new SqlConnection(connectionString);
            try
            {
                List<Contact> contact = new List<Contact>();
                using (sqlconnection)
                {
                    sqlconnection.Open();
                    SqlCommand command = new SqlCommand("SPRetrieveAllDetails", sqlconnection);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader dr = command.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            Contact contactNew = new Contact();
                            contactNew.FirstName = dr.GetString(0);
                            contactNew.LastName = dr.GetString(1);
                            contactNew.Address = dr.GetString(2);
                            contactNew.City = dr.GetString(3);
                            contactNew.State = dr.GetString(4);
                            contactNew.Zip = dr.GetInt32(5);
                            contactNew.PhoneNUmber = dr.GetInt64(6);
                            contactNew.Email = dr.GetString(7);
                            contact.Add(contactNew);
                        }
                        foreach (var data in contact)
                        {
                            Console.WriteLine("Firstame:" + data.FirstName + "  " + "LastName:" + data.LastName + "  " + "Address:" + data.Address + "  " + "City:" + data.City + "  " + "State:" + data.State + "  " + "ZIP:" + data.Zip + "  " + "PhoneNo:" + data.PhoneNUmber + "  " + "Email:" + data.Email);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Database Found");
                    }
                }
            }
            catch (Exception ex)
            {
                // handle exception here
                Console.WriteLine(ex.Message);
            }
        }
        public void UpdateDataInDatabase(Contact contact)
        {
            SqlConnection sqlconnection = new SqlConnection(connectionString);
            try
            {
                using (sqlconnection)
                {
                    sqlconnection.Open();
                    SqlCommand command = new SqlCommand("SPUpdateDataInDB", sqlconnection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@FirstName", contact.FirstName);
                    command.Parameters.AddWithValue("@City", contact.City);
                    command.Parameters.AddWithValue("@State", contact.State);
                    int result = command.ExecuteNonQuery();
                    sqlconnection.Close();
                    if (result >= 1)
                    {
                        Console.WriteLine("Contact Updated Successfully");
                    }
                    else
                        Console.WriteLine("No DataBase found");
                }
            }
            catch (Exception ex)
            {
                // handle exception here
                Console.WriteLine(ex.Message);
            }
        }
        public void DeleteDataFromDatabase(string name)
        {
            SqlConnection sqlconnection = new SqlConnection(connectionString);
            try
            {
                using (sqlconnection)
                {
                    sqlconnection.Open();
                    SqlCommand command = new SqlCommand("SPDeleteDataFromDB", sqlconnection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@FirstName", name);
                    int result = command.ExecuteNonQuery();
                    sqlconnection.Close();
                    if (result >= 1)
                    {
                        Console.WriteLine("Data Deleted Successfully");
                    }
                    else
                        Console.WriteLine("No Data found");
                }
            }
            catch (Exception ex)
            {
                // handle exception here
                Console.WriteLine(ex.Message);
            }
        }
    }
}
