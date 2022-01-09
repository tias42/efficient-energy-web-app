using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace EfficientEnergyWebApp.BLL
{
    public class Address
    {
        public int id { get; set; }
        public string line1 { get; set; }
        public string line2 { get; set; }
        public string suburb { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public string postcode { get; set; }
        public DAL.DataAccess da { get; set; }
        public Address() 
        {
            da = new DAL.DataAccess();
        }

        public void AddAddress(int employeeID, string line1, string line2, string suburb, string state, string country, string postcode)
        {
            da.AddAddress(employeeID, line1, line2, suburb, state, country, postcode);
        }
        public DataTable GetAddressList()
        {
            return da.GetAddressList();
        }
        public void UpdateAddress(int addressID, string line1, string line2, string suburb, string state, string country, string postcode)
        {
            da.UpdateAddress(addressID, line1, line2, suburb, state, country, postcode);
        }
        public bool EmployeeHasAddress(int employeeID)
        {
            return da.EmployeeHasAddress(employeeID);
        }
    }
}