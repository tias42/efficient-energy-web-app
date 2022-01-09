using EfficientEnergyWebApp.BLL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EfficientEnergyWebApp.DAL
{
    public class DataAccess
    {
        private string connString;
        public DataAccess()
        {
            connString = ConfigurationManager.ConnectionStrings["EfficientEnergyDBConnectionString"].ConnectionString;
        }
        public List<Employee> GetEmployees()
        {
            List<Employee> resultList = new List<Employee>();
            DateTime? nullDate = null;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string strSql = "SELECT employee_Id, first_name, last_name, dob, phone, employment_type, salary, email, address_Id, department_Id " +
                        "FROM employees";
                    SqlCommand cmd = new SqlCommand(strSql, conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader != null)
                    {
                        while (reader.Read())
                        {
                            Employee emp = new Employee();
                            emp.EmpID = Convert.ToInt32(reader["employee_Id"]);
                            emp.FirstName = (string)reader["first_name"];
                            emp.LastName = (string)reader["last_name"];
                            emp.DateOfBirth = Convert.ToDateTime(reader["dob"]);
                            emp.Phone = (string)reader["phone"];
                            emp.EmploymentType = (string)reader["employment_type"];
                            emp.Salary = Convert.ToDouble(reader["salary"]);
                            emp.Email = !String.IsNullOrEmpty(reader["email"].ToString()) ? reader["email"].ToString() : "";
                            emp.Address = null;
                            emp.Department = null;
                            resultList.Add(emp);
                        }
                    }


                }
                catch (Exception ex)
                {
                    Logger.Logger.LogErrorToFile("GetEmployees", "DataAccess", ex);
                }
            }
            return resultList;
        }

        public void DeleteEmployee(int empID)
        {
            //delete user account if any
            DeleteUser(empID);
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    string strSql = "DELETE FROM employees WHERE employee_Id = @empID";
                    SqlCommand cmd = new SqlCommand(strSql, conn);

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@empID", empID);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.LogErrorToFile("DeleteEmployee", "DataAccess", ex);
            }
        }

        public void UpdateEmployee(int empID, string firstName, string lastName, DateTime? dateOfBirth, string phone, string email, string employmentType, double salary)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    string strSql = "UPDATE employees SET " +
                        "first_name = @firstName, " +
                        "last_name = @lastName, " +
                        "dob = @dateOfBirth, " +
                        "phone = @phone, " +
                        "email = @email, " +
                        "employment_type = @employmentType, " +
                        "salary = @salary " +
                        "WHERE employee_Id = @empID;";
                    SqlCommand cmd = new SqlCommand(strSql, conn);

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@firstName", firstName);
                    cmd.Parameters.AddWithValue("@lastName", lastName);
                    cmd.Parameters.AddWithValue("@dateOfBirth", dateOfBirth);
                    cmd.Parameters.AddWithValue("@phone", phone);
                    cmd.Parameters.AddWithValue("@email", !String.IsNullOrEmpty(email) ? email.Trim() : "");
                    cmd.Parameters.AddWithValue("@employmentType", employmentType);
                    cmd.Parameters.AddWithValue("@salary", salary);
                    cmd.Parameters.AddWithValue("@empID", empID);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.LogErrorToFile("UpdateEmployee", "DataAccess", ex);
            }
        }

        public void AddEmployee(string firstName, string lastName, DateTime dateOfBirth, string phone, string email, string employmentType, double salary, string image, string comments)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    string strSql = "INSERT INTO employees (first_name, last_name, dob, phone, email, employment_type, salary, comments) " +
                        "VALUES (@firstName, @lastName, @dateOfBirth, @phone, @email, @employmentType, @salary, @comments);";
                    SqlCommand cmd = new SqlCommand(strSql, conn);
                    cmd.Parameters.Clear();

                    cmd.Parameters.AddWithValue("@firstName", firstName);
                    cmd.Parameters.AddWithValue("@lastName", lastName);
                    cmd.Parameters.AddWithValue("@dateOfBirth", dateOfBirth);
                    cmd.Parameters.AddWithValue("@phone", phone);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@employmentType", employmentType);
                    cmd.Parameters.AddWithValue("@salary", salary);
                    // cmd.Parameters.AddWithValue("@image", image);
                    cmd.Parameters.AddWithValue("@comments", "");

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.LogErrorToFile("AddEmployee", "DataAccess", ex);
            }
        }
        //return list of unregistered employees
        public DataTable GetEmployeeList()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    string strSql = "SELECT employee_Id, CONCAT(employee_Id, ' - ', first_name, ' ', last_name) AS 'full_name' from employees " + 
                        "WHERE employee_Id NOT IN (SELECT userID FROM [User])";
                    SqlDataAdapter adapter = new SqlDataAdapter(strSql, conn);
                    adapter.Fill(dt);
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.LogErrorToFile("GetEmployeeList", "DataAccess", ex);
            }
            return dt;

        }

        public DataTable GetCountries()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    string sql = "SELECT * FROM countries";
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                    adapter.Fill(dt);
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.LogErrorToFile("GetCountries", "DataAccess", ex);
            }

            return dt;
        }

        public List<User> GetUsers()
        {
            List<User> usersList = new List<User>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    string strSql = "SELECT userID, username FROM [User]";
                    SqlCommand cmd = new SqlCommand(strSql, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        User nextUser = new User();
                        nextUser.userID = Convert.ToInt32(reader["userID"]);
                        nextUser.username = reader["username"].ToString();
                        usersList.Add(nextUser);
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.LogErrorToFile("GetUsers", "DataAccess", ex);
            }

            return usersList;
        }

        public void AddUser(int userID, string username, string password)
        {

            try
            {
                string encryptedPassword = Encryption.Encryption.Encrypt(password);
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    string strSql = "INSERT INTO [User] (userID, username, password) VALUES (@userID, @username, @password)";
                    SqlCommand cmd = new SqlCommand(strSql, conn);

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@userID", userID);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", encryptedPassword);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.LogErrorToFile("AddUser", "DataAccess", ex);
            }
        }

        public void DeleteUser(int userID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    string strSql = "DELETE FROM [User] WHERE userID = @userID";
                    SqlCommand cmd = new SqlCommand(strSql, conn);

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@userID", userID);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.LogErrorToFile("DeleteUser", "DataAccess", ex);
            }
        }

        public bool ValidateLogin(string username, string password)
        {
            bool valid = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    string strSql = "SELECT username, password FROM [User] WHERE username = @username";
                    SqlCommand cmd = new SqlCommand(strSql, conn);

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@username", username);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        valid = password == Encryption.Encryption.Decrypt(reader["password"].ToString());
                    }

                    cmd.Dispose();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.LogErrorToFile("DeleteUser", "DataAccess", ex);
            }

            return valid;
        }

        public bool IsUniqueUsername(string username)
        {
            bool unique = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    string strSql = "SELECT * FROM [User] where username = @username";
                    SqlCommand cmd = new SqlCommand(strSql, conn);

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@username", username);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (!reader.Read())
                    {
                        unique = true;
                    }

                    reader.Close();
                    cmd.Dispose();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.LogErrorToFile("DeleteUser", "DataAccess", ex);
            }

            return unique;
        }

        public void AddAddress(int employeeID, string line1, string line2, string suburb, string state, string country, string postcode)
        {
            try 
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    //insert new address record
                    string strSql = "INSERT INTO address (addr_line1, addr_line2, suburb_city, state, country, postcode) " +
                        "VALUES (@line1, @line2, @suburb, @state, @country, @postcode) SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(strSql, conn);

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@line1", line1);
                    cmd.Parameters.AddWithValue("@line2", !String.IsNullOrEmpty(line2)?line2:"");
                    cmd.Parameters.AddWithValue("@suburb", suburb);
                    cmd.Parameters.AddWithValue("@state", state);
                    cmd.Parameters.AddWithValue("@country", country);
                    cmd.Parameters.AddWithValue("@postcode", postcode);
                    int addressID = Convert.ToInt32(cmd.ExecuteScalar()); //save the new address ID
                    cmd.Dispose();
                    System.Diagnostics.Debug.WriteLine("address ID " + addressID);
                    System.Diagnostics.Debug.WriteLine("employee ID " +  employeeID);
                    System.Diagnostics.Debug.WriteLine("Seven " + 7);

                    //get employee record and update address ID
                    strSql = "UPDATE employees SET address_Id = @addressID WHERE employee_Id = @employeeID";
                    cmd = new SqlCommand(strSql, conn);

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@addressID", addressID);
                    cmd.Parameters.AddWithValue("@employeeID", employeeID);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.LogErrorToFile("AddAddress", "DataAccess", ex);
            }
        }
        public DataTable GetAddressList()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    string strSql = "SELECT CONCAT(employee_Id, ' - ', first_name, ' ', last_name) AS 'Employee', " +
                        "addr_line1 AS 'Address Line 1', addr_line2 AS 'Address Line 2', suburb_city AS 'Suburb/City', state AS 'State', country AS 'Country', postcode AS 'Postcode' " +
                        "FROM address INNER JOIN employees ON employees.address_Id = address.address_Id";
                    SqlDataAdapter adapter = new SqlDataAdapter(strSql, conn);
                    adapter.Fill(dt);
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.LogErrorToFile("GetAddressList", "DataAccess", ex);
            }
            return dt;
        }

        public void UpdateAddress(int addressID, string line1, string line2, string suburb, string state, string country, string postcode)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    string strSql = "UPDATE TABLE address SET addr_line1 = @line1, " +
                                                            "addr_line2 = @line2, " +
                                                            "suburb_city = @suburb, " +
                                                            "state = @state, " +
                                                            "country = @country, " +
                                                            "postcode = @postcode " +
                                                            "WHERE address_Id = @addressID";
                    SqlCommand cmd = new SqlCommand(strSql, conn);
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@line1", line1);
                    cmd.Parameters.AddWithValue("@line2", !String.IsNullOrEmpty(line2)?line2:null);
                    cmd.Parameters.AddWithValue("@suburb", suburb);
                    cmd.Parameters.AddWithValue("@state", state);
                    cmd.Parameters.AddWithValue("@country", country);
                    cmd.Parameters.AddWithValue("@postcode", postcode);
                    cmd.Parameters.AddWithValue("@addressID", addressID);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.LogErrorToFile("UpdateAddress", "DataAccess", ex);
            }
        }
        //not working
        public bool EmployeeHasAddress(int employeeID)
        {
            bool hasAddress = false;

            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    string strSql = "SELECT address_Id from employees WHERE employee_Id = @employeeID";
                    SqlCommand cmd = new SqlCommand(strSql, conn);

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@employeeID", employeeID);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read() && reader["address_Id"] != null)
                    {
                        hasAddress = true;
                    }
                   conn.Close();
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.LogErrorToFile("EmployeeHasAddress", "DataAccess", ex);
            }
            return hasAddress;
        }
    }

}