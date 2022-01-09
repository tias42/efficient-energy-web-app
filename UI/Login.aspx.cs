using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EfficientEnergyWebApp.UI
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void IDC_btnSubmit_Click(object sender, EventArgs e)
        {
            BLL.User u = new BLL.User();

            if (u.ValidateLogin(IDC_txtUsername.Text.Trim(), IDC_txtPassword.Text))
            {
                Session["username"] = IDC_txtUsername.Text.Trim();
                Response.Redirect("~/UI/Employee.aspx");
            }
            else
            {
                Session["username"] = null;
                IDC_lblFeedback.Text = "Incorrect login details";
            }
        }
    }
}