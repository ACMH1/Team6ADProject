using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Security.Principal;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DErequestItem : System.Web.UI.Page
{
    DEserviceManager eM = new DEserviceManager();
    string category;
    string idstring = " ";
    int ecode;
    List<string> idesc;
    List<string> icode;
    List<string> iqty;
    List<string> iunit;
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            IIdentity id = User.Identity;
            ecode = Convert.ToInt32(id.Name);

            if (!IsPostBack)
            {

                idstring = Request.QueryString["id"];
                loadDropDownList7();


            }
            loadPlaceholders();
        }
        catch (Exception)
        {
            Response.Redirect("~/Error.aspx");
        }


    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

        loadDropDownList7();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {

        try
        {
            if (Session["idesc"] != null && Session["icode"] != null && Session["iqty"] != null && Session["iunit"] != null)
            {
                idesc = (List<string>)Session["idesc"];
                icode = (List<string>)Session["icode"];
                iqty = (List<string>)Session["iqty"];
                iunit = (List<string>)Session["iunit"];
            }
            else
            {
                idesc = new List<string>();
                icode = new List<string>();
                iqty = new List<string>();
                iunit = new List<string>();
            }
            bool alreadyAdded = icode.Contains(DropDownList7.SelectedItem.Value);

            if (!alreadyAdded)
            {
                idesc.Add(DropDownList7.SelectedItem.Text);
                icode.Add(DropDownList7.SelectedItem.Value);
                iqty.Add("0");

                //retrieve unit
                iunit.Add(eM.getUnit(DropDownList7.SelectedItem.Value));

                Session["idesc"] = idesc;
                Session["icode"] = icode;
                Session["iqty"] = iqty;
            }
            Response.Redirect(Request.RawUrl);
        }
        catch (Exception)
        {
            Response.Redirect("~/Error.aspx");
        }
    }
    protected void rmbtn_Click(object sender, EventArgs e)
    {
        try
        {
            Button rmbtn = (Button)sender;
            idesc = (List<string>)Session["idesc"];
            icode = (List<string>)Session["icode"];
            iqty = (List<string>)Session["iqty"];
            iunit = (List<string>)Session["iunit"];
            string[] ID = rmbtn.ID.Split('r');
            iqty.RemoveAt(Convert.ToInt32(ID[1]));
            icode.RemoveAt(Convert.ToInt32(ID[1]));
            idesc.RemoveAt(Convert.ToInt32(ID[1]));
            iunit.RemoveAt(Convert.ToInt32(ID[1]));

            Session["idesc"] = idesc;
            Session["icode"] = icode;
            Session["iqty"] = iqty;
            Session["iunit"] = iunit;
            System.Diagnostics.Debug.WriteLine(rmbtn.ID + " removed " + ID[1]);
            Response.Redirect(Request.RawUrl);
        }
        catch (Exception)
        {
            Response.Redirect("~/Error.aspx");
        }

    }
    protected void qtybox_Changed(object sender, EventArgs e)
    {
        try
        {
            TextBox qtybox = (TextBox)sender;
            iqty = (List<string>)Session["iqty"];
            string[] ID = qtybox.ID.Split('q');
            iqty[Convert.ToInt32(ID[1])] = qtybox.Text;
            Session["iqty"] = iqty;

            System.Diagnostics.Debug.WriteLine(qtybox.ID + " VALUE IS" + qtybox.Text + "ID " + ID[1]);
        }
        catch (Exception)
        {

            Response.Redirect("~/Error.aspx");
        }
    }



    protected void SubmitBtn_Click(object sender, EventArgs e)
    {
        try
        {
            if (Page.IsValid)
            {
                icode = (List<string>)Session["icode"];
                iqty = (List<string>)Session["iqty"];
                eM.submitRequisitionItemList(iqty, icode, ecode);
                Session["idesc"] = null;
                Session["icode"] = null;
                Session["iqty"] = null;
                Session["iunit"] = null;
                Label1.Text = "Items submitted!";
                System.Diagnostics.Debug.WriteLine("Submitted");
                //to test email uncomment out line below

                DEserviceManager.sendEmail("Pending stationery request to be approved");
                Response.Redirect(Request.RawUrl);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(this.Page, "submit failed. try again");
            System.Diagnostics.Debug.WriteLine(ex);
        }
        //No need for else, the validations should display accordingly

    }

    protected void loadDropDownList7()
    {
        try
        {
            if (DropDownList1.Text.Equals("--select--"))
            {
                category = "Clip";
            }
            else
            {
                category = DropDownList1.Text;
            }
            List<Item> ilist = eM.PopulateCatDropDownList(category);
            DropDownList7.DataSource = ilist;
            DropDownList7.DataValueField = "itemcode";
            DropDownList7.DataTextField = "itemdescription";
            DropDownList7.DataBind();
        }
        catch (Exception)
        {
            Response.Redirect("~/Error.aspx");
        }
    }
    protected void loadPlaceholders()
    {
        try
        {
            if (Session["idesc"] != null && Session["icode"] != null && Session["iqty"] != null && Session["iunit"] != null)
            {
                idesc = (List<string>)Session["idesc"];
                icode = (List<string>)Session["icode"];
                iqty = (List<string>)Session["iqty"];
                iunit = (List<string>)Session["iunit"];
            }
            else
            {
                idesc = new List<string>();
                icode = new List<string>();
                iqty = new List<string>();
                iunit = new List<string>();
            }


            Session["idesc"] = idesc;
            Session["icode"] = icode;
            Session["iqty"] = iqty;
            Session["iunit"] = iunit;
            int ReqSize = idesc.Count;

            PlaceHolder1.Controls.Add(new LiteralControl("<b>Item</b>"));
            PlaceHolder2.Controls.Add(new LiteralControl("<b>Quantity</b>"));
            PlaceHolder4.Controls.Add(new LiteralControl("<b>Unit of Measure</b>"));
            PlaceHolder1.Controls.Add(new LiteralControl("<br/>"));
            PlaceHolder2.Controls.Add(new LiteralControl("<br/>"));
            PlaceHolder4.Controls.Add(new LiteralControl("<br/>"));

            for (int i = 0; i < ReqSize; i++)
            {
                Label lblitem = new Label();
                Label lblunit = new Label();
                TextBox qtybox = new TextBox();
                Button rmbtn = new Button();
                RangeValidator range = new RangeValidator();
                lblitem.Text = idesc.ElementAt(i);
                lblitem.ID = "lblitem" + i;

                lblunit.Text = iunit.ElementAt(i);
                lblunit.ID = "lblunit" + i;

                qtybox.ID = "q" + i;
                qtybox.Text = iqty.ElementAt(i);
                qtybox.TextChanged += new EventHandler(qtybox_Changed);

                rmbtn.Click += new EventHandler(rmbtn_Click);
                rmbtn.ID = "r" + i;
                rmbtn.Text = "Remove";

                PlaceHolder1.Controls.Add(lblitem);
                PlaceHolder2.Controls.Add(qtybox);
                PlaceHolder4.Controls.Add(lblunit);
                range.ID = "rangeqty" + i;
                range.ControlToValidate = qtybox.ID;
                range.MaximumValue = "999";
                range.MinimumValue = "1";
                range.Type = ValidationDataType.Integer;
                range.ForeColor = System.Drawing.Color.Red;
                range.ErrorMessage = "Invalid Quantity";
                range.EnableClientScript = false;

                PlaceHolder5.Controls.Add(range);
                PlaceHolder3.Controls.Add(rmbtn);

                PlaceHolder1.Controls.Add(new LiteralControl("<br/>"));
                PlaceHolder2.Controls.Add(new LiteralControl("<br/>"));
                PlaceHolder3.Controls.Add(new LiteralControl("<br/>"));
                PlaceHolder4.Controls.Add(new LiteralControl("<br/>"));
                PlaceHolder5.Controls.Add(new LiteralControl("<br/>"));
            }
        }
        catch (Exception)
        {
            Response.Redirect("~/Error.aspx");
        }

    }

}