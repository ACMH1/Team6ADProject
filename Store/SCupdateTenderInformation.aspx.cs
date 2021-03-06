﻿using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//AUTHOR- BAO ZHIQIANG
public partial class SCupdateTenderInformation : System.Web.UI.Page
{
    //Service
    SCserviceManager scService = new SCserviceManager();
 
    //Populate data into dropdownlist
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                bindGridView();
            }
        }
        catch (Exception)
        {
            Response.Redirect("~/Error.aspx");
        }
    }
    private void bindGridView()
    {
        try
        {
            List<string> slist = scService.getSuppliername();
            DropDownList1.DataSource = slist;
            DropDownList1.DataBind();
            
            string suppliername = DropDownList1.SelectedValue;

            Supplier s = scService.getSupplierByName(suppliername);
            Label.Text = s.address;
            string suppliercode = s.suppliercode;

           
            List<dynamic> list = scService.getTenderQuotation(suppliercode).ToList();

            GridView1.DataSource = list;
            GridView1.DataBind();
        }
        catch (Exception)
        {
            Response.Redirect("~/Error.aspx");
        }
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GridView1.PageIndex = e.NewPageIndex;
            bindGridView();
        }
        catch (Exception)
        {
            Response.Redirect("~/Error.aspx");
        }
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            string suppliername = DropDownList1.SelectedValue;

            Supplier s = scService.getSupplierByName(suppliername);
            Label.Text = s.address;
            string suppliercode = s.suppliercode;


            List<dynamic> list = scService.getTenderQuotation(suppliercode).ToList();

            GridView1.DataSource = list;
            GridView1.DataBind();
        }
        catch (Exception)
        {
            Response.Redirect("~/Error.aspx");
        }

    }

    //Select row in GridView
    protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink(this.GridView1,
                    "Select$" + e.Row.RowIndex);

                e.Row.Attributes.Add("onmouseover",
                    "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FDCB0A';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
            }
        }
        catch (Exception)
        {
            Response.Redirect("~/Error.aspx");
        }
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            int index = Convert.ToInt32(e.CommandArgument);
            bindGridView();
            GridView1.Rows[index].Attributes.Add("style", "background-color:#FDCB0A");
            
        }
        catch (Exception)
        {
            Response.Redirect("~/Error.aspx");
        }
    }

   

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            Item i = scService.getItemByItemdescription(GridView1.SelectedRow.Cells[0].Text.Replace("&quot;", "\""));
            TextBox1.Text = GridView1.SelectedRow.Cells[0].Text.Replace("&quot;", "\"");
            TextBox2.Text = GridView1.SelectedRow.Cells[1].Text;
            TextBox3.Text = i.itemcode;
        }
        catch (Exception)
        {
            Response.Redirect("~/Error.aspx");
        }
  
    }

    protected void Save_Click(object sender, EventArgs e)
    {
        try
        {
            GridViewRow row = GridView1.SelectedRow;
            string itemdescription = row.Cells[0].Text;
            Item i = scService.getItemByItemdescription(itemdescription);
            

            string suppliername = DropDownList1.SelectedValue;
            Supplier s = scService.getSupplierByName(suppliername);

            TenderQuotation tq = new TenderQuotation();
            tq.suppliercode = s.suppliercode;
            tq.itemcode = i.itemcode;
            tq.price = Convert.ToDouble(TextBox2.Text);
           

            scService.updateTenderQuotation(tq);
            Response.Redirect("SCupdateTenderInformation.aspx");
        }
        catch (Exception)
        {
            Response.Redirect("~/Error.aspx");
        }
    }
}