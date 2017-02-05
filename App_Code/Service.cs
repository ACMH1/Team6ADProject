using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Principal;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Security;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.

public class Service : IService
{
    static Dictionary<int, int> hm = new Dictionary<int, int>();
    SCserviceManager scmanager = new SCserviceManager();
    DHserviceManager dhmanager = new DHserviceManager();
    public string[] listDeliverCollectionPoint()
    {
        string token = WebOperationContext.Current.IncomingRequest.Headers["Token"];
        List<string> rt = token.Split(':').ToList<string>();


        string role = rt[0];
        int token1 = Convert.ToInt32(rt[1]);
        int usercode;
        if (hm.TryGetValue(token1, out usercode))
        {
            string ucode = Convert.ToString(usercode);
            if (role.Equals(Roles.GetRolesForUser(ucode)[0]) && role.Equals("storeclerk"))
            {
                string[] cols = scmanager.listDeliverCollectionPoint();
                return cols;
            }
            else
            {
                return null;
            }

        }
        else
        {
            return null;
        }
    }
    public WCFDisbursement[] findDeliverDisburseByCollectionPoint(string colpoint)
    {
        string token = WebOperationContext.Current.IncomingRequest.Headers["Token"];
        List<string> rt = token.Split(':').ToList<string>();


        string role = rt[0];
        int token1 = Convert.ToInt32(rt[1]);
        int usercode;
        if (hm.TryGetValue(token1, out usercode))
        {
            string ucode = Convert.ToString(usercode);
            if (role.Equals(Roles.GetRolesForUser(ucode)[0]) && role.Equals("storeclerk"))
            {
                List<Disbursement> dlist = new List<Disbursement>();
                dlist = scmanager.findDeliverDisburseByCollectionPoint(colpoint);
                List<WCFDisbursement> wdkust = new List<WCFDisbursement>();
                foreach (Disbursement i in dlist)
                {
                    WCFDisbursement wdept = WCFDisbursement.Make(i.disbursementid, i.deptcode, i.representativecode, i.collectiondate);
                    wdkust.Add(wdept);
                }
                return wdkust.ToArray();
            }
            else
            {
                return null;
            }

        }
        else
        {
            return null;
        }
    }
    public WCFDisbursementItem[] findDeliverDisburseItemByDisburseid(string id)
    {
        string token = WebOperationContext.Current.IncomingRequest.Headers["Token"];
        List<string> rt = token.Split(':').ToList<string>();


        string role = rt[0];
        int token1 = Convert.ToInt32(rt[1]);
        int usercode;
        if (hm.TryGetValue(token1, out usercode))
        {
            string ucode = Convert.ToString(usercode);
            if (role.Equals(Roles.GetRolesForUser(ucode)[0]) && role.Equals("storeclerk"))
            {



                List<string> names = id.Split(',').ToList<string>();
                List<DisbursementItem> items = scmanager.findDeliverDisburseItemByDisburseid(names[0], names[1]);
                List<WCFDisbursementItem> itemarray = new List<WCFDisbursementItem>();
                foreach (DisbursementItem i in items)
                {
                    int? allocated = i.allocatedquantity;
                    WCFDisbursementItem item = WCFDisbursementItem.Make(i.disbursementid, i.itemcode, i.allocatedquantity, allocated, i.Item.supplier1, i.Item.supplier2, i.Item.supplier3);
                    itemarray.Add(item);
                }
                return itemarray.ToArray();
            }
            else
            {
                return null;
            }

        }
        else
        {
            return null;
        }
    }

    public void UpdateDisbursementItem(List<WCFDisbursementItem> disitems)
    {
        string token = WebOperationContext.Current.IncomingRequest.Headers["Token"];
        List<string> rt = token.Split(':').ToList<string>();
        string role = rt[0];
        int token1 = Convert.ToInt32(rt[1]);
        int usercode;
        if (hm.TryGetValue(token1, out usercode))
        {
            string ucode = Convert.ToString(usercode);
            if (role.Equals(Roles.GetRolesForUser(ucode)[0]) && role.Equals("storeclerk"))
            {
                int clerkcode = Convert.ToInt32(disitems[0].Supplier2);
                double cost = 0;
                for (int i = 0; i < disitems.Count; i++)
                {

                    DisbursementItem item = scmanager.findDisbursementByDisburseAndItem(disitems[i].Disbursementid, disitems[i].Itemcode);
                    item.actualquantity = disitems[i].Actualquantity;

                    int al = disitems[i].Allocatedquantity;
                    int ac = (int)disitems[i].Actualquantity;
                    int minus = ac - al;
                    string dept = item.Disbursement.deptcode;
                    List<RequisitionItem> rlist = new List<RequisitionItem>();
                    List<Requisition> reqlist = new List<Requisition>();
                    rlist = scmanager.getrequisitions(dept);
                    reqlist = scmanager.getreq(dept);
                    if (minus < 0)
                    {
                        double price = scmanager.findPriceBySupplierAndItem(disitems[i].Supplier1, disitems[i].Itemcode);
                        cost += price;

                        scmanager.addadjustmentvoucher(price, clerkcode, item.itemcode, minus);
                        foreach (RequisitionItem it in rlist)
                        {
                            if (it.itemcode == item.itemcode)
                            {
                                scmanager.deliverstatus(it.requisitionid, it.itemcode, Math.Abs(minus), ac, dept, it.Requisition.employeecode);
                            }
                        }
                    }
                    else
                    {
                        foreach (RequisitionItem it in rlist)
                        {
                            if (it.itemcode == item.itemcode)
                            {
                                scmanager.updatestatusto3(it.requisitionid, it.itemcode);
                            }
                        }
                    }
                    scmanager.updatedisbursement(item.disbursementid, item.itemcode, ac);
                    for (int z = 0; z < reqlist.Count; z++)
                    {
                        int reqcount = scmanager.getreqcount(reqlist[z].requisitionid);
                        int statuscount = scmanager.getstatuscount(reqlist[z].requisitionid);
                        if (reqcount == statuscount)
                        {
                            scmanager.updaterequisition(reqlist[z].requisitionid);
                        }

                    }
                    try
                    {
                        scmanager.updatedisb(item.Disbursement.deptcode);
                    }
                    catch (Exception)
                    {
                        continue;
                    }

                }
            }


        }

    }
    public WCFItem findItemByItemcode(string id)
    {
        string token = WebOperationContext.Current.IncomingRequest.Headers["Token"];
        List<string> rt = token.Split(':').ToList<string>();


        string role = rt[0];
        int token1 = Convert.ToInt32(rt[1]);
        int usercode;
        if (hm.TryGetValue(token1, out usercode))
        {
            string ucode = Convert.ToString(usercode);
            if (role.Equals(Roles.GetRolesForUser(ucode)[0]) && role.Equals("storeclerk"))
            {
                Item it = scmanager.findItemByItemcode(id);
                WCFItem ite = WCFItem.Make(it.itemcode, it.category, it.itemdescription, it.bin, it.quantityonhand, it.reorderlevel, it.reorderquantity, it.unitofmeasure, it.Supplier.suppliercode, it.Supplier4.suppliercode, it.Supplier5.suppliercode, it.del);
                return ite;
            }
            else
            {
                return null;
            }

        }
        else
        {
            return null;
        }
    }

    public void createAdjustment(List<WCFAdjustmentItem> adjitems)
    {
        string token = WebOperationContext.Current.IncomingRequest.Headers["Token"];
        List<string> rt = token.Split(':').ToList<string>();


        string role = rt[0];
        int token1 = Convert.ToInt32(rt[1]);
        int usercode;
        if (hm.TryGetValue(token1, out usercode))
        {
            string ucode = Convert.ToString(usercode);
            if (role.Equals(Roles.GetRolesForUser(ucode)[0]) && role.Equals("storeclerk"))
            {


                AdjustmentVoucher adjs = new AdjustmentVoucher();
                double cost = 0;
                foreach (WCFAdjustmentItem i in adjitems)
                {
                    AdjustmentItem item = new AdjustmentItem();
                    item.itemcode = i.Itemcode;
                    item.quantity = i.Quantity;
                    item.reason = i.Reason;
                    double price = scmanager.findPriceBySupplierAndItem(i.Suppliercode, i.Itemcode);
                    cost += Math.Abs(item.quantity * price);
                    adjs.AdjustmentItems.Add(item);
                }
                adjs.issuedate = DateTime.Today;
                adjs.cost = cost;
                adjs.clerkcode = 1027;
                string di = adjs.ToString();
                scmanager.createAdjustmentVoucher(adjs);

            }


        }


    }

    public List<WCFRequisitionItem> findRequisitionItemsByHead(string head)
    {
        string token = WebOperationContext.Current.IncomingRequest.Headers["Token"];
        List<string> rt = token.Split(':').ToList<string>();

        string role = rt[0];
        int token1 = Convert.ToInt32(rt[1]);
        int usercode;
        if (hm.TryGetValue(token1, out usercode))
        {
            string ucode = Convert.ToString(usercode);
            if (role.Equals(Roles.GetRolesForUser(ucode)[0]) && role.Equals("departmenthead"))
            {


                int headcode = Convert.ToInt32(head);
                List<WCFRequisitionItem> rilist = new List<WCFRequisitionItem>();
                List<RequisitionItem> rlist = dhmanager.findRequisitionItemsByHead(headcode);
                foreach (RequisitionItem j in rlist)
                {

                    WCFRequisitionItem wcfitem = WCFRequisitionItem.Make(j.requisitionid, j.itemcode, j.Item.itemdescription, j.quantity, j.status);
                    rilist.Add(wcfitem);
                }
                return rilist;

            }
            else
            {
                return null;
            }

        }
        else
        {
            return null;
        }


    }

    public void rejectRequisition(string requisitionid)
    {
        string token = WebOperationContext.Current.IncomingRequest.Headers["Token"];
        List<string> rt = token.Split(':').ToList<string>();

        string role = rt[0];
        int token1 = Convert.ToInt32(rt[1]);
        int usercode;
        if (hm.TryGetValue(token1, out usercode))
        {
            string ucode = Convert.ToString(usercode);
            if (role.Equals(Roles.GetRolesForUser(ucode)[0]) && role.Equals("departmenthead"))
            {

                int id = Convert.ToInt32(requisitionid);
                Requisition item = dhmanager.findRequisitionByRequisitionId(id);
                dhmanager.reject(id);
                dhmanager.sendRejectEmail(String.Format("Your requisition : {0} is rejected",item.requisitionid), item.Employee.employeeemail);
                
            }


        }


    }

    public void approveRequisition(string[] reidandheid)
    {
        string token = WebOperationContext.Current.IncomingRequest.Headers["Token"];
        List<string> rt = token.Split(':').ToList<string>();

        string role = rt[0];
        int token1 = Convert.ToInt32(rt[1]);
        int usercode;
        if (hm.TryGetValue(token1, out usercode))
        {
            string ucode = Convert.ToString(usercode);
            if (role.Equals(Roles.GetRolesForUser(ucode)[0]) && role.Equals("departmenthead"))
            {



                int rid = Convert.ToInt32(reidandheid[0]);
                int hid = Convert.ToInt32(reidandheid[1]);
                dhmanager.approve(rid, hid);

            }

        }


    }
    public List<WCFEmployee> populateEmployee(string headcode)
    {
        string token = WebOperationContext.Current.IncomingRequest.Headers["Token"];
        List<string> rt = token.Split(':').ToList<string>();


        string role = rt[0];
        int token1 = Convert.ToInt32(rt[1]);
        int usercode;
        if (hm.TryGetValue(token1, out usercode))
        {
            string ucode = Convert.ToString(usercode);
            if (role.Equals(Roles.GetRolesForUser(ucode)[0]) && role.Equals("departmenthead"))
            {


                int hcode = Convert.ToInt32(headcode);
                List<WCFEmployee> wcfelist = new List<WCFEmployee>();
                List<Employee> elist = dhmanager.PopulateEmpList(hcode);
                foreach (Employee i in elist)
                {
                    WCFEmployee e = WCFEmployee.Make(i.employeecode, i.employeename, i.employeeemail, i.deptcode, i.role, i.del);
                    wcfelist.Add(e);
                }
                return wcfelist;
            }
            else
            {
                return null;
            }

        }
        else
        {
            return null;
        }

    }
    public void setRepresentative(WCFEmployee remp)
    {
        string token = WebOperationContext.Current.IncomingRequest.Headers["Token"];
        List<string> rt = token.Split(':').ToList<string>();


        string role = rt[0];
        int token1 = Convert.ToInt32(rt[1]);
        int usercode;
        if (hm.TryGetValue(token1, out usercode))
        {
            string ucode = Convert.ToString(usercode);
            if (role.Equals(Roles.GetRolesForUser(ucode)[0]) && role.Equals("departmenthead"))
            {


                int emcode = remp.Employeecode;
                string deptcode = remp.Deptcode;
                Employee re = dhmanager.getDepartmentRepresentativeByDept(deptcode);
                int recode = re.employeecode;
                dhmanager.changePreviousRepresentative(recode);
                dhmanager.setRepresentative(emcode);
            }

        }

    }

    public WCFEmployee findCurrentRepresentative(string headid)
    {
        string token = WebOperationContext.Current.IncomingRequest.Headers["Token"];
        List<string> rt = token.Split(':').ToList<string>();

        string role = rt[0];
        int token1 = Convert.ToInt32(rt[1]);
        int usercode;
        if (hm.TryGetValue(token1, out usercode))
        {
            string ucode = Convert.ToString(usercode);
            if (role.Equals(Roles.GetRolesForUser(ucode)[0]) && role.Equals("departmenthead"))
            {


                int head = Convert.ToInt32(headid);
                Employee current = dhmanager.getDepartmentRepresentative(head);
                WCFEmployee wcfcurrent = WCFEmployee.Make(current.employeecode, current.employeename, current.employeeemail, current.deptcode, current.role, current.del);
                return wcfcurrent;
            }
            else
            {
                return null;
            }

        }
        else
        {
            return null;
        }
    }
    public void updateCollectionPoint(string[] cpointandhecode)
    {
        string token = WebOperationContext.Current.IncomingRequest.Headers["Token"];
        List<string> rt = token.Split(':').ToList<string>();


        string role = rt[0];
        int token1 = Convert.ToInt32(rt[1]);
        int usercode;
        if (hm.TryGetValue(token1, out usercode))
        {
            string ucode = Convert.ToString(usercode);
            if (role.Equals(Roles.GetRolesForUser(ucode)[0]) && (role.Equals("departmenthead") || role.Equals("departmentrepresentative")))
            {


                string cpoint = cpointandhecode[0];
                int hecode = Convert.ToInt32(cpointandhecode[1]);
                dhmanager.DHupdateCollectionPoint(cpoint, hecode);
            }

        }

    }
    public string[] findCurrentCollectionPoint(string headid)
    {
        string token = WebOperationContext.Current.IncomingRequest.Headers["Token"];
        List<string> rt = token.Split(':').ToList<string>();

        string role = rt[0];
        int token1 = Convert.ToInt32(rt[1]);
        int usercode;
        if (hm.TryGetValue(token1, out usercode))
        {
            string ucode = Convert.ToString(usercode);
            if (role.Equals(Roles.GetRolesForUser(ucode)[0]) && (role.Equals("departmenthead") || role.Equals("departmentrepresentative")))
            {


                int head = Convert.ToInt32(headid);
                Department thatdept = dhmanager.DHfindCurrentCollectionPoint(head);
                string collectionpoint = thatdept.collectionpoint;
                string[] col = new string[] { collectionpoint };
                return col;
            }
            else
            {
                return null;
            }

        }
        else
        {
            return null;
        }
    }

    public string Login(WCFLogin login)
    {
        string wcfe = "";
        string usercode = Convert.ToString(login.Usercode);
        bool result = Membership.ValidateUser(usercode, login.Password);

        if (result)
        {
            string role = Roles.GetRolesForUser(usercode)[0];
            int token = 0;

            if (hm.ContainsValue(login.Usercode))
            {
                token = hm.FirstOrDefault(x => x.Value == login.Usercode).Key;

            }
            else
            {
                Random rnd1 = new Random();
                int i1 = rnd1.Next(1, 99999999);
                Random rnd2 = new Random();
                int i2 = rnd2.Next(1, 99999999);
                token = Math.Abs(i1 * i2);
                hm.Add(token, login.Usercode);
            }

            wcfe = ":" + usercode + ":" + role + ":" + token + ":";
        }
        return wcfe;

    }

    public string[] getuniqueitems()
    {
        string token = WebOperationContext.Current.IncomingRequest.Headers["Token"];
        List<string> rt = token.Split(':').ToList<string>();


        string role = rt[0];
        int token1 = Convert.ToInt32(rt[1]);
        int usercode;
        if (hm.TryGetValue(token1, out usercode))
        {
            string ucode = Convert.ToString(usercode);
            if (role.Equals(Roles.GetRolesForUser(ucode)[0]) && role.Equals("storeclerk"))
            {

                string[] list = scmanager.getuniqueitems().ToArray<string>();
                return list;
            }
            else
            {
                return null;
            }

        }
        else
        {
            return null;
        }

    }
    public string[] getuniqueitems2()
    {
        string token = WebOperationContext.Current.IncomingRequest.Headers["Token"];
        List<string> rt = token.Split(':').ToList<string>();

        string role = rt[0];
        int token1 = Convert.ToInt32(rt[1]);
        int usercode;
        if (hm.TryGetValue(token1, out usercode))
        {
            string ucode = Convert.ToString(usercode);
            if (role.Equals(Roles.GetRolesForUser(ucode)[0]) && role.Equals("storeclerk"))
            {


                string[] list = scmanager.getuniqueitems2().ToArray<string>();
                return list;
            }
            else
            {
                return null;
            }

        }
        else
        {
            return null;
        }
    }
    public List<WCFRequestDept> getrequestdeptstatus(string item)
    {
        string token = WebOperationContext.Current.IncomingRequest.Headers["Token"];
        List<string> rt = token.Split(':').ToList<string>();


        string role = rt[0];
        int token1 = Convert.ToInt32(rt[1]);
        int usercode;
        if (hm.TryGetValue(token1, out usercode))
        {
            string ucode = Convert.ToString(usercode);
            if (role.Equals(Roles.GetRolesForUser(ucode)[0]) && role.Equals("storeclerk"))
            {


                List<dynamic> rdlist = scmanager.getrequestdeptstatus(item);
                List<WCFRequestDept> redelist = getrequestdept(rdlist);
                return redelist;
            }
            else
            {
                return null;
            }

        }
        else
        {
            return null;
        }

    }
    public List<WCFRequestDept> getrequestdeptstatus2(string item)
    {
        string token = WebOperationContext.Current.IncomingRequest.Headers["Token"];
        List<string> rt = token.Split(':').ToList<string>();


        string role = rt[0];
        int token1 = Convert.ToInt32(rt[1]);
        int usercode;
        if (hm.TryGetValue(token1, out usercode))
        {
            string ucode = Convert.ToString(usercode);
            if (role.Equals(Roles.GetRolesForUser(ucode)[0]) && role.Equals("storeclerk"))
            {


                List<dynamic> rdlist = scmanager.getrequestdeptstatus2(item);
                List<WCFRequestDept> redelist = getrequestdept(rdlist);

                return redelist;
            }
            else
            {
                return null;
            }

        }
        else
        {
            return null;
        }
    }
    public List<WCFRequestDept> getrequestdept(List<dynamic> rdlist)
    {
        string token = WebOperationContext.Current.IncomingRequest.Headers["Token"];
        List<string> rt = token.Split(':').ToList<string>();


        string role = rt[0];
        int token1 = Convert.ToInt32(rt[1]);
        int usercode;
        if (hm.TryGetValue(token1, out usercode))
        {
            string ucode = Convert.ToString(usercode);
            if (role.Equals(Roles.GetRolesForUser(ucode)[0]) && role.Equals("storeclerk"))
            {


                List<WCFRequestDept> redelist = new List<WCFRequestDept>();
                int available = 0;
                List<int> requested = new List<int>();

                foreach (dynamic i in rdlist)
                {

                    string itemdescription = i.Description;
                    int quantityonhand = i.Actualqty;
                    int requisitionid = i.RequisitionID;
                    string deptname = i.DepartmentName;
                    int deptneededquantity = i.deptneeded;
                    int allocatedquantity = 0;
                    string itemcode = i.itemcode;
                    string bin = i.BIN;

                    WCFRequestDept deitem = WCFRequestDept.Make(bin, itemdescription, quantityonhand, requisitionid, deptname, deptneededquantity, allocatedquantity, itemcode);
                    redelist.Add(deitem);
                    available = quantityonhand;

                }
                for (int j = 0; j < redelist.Count; j++)
                {
                    for (int n = j + 1; n < redelist.Count; n++)
                    {
                        if (redelist[j].Deptname == redelist[n].Deptname)
                        {
                            if (redelist[j].Requisitionid < redelist[n].Requisitionid)
                            {
                                redelist[j].Deptneededquantity += redelist[n].Deptneededquantity;
                                redelist.Remove(redelist[n]);
                            }
                        }
                    }
                }

                foreach (WCFRequestDept it in redelist)
                {
                    requested.Add(it.Deptneededquantity);
                }

                List<int> allocatedlist = scmanager.recommendDistribution(available, requested);
                for (int i = 0; i < allocatedlist.Count; i++)
                {
                    redelist[i].Allocatedquantity = allocatedlist[i];
                }

                return redelist;
            }
            else
            {
                return null;
            }

        }
        else
        {
            return null;
        }
    }
    public void sendRequestDepts(List<WCFRequestDept> rdlist)
    {
        string token = WebOperationContext.Current.IncomingRequest.Headers["Token"];
        List<string> rt = token.Split(':').ToList<string>();

        string role = rt[0];
        int token1 = Convert.ToInt32(rt[1]);
        int usercode;
        if (hm.TryGetValue(token1, out usercode))
        {
            string ucode = Convert.ToString(usercode);
            if (role.Equals(Roles.GetRolesForUser(ucode)[0]) && role.Equals("storeclerk"))
            {


                int sumneededqty = 0;
                foreach (WCFRequestDept i in rdlist)
                {
                    string deptname = i.Deptname;
                    string deptcode = scmanager.getdepartmentcode(deptname);
                    int recode = scmanager.getrepresentativecode(deptcode);
                    Disbursement disburse = new Disbursement();
                    disburse.deptcode = deptcode;
                    disburse.representativecode = recode;
                    Disbursement newdisburse = scmanager.addtodisbursement(disburse);
                    int id = newdisburse.disbursementid;

                    DisbursementItem disburseitem = new DisbursementItem();
                    disburseitem.disbursementid = id;
                    disburseitem.itemcode = i.Itemcode;
                    disburseitem.allocatedquantity = i.Allocatedquantity;
                    scmanager.addtodisbursementitem(newdisburse, disburseitem);
                    sumneededqty += i.Deptneededquantity;
                    RequisitionItem status = scmanager.getstatus(i.Requisitionid, i.Itemcode);
                    Requisition employeecode = scmanager.getemployeecode(i.Requisitionid);
                    if (i.Deptneededquantity == i.Allocatedquantity)
                    {
                        scmanager.updateStatus(i.Requisitionid, i.Itemcode, i.Quantityonhand - i.Allocatedquantity);
                    }
                    else if (i.Deptneededquantity != i.Allocatedquantity)
                    {
                        scmanager.owestatus(i.Requisitionid, i.Itemcode, i.Quantityonhand - i.Allocatedquantity, i.Allocatedquantity, deptcode, employeecode.employeecode, status);
                    }


                }
                int quantityonhand = rdlist[0].Quantityonhand;
                string itemcode = rdlist[0].Itemcode;
                Item item = scmanager.getreorderlevel(itemcode);

                int minus = Math.Abs(sumneededqty - quantityonhand);
                if (minus <= item.reorderlevel)
                {
                    scmanager.raiseReorder(item, 1025);
                }



            }


        }
    }
}