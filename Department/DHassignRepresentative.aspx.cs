using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DHassignRepresentative : System.Web.UI.Page
{
    int headcode;
    static Employee e1;
    DHserviceManager d = new DHserviceManager();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            IIdentity id = User.Identity;
            headcode = Convert.ToInt32(id.Name);
            e1 = d.getDepartmentRepresentative(headcode);
            if (!IsPostBack)
            {

                List<Employee> elist = d.PopulateEmpList(headcode);
                DropDownList1.DataSource = elist;
                DropDownList1.DataTextField = "employeename";
                DropDownList1.DataValueField = "employeecode";
                DropDownList1.DataBind();

                Label1.Text = e1.employeename;
            }
        }
        catch (Exception)
        {
            Response.Redirect("~/Error.aspx");
        }

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            Label1.Text = DropDownList1.SelectedItem.Text;
            int selectedVal = Convert.ToInt32(DropDownList1.SelectedValue);
            d.setRepresentative(selectedVal);
            d.changePreviousRepresentative(e1.employeecode);
            List<Employee> elist = d.PopulateEmpList(headcode);
            DropDownList1.DataSource = elist;
        }
        catch (Exception)
        {
            Response.Redirect("~/Error.aspx");
        }
    }
}