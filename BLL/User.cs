using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EfficientEnergyWebApp.BLL
{
    public class User
    {
        public int userID { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public DAL.DataAccess da;

        public User()
        {
            da = new DAL.DataAccess();
        }

        public List<User> GetUsers()
        {
            return da.GetUsers();
        }

        public void AddUser(int userID, string username, string password)
        {
            da.AddUser(userID, username, password);
        }

        public void DeleteUser(int userID)
        {
            da.DeleteUser(userID);
        }

        public bool ValidateLogin(string username, string password)
        {
            return da.ValidateLogin(username, password);
        }
        public bool IsUniqueUsername(string username)
        {
            return da.IsUniqueUsername(username);
        }
    }
}