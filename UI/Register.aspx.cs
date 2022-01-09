using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EfficientEnergyWebApp.UI
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                IDC_drpEmployee.DataSource = new DAL.DataAccess().GetEmployeeList();
                IDC_drpEmployee.DataTextField = "full_name";
                IDC_drpEmployee.DataValueField = "employee_Id";
                IDC_drpEmployee.DataBind();
            }
            
        }

        protected void IDC_btnRegister_Click(object sender, EventArgs e)
        {
            BLL.User u = new BLL.User();

            if (u.IsUniqueUsername(IDC_txtUsername.Text.Trim()))
            {
                u.AddUser(Convert.ToInt32(IDC_drpEmployee.SelectedValue), IDC_txtUsername.Text.Trim(), IDC_txtPassword.Text);
                Response.Redirect("~/UI/Login.aspx");
            }
            else
            {
                IDC_lblFeedback.Text = "Username is already taken";
                IDC_txtUsername.Text = "";
            }
        }
    }
}