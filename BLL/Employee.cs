using EfficientEnergyWebApp.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EfficientEnergyWebApp.BLL
{
    //business object for Employee database table
    public class Employee
    {
        public int EmpID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string EmploymentType { get; set; }
        public double Salary { get; set; }
        public string comments { get; set; }
        public string image { get; set; }
        public Address Address { get; set; }
        public Department Department { get; set; }
        public DataAccess da { get; set; }

        public Employee() 
        {
            da = new DataAccess();
        }
        public List<Employee> GetEmployees()
        {
            return da.GetEmployees();
        }
        public void UpdateEmployee(int empID, string firstName, string lastName, DateTime? dateOfBirth, string phone, string email, string employmentType, double salary)
        {
            da.UpdateEmployee(empID, firstName, lastName,dateOfBirth, phone, email, employmentType, salary);
        }
        public void DeleteEmployee(int empID)
        {
            da.DeleteEmployee(empID);
        }
        public void AddEmployee(string firstName, string lastName, DateTime dateOfBirth, string phone, string email, string employmentType, double salary, string image, string comments)
        {
            da.AddEmployee(firstName, lastName, dateOfBirth, phone, email, employmentType, salary, image, comments);
        }
    }
}