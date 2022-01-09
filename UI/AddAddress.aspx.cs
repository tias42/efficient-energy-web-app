using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EfficientEnergyWebApp.UI
{
    public partial class AddAddress : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("~/UI/Login.aspx");
            }
            if (!IsPostBack)
            {
                //bind employee name list to dropdown
                IDC_drpEmployeeName.DataSource = new DAL.DataAccess().GetEmployeeList();
                IDC_drpEmployeeName.DataTextField = "full_name";
                IDC_drpEmployeeName.DataValueField = "employee_Id";
                IDC_drpEmployeeName.DataBind();
                //bind countries list to dropdown
                IDC_drpCountry.DataSource = new DAL.DataAccess().GetCountries();
                IDC_drpCountry.DataTextField = "name";
                IDC_drpCountry.DataValueField = "code";
                IDC_drpCountry.DataBind();
            }
        }

        protected void IDC_btnAdd_Click(object sender, EventArgs e)
        {
            BLL.Address addr = new BLL.Address();
            //if (employee does not have address) - create DAL function to check this
            if (addr.EmployeeHasAddress(Convert.ToInt32(IDC_drpEmployeeName.SelectedValue)))
            {
                addr.AddAddress(Convert.ToInt32(IDC_drpEmployeeName.SelectedValue),
                                             IDC_txtAddress1.Text,
                                             IDC_txtAddress2.Text,
                                             IDC_txtSuburb.Text,
                                             IDC_txtState.Text,
                                             IDC_drpCountry.SelectedValue,
                                             IDC_txtPostCode.Text);
                IDC_lblFeedback.Text = "Address added successfully";
            }

            else
                IDC_lblFeedback.Text = "Employee already has address set";
            //else
            // set feedback "employee already has address"- please update
        }
    }
}