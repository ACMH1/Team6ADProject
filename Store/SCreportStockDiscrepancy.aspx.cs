﻿using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SCreportStockDiscrepancy : System.Web.UI.Page
{
 
    //Service
    SCserviceManager scService = new SCserviceManager();

    static List<AdjustmentItem> alist = new List<AdjustmentItem>();
    static double cost = 0;
    static AdjustmentVoucher avoucher = new AdjustmentVoucher();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) { 
           
            List<string> slist = scService.getSuppliercode();
            DropDownList2.DataSource = slist;
            DropDownList2.DataBind();

            List<string> list = scService.getItemCodeBySupplierCode(DropDownList2.SelectedValue);
            DropDownList1.DataSource = list;
            DropDownList1.DataBind();

            Calendar1.SelectedDate = DateTime.Today;
        }

    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<string> list = scService.getItemCodeBySupplierCode(DropDownList2.SelectedValue);
        DropDownList1.DataSource = list;
        DropDownList1.DataBind();
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Item i = scService.getItem(DropDownList1.SelectedValue);
        TextBox1.Text = i.category;
        TextBox2.Text = i.itemdescription;
        TextBox3.Text = Convert.ToString(i.quantityonhand);
    }

    protected void DateSelectedChanged(object sender, EventArgs e)
    {
       
    }

    protected void Add_Click(object sender, EventArgs e)
    {
        AdjustmentItem ait = new AdjustmentItem();
            
        ait.itemcode = DropDownList1.SelectedValue;
        ait.quantity = Convert.ToInt32(TextBox4.Text);
        ait.reason = TextBox5.Text;
    
        alist.Add(ait);
        GridView1.DataSource = alist;
        GridView1.DataBind();


        double price = scService.getTenderQuotationByKey(DropDownList2.SelectedValue, DropDownList1.SelectedValue).price;
        cost = cost + price * Convert.ToInt32(TextBox4.Text);
        avoucher.AdjustmentItems.Add(ait);
    }

    protected void Report_Click(object sender, EventArgs e)
    {
        //AdjustmentVoucher avoucher = new AdjustmentVoucher();
        avoucher.issuedate=Calendar1.SelectedDate;
        avoucher.cost = cost;
        avoucher.clerkcode = 1026;

        scService.adjustItem(avoucher);
    }

   
}