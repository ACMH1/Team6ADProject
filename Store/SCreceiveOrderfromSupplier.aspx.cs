using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SCreceiveOrderfromSupplier : System.Web.UI.Page
{
    SCserviceManager sc = new SCserviceManager();
    int role;
    protected void Page_Load(object sender, EventArgs e)
    {
        //try
        //{
            IIdentity id = User.Identity;
            role = Convert.ToInt32(id.Name);
            if (!IsPostBack)
            {
                DropDownList2.DataBind();
                DropDownList2.SelectedIndex = 0;
                List<int> purchaseid = sc.getpurchaseid(DropDownList2.SelectedItem.Text);
                List<dynamic> items = new List<dynamic>();
                foreach (int i in purchaseid)
                {
                    List<dynamic> item = sc.getorderdetails(i).ToList();
                    items.AddRange(item);

                }
                GridView1.DataSource = items;
                GridView1.DataBind();
                if (GridView1.Rows.Count == 0)
                {
                    Label3.Text = "No order to receive";
                }
                if (GridView1.Rows.Count > 0)
                {
                    Label3.Visible = false;
                }
            }
        //}
        //catch (Exception)
        //{
        //    Response.Redirect("~/Error.aspx");
        //}
    }

    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        //try
        //{
            List<int> purchaseid = sc.getpurchaseid(DropDownList2.SelectedItem.Text);
            List<dynamic> items = new List<dynamic>();
            foreach (int i in purchaseid)
            {
                List<dynamic> item = sc.getorderdetails(i).ToList();
                items.AddRange(item);

            }
            GridView1.DataSource = items;
            GridView1.DataBind();
            if (GridView1.Rows.Count == 0)
            {
                Label3.Text = "No order to receive";
            }
            if (GridView1.Rows.Count > 0)
            {
                Label3.Visible = false;
            }
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
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                string remarks = "";
                GridViewRow row = GridView1.Rows[i];
                int purchaseid = Convert.ToInt32(GridView1.Rows[i].Cells[0].Text);
                TextBox remarkstextbox = (TextBox)row.FindControl("TextRemarks");
                if (remarkstextbox.Text != "")
                {
                    remarks = remarkstextbox.Text;
                }
                else
                {
                    remarks = null;
                }
                string itemcode = GridView1.Rows[i].Cells[1].Text;
                sc.updateorderitems(purchaseid, itemcode, remarks);
                string deliverno = TextBox1.Text;
                sc.updatesorder(purchaseid, role, deliverno);
            }
            Response.Write("<script>alert('Receive Sucessful');</script>");
            List<int> purchase = sc.getpurchaseid(DropDownList2.SelectedItem.Text);
            List<dynamic> items = new List<dynamic>();
            foreach (int i in purchase)
            {
                List<dynamic> item = sc.getorderdetails(i).ToList();
                items.AddRange(item);

            }
            GridView1.DataSource = items;
            GridView1.DataBind();
            if (GridView1.Rows.Count == 0)
            {
                Label3.Text = "No order to receive";
            }
        //}
        //catch (Exception)
        //{
        //    Response.Redirect("~/Error.aspx");
        //}

    }
}
