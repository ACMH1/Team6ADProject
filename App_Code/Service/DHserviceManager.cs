using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Security;

/// <summary>
/// Summary description for DHserviceManager
/// </summary>
public class DHserviceManager
{

    public DHserviceManager()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public Department DHfindCurrentCollectionPoint(int id)
    {
        return DepartmentDAO.DHfindCurrentCollectionPoint(id);
    }
    public void DHupdateCollectionPoint(string Cpoint, int headcode)
    {
        DepartmentDAO.DHupdateCollectionPoint(Cpoint, headcode);
    }
    public Employee getDepartmentRepresentative(int headcode)
    {
        return DepartmentDAO.getDepartmentRepresentative(headcode);
    }
    public List<Employee> PopulateEmpList(int headcode)
    {
        return DepartmentDAO.PopulateEmpList(headcode);
    }
    public void setRepresentative(int empCode)
    {
        DepartmentDAO.setRepresentative(empCode);
    }
    public void changePreviousRepresentative(int empCode)
    {
        DepartmentDAO.changePreviousRepresentative(empCode);
    }
    public List<Requisition> DHgetRequisitionItems(int headcode)
    {
        return DepartmentDAO.DHgetRequisitionItems(headcode);
    }
    public IEnumerable<dynamic> getItems(int reqid)
    {
        return DepartmentDAO.getItems(reqid);
    }

    public void approve(int id, int headcode)
    {

        DepartmentDAO.approveRequisition(id, headcode);
    }

    public void reject(int id)
    {

        DepartmentDAO.rejectRequisition(id);

    }

    public void sendRejectEmail(string comments, string email)
    {
        if (comments != null)
        {
            sendEmail(comments, email);
        }
        else
        {
            comments = "your request was rejected";
            sendEmail(comments, email);
        }
    }

    public void sendEmail(string message, string email)
    {
        try
        {
            SmtpClient smtpClient = new SmtpClient("lynx.class.iss.nus.edu.sg", 25);
            MailMessage mail = new MailMessage();        
            mail.Body = message;
            mail.From = new MailAddress("sysgenlogicu@gmail.com");
            mail.To.Add(new MailAddress(email));
            smtpClient.Send(mail);        
        }
        catch (Exception e)
        {
            DepartmentDAO.errormessage("Mail was not sent." + e.ToString());
        }
    }

    public string getEmployee(int requid)
    {
        return DepartmentDAO.getEmployee(requid);


    }

    public Employee getDepartmentRepresentativeByDept(string dept)
    {
        return DepartmentDAO.getDepartmentRepresentativeByDept(dept);
    }
    public List<Employee> getAllEmployees(int headcode)
    {
        return DepartmentDAO.getAllEmployees(headcode);
    }

    public void delegateAuthority(int headcode, int ecode, DateTime from, DateTime to)
    {
        DepartmentDAO.delegateAuthority(headcode, ecode, from, to);
    }
    public void executeDelegation()
    {
        foreach (Department dept in DepartmentDAO.ListAllDepartments())
        {
            if (DepartmentDAO.findHeadByDepartment(dept.deptcode) != null)
            {
                int headcode = DepartmentDAO.findHeadByDepartment(dept.deptcode).employeecode;
                if (dept.delegatecode.HasValue && dept.startdate.HasValue && dept.enddate.HasValue)
                {
                    
                    if (((DateTime)dept.startdate).CompareTo(DateTime.Now) <= 0)
                    {
                        if (((DateTime)dept.enddate).CompareTo(DateTime.Now) >= 0)
                        {
                            DepartmentDAO.executeDelegation(dept.deptcode);
                        }
                        else
                        {
                            retrieveAuthority(DepartmentDAO.findHeadByDepartment(dept.deptcode).employeecode);
                        }
                    }
                }
            }
        }
    }

    public void retrieveAuthority(int headcode)
    {
        DepartmentDAO.retrieveAuthority(headcode);
    }
    public List<RequisitionItem> findRequisitionItemsByHead(int headcode)
    {
        List<RequisitionItem> items = DepartmentDAO.findRequisitionItemsByHead(headcode);
        return items;
    }
    public Requisition findRequisitionByRequisitionId(int requisitionid)
    {
        Requisition item = DepartmentDAO.findRequisitionByRequisitionId(requisitionid);
        return item;

    }
}
