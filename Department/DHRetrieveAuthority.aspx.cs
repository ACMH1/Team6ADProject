﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RetriveAuthority : System.Web.UI.Page
{
    static int headcode;
    DHserviceManager d = new DHserviceManager();
    protected void Page_Load(object sender, EventArgs e)
    {
        //try
        //{
            IIdentity id = User.Identity;
            headcode = Convert.ToInt32(id.Name);
        //}
        //catch (Exception)
        //{
        //    Response.Redirect("~/Error.aspx");
        //}
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        //try
        //{
            d.retrieveAuthority(headcode);
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        //}
        //catch (Exception)
        //{
        //    Response.Redirect("~/Error.aspx");
        //}
    }
}