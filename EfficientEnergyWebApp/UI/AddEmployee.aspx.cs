using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace EfficientEnergyWebApp.UI
{
    public partial class AddEmployee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("~/UI/Login.aspx");
            }
            IDC_lblTest.Text = "";
        }

        protected void IDC_btnSave_Click(object sender, EventArgs e)
        {
            string message = "";

            message += "data: ";

            message += IDC_txtFirstName.Text + " ";
            message += IDC_txtLastName.Text + " ";
            message += IDC_txtDateOfBirth.Text + " ";
            message += IDC_drpEmploymentType.SelectedValue + " ";
            message += IDC_txtEmail.Text;
            message += IDC_txtMobile.Text;
           
            

            new BLL.Employee().AddEmployee(IDC_txtFirstName.Text.Trim(),
                                           IDC_txtLastName.Text.Trim(), 
                                           Convert.ToDateTime(IDC_txtDateOfBirth.Text), 
                                           IDC_txtMobile.Text.Trim(), 
                                           IDC_txtEmail.Text.Trim(),
                                           IDC_drpEmploymentType.SelectedValue, 
                                           0, null, 
                                           null); // needs arguments
            IDC_lblTest.Text = "Employee added";
            //Response.Redirect("~/UI/Employee.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {

        }
    }
}