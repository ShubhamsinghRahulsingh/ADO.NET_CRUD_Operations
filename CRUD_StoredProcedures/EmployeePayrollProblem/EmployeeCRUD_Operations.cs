using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUD_StoredProcedures.AddressBookProblem;

namespace CRUD_StoredProcedures.EmployeePayrollProblem
{
    public class EmployeeCRUD_Operations
    {
        public static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EMPLOYEE_PAY;Integrated Security=true;";
        public void AddEmployeeInDB(Employee employee)
        {
            SqlConnection sqlconnection = new SqlConnection(connectionString);
            try
            {
                using (sqlconnection)
                {
                    sqlconnection.Open();
                    SqlCommand command = new SqlCommand("SPAddNewEmployee", sqlconnection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmployeeId", employee.EmployeeId);
                    command.Parameters.AddWithValue("@EmployeeName", employee.EmployeeName);
                    command.Parameters.AddWithValue("@Gender", employee.Gender);
                    command.Parameters.AddWithValue("@PhoneNo", employee.PhoneNo);
                    command.Parameters.AddWithValue("@EmployeeAddress", employee.EmployeeAddress);
                    command.Parameters.AddWithValue("@CompanyName", employee.CompanyName);
                    command.Parameters.AddWithValue("@StartDate", employee.StartDate);
                    int result = command.ExecuteNonQuery();
                    sqlconnection.Close();
                    if (result >= 1)
                    {
                        Console.WriteLine("Employee Added Successfully");
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
        public void RetrieveEntriesFromEmployeePayDB()
        {
            SqlConnection sqlconnection = new SqlConnection(connectionString);
            try
            {
                List<Employee> employee = new List<Employee>();
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
                            Employee emp = new Employee();
                            emp.EmployeeId = dr.GetInt32(0);
                            emp.EmployeeName = dr.GetString(1);
                            emp.Gender = dr.GetString(2);
                            emp.PhoneNo = dr.GetInt64(3);
                            emp.EmployeeAddress = dr.GetString(4);
                            emp.CompanyName = dr.GetString(5);
                            emp.StartDate = dr.GetDateTime(6);
                            employee.Add(emp);
                        }
                        Console.WriteLine("EmployeeId"+ " "+"EmployeeName" + "  " + "Gender" + "  " + "PhoneNo" + "  " + "EmployeeAddress" + "  " + "CompanyName" + "  "  + "StartDate");
                        foreach (var data in employee)
                        {
                            Console.WriteLine(data.EmployeeId + "           " + data.EmployeeName + "          " + data.Gender + "     " + data.PhoneNo + "   " + data.EmployeeAddress + "      " + data.CompanyName +  "   " + data.StartDate);
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
        public void UpdateDataInDatabase(Employee employee)
        {
            SqlConnection sqlconnection = new SqlConnection(connectionString);
            try
            {
                using (sqlconnection)
                {
                    sqlconnection.Open();
                    SqlCommand command = new SqlCommand("SPUpdateDataInDB", sqlconnection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmployeeName", employee.EmployeeName);
                    command.Parameters.AddWithValue("@CompanyName", employee.CompanyName);
                    command.Parameters.AddWithValue("@PhoneNo", employee.PhoneNo);
                    int result = command.ExecuteNonQuery();
                    sqlconnection.Close();
                    if (result >= 1)
                    {
                        Console.WriteLine("Employee Updated Successfully");
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
                    command.Parameters.AddWithValue("@EmployeeName", name);
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
