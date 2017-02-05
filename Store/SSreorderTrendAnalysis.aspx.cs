﻿using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Store_SSreorderTrendAnalysis : System.Web.UI.Page
{
    string cate;
    string time1;
    string time2;
    string time3;
    string cateselect;
    List<ListItem> selecteditem;
    List<Supplier> suppliers;
    DateTime selecttime;
    SSserviceManager ssmanager = new SSserviceManager();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            cate = ListBox5.SelectedValue.ToString();
            time1 = Lbmonth1.Text;
            time2 = Lbmonth2.Text;
            time3 = Lbmonth3.Text;
            cateselect = Label1.Text;
            selecttime = Calendar1.SelectedDate;
            selecteditem = new List<ListItem>();
            foreach (ListItem item in CheckBoxList1.Items)
                if (item.Selected) selecteditem.Add(item);

            if (cate == null)
            {
                Button1.Enabled = false;
            }
            if (selecttime == null)
            {
                Btnmonth1.Enabled = false;
                Btnmonth2.Enabled = false;
                Btnmonth3.Enabled = false;
            }
            if (cateselect == null || selecteditem == null || time1 == null)
            {
                Btngenerate.Enabled = false;
            }



            string que = " select c.category,d.suppliercode,Month(d.deliverydate) as reordermonth,YEAR(d.deliverydate) as reorderyear, sum(b.cost) as reorderammount from OrderItem b,Item c ,sorder d where b.itemcode = c.itemcode and d.purchaseordernumber = b.purchaseordernumber  group by d.suppliercode, c.category, Month(d.deliverydate), YEAR(d.deliverydate)";
            SS.CryDataSet ds = ssmanager.setReorderDataSet(que);
            SS.SSreorderTrend cryview2 = new SS.SSreorderTrend();

            cryview2.SetDataSource(ds);
            CrystalReportViewer1.ReportSource = cryview2;
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
            // string cate = ListBox5.SelectedValue.ToString();
            Label1.Text = cate;
            suppliers = ssmanager.findSupplierByCategory(cate);
            CheckBoxList1.DataSource = suppliers;
            CheckBoxList1.DataBind();
        }
        catch (Exception)
        {
            Response.Redirect("~/Error.aspx");
        }
    }

    protected void Btngenerate_Click(object sender, EventArgs e)
    {
        try
        {
            cateselect = Label1.Text;
            string supcode = "";
            foreach (ListItem i in selecteditem)
            {
                supcode += "'" + i.Text + "',";
            }
            string resultsupplier = supcode.Substring(0, supcode.Length - 1);

            string que = " select c.category,d.suppliercode,Month(d.deliverydate) as reordermonth,YEAR(d.deliverydate) as reorderyear, sum(b.cost) as reorderammount from OrderItem b,Item c ,sorder d "
                +
                "where b.itemcode = c.itemcode and d.purchaseordernumber = b.purchaseordernumber and c.category='"
                + cateselect +
                "' and d.suppliercode in ("
                + resultsupplier
                + ") and  d.deliverydate like  ('"
                + time1
                + "-%' )"
                +
                "group by d.suppliercode, c.category, Month(d.deliverydate), YEAR(d.deliverydate)"
                + "union"
                + " select c.category,d.suppliercode,Month(d.deliverydate) as reordermonth,YEAR(d.deliverydate) as reorderyear, sum(b.cost) as reorderammount from OrderItem b,Item c ,sorder d "
                +
                "where b.itemcode = c.itemcode and d.purchaseordernumber = b.purchaseordernumber and c.category='"
                + cateselect +
                "' and d.suppliercode in ("
                + resultsupplier
                + ") and  d.deliverydate like  ('"
                + time2
                + "-%' )"
                +
                "group by d.suppliercode, c.category, Month(d.deliverydate), YEAR(d.deliverydate)"
                + "union"
                + " select c.category,d.suppliercode,Month(d.deliverydate) as reordermonth,YEAR(d.deliverydate) as reorderyear, sum(b.cost) as reorderammount from OrderItem b,Item c ,sorder d "
                +
                "where b.itemcode = c.itemcode and d.purchaseordernumber = b.purchaseordernumber and c.category='"
                + cateselect +
                "' and d.suppliercode in ("
                + resultsupplier
                + ") and  d.deliverydate like  ('"
                + time3
                + "-%' )"
                +
                "group by d.suppliercode, c.category, Month(d.deliverydate), YEAR(d.deliverydate)"
                ;
            SS.CryDataSet ds = ssmanager.setReorderDataSet(que);
            SS.SSreorderTrend cryview2 = new SS.SSreorderTrend();

            cryview2.SetDataSource(ds);
            CrystalReportViewer1.ReportSource = cryview2;
        }
        catch (Exception)
        {
            Response.Redirect("~/Error.aspx");
        }

    }


    protected void Btnmonth2_Click(object sender, EventArgs e)
    {
        try
        {
            string month = selecttime.Month.ToString();
            string year = selecttime.Year.ToString();
            if (month.Length == 1)
            {
                Lbmonth2.Text = year + "-0" + month;
            }
            else
            {
                Lbmonth2.Text = year + "-" + month;
            }
        }
        catch (Exception)
        {
            Response.Redirect("~/Error.aspx");
        }

    }

    protected void Btnmonth1_Click(object sender, EventArgs e)
    {
        try
        {
            string month = selecttime.Month.ToString();
            string year = selecttime.Year.ToString();
            if (month.Length == 1)
            {
                Lbmonth1.Text = year + "-0" + month;
            }
            else
            {
                Lbmonth1.Text = year + "-" + month;
            }
        }
        catch (Exception)
        {
            Response.Redirect("~/Error.aspx");
        }
    }

    protected void Btnmonth3_Click(object sender, EventArgs e)
    {
        try
        {
            string month = selecttime.Month.ToString();
            string year = selecttime.Year.ToString();
            if (month.Length == 1)
            {
                Lbmonth3.Text = year + "-0" + month;
            }
            else
            {
                Lbmonth3.Text = year + "-" + month;
            }
        }
        catch (Exception)
        {
            Response.Redirect("~/Error.aspx");
        }
    }
}