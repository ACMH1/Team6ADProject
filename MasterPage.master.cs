﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                int userNo = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
                string role = Roles.GetRolesForUser(userNo.ToString())[0];

                if (role.Equals("storeclerk"))
                {
                    Menu1.Visible = true;
                    Menu2.Visible = false;
                    Menu3.Visible = false;
                    Menu4.Visible = false;
                    Menu5.Visible = false;
                    Menu6.Visible = false;
                    Menu7.Visible = false;
                }
                else if (role.Equals("storesupervisor"))
                {
                    Menu1.Visible = false;
                    Menu2.Visible = true;
                    Menu3.Visible = false;
                    Menu4.Visible = false;
                    Menu5.Visible = false;
                    Menu6.Visible = false;
                    Menu7.Visible = false;
                }
                else if (role.Equals("storemanager"))
                {
                    Menu1.Visible = false;
                    Menu2.Visible = false;
                    Menu3.Visible = true;
                    Menu4.Visible = false;
                    Menu5.Visible = false;
                    Menu6.Visible = false;
                    Menu7.Visible = false;
                }
                else if (role.Equals("departmentemployee"))
                {
                    Menu1.Visible = false;
                    Menu2.Visible = false;
                    Menu3.Visible = false;
                    Menu4.Visible = true;
                    Menu5.Visible = false;
                    Menu6.Visible = false;
                    Menu7.Visible = false;
                }
                else if (role.Equals("departmentrepresentative"))
                {
                    Menu1.Visible = false;
                    Menu2.Visible = false;
                    Menu3.Visible = false;
                    Menu4.Visible = false;
                    Menu5.Visible = true;
                    Menu6.Visible = false;
                    Menu7.Visible = false;
                }
                else if (role.Equals("departmenthead"))
                {
                    Menu1.Visible = false;
                    Menu2.Visible = false;
                    Menu3.Visible = false;
                    Menu4.Visible = false;
                    Menu5.Visible = false;
                    Menu6.Visible = true;
                    Menu7.Visible = false;
                }
                else if (role.Equals("delegatedemployee"))
                {
                    Menu1.Visible = false;
                    Menu2.Visible = false;
                    Menu3.Visible = false;
                    Menu4.Visible = false;
                    Menu5.Visible = false;
                    Menu6.Visible = false;
                    Menu7.Visible = true;
                }
                else
                {
                    Menu1.Visible = false;
                    Menu2.Visible = false;
                    Menu3.Visible = false;
                    Menu4.Visible = false;
                    Menu5.Visible = false;
                    Menu6.Visible = false;
                    Menu7.Visible = false;
                }
            }
            else
            {
                FormsAuthentication.RedirectToLoginPage();
            }
        }
        catch (Exception)
        {
            Response.Redirect("~/Error.aspx");
        }
    }
}
