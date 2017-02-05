using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for TransactionDAO
/// </summary>
public static class TransactionDAO
{
    public static void repopulateTransactions()
    {
        //Initialise set to capture items that experience changes
        HashSet<Item> items = new HashSet<Item>();

        team6adprojectdbEntities ctx = new team6adprojectdbEntities();

        //Clear out transactions database
        foreach (Transaction t in ctx.Transactions.ToList())
        {
            ctx.Transactions.Remove(t);
        }
        ctx.SaveChanges();
        List<Transaction> transactions = new List<Transaction>();

        //Generate transactions from disbursements
        List<Disbursement> disbursements = ctx.Disbursements.ToList();
        foreach (Disbursement d in disbursements)
        {
            foreach (DisbursementItem ditem in d.DisbursementItems)
            {
                if (d.collectiondate.HasValue)
                {
                    Transaction t = new Transaction();
                    t.Item = ditem.Item;
                    items.Add(ditem.Item);
                    t.date = d.collectiondate.Value;
                    t.deptsupplier = d.Department.deptname;
                    t.quantitychange = -ditem.allocatedquantity;
                    transactions.Add(t);
                }
            }
        }

        //Generate transactions from adjustments
        List<AdjustmentVoucher> adjustments = ctx.AdjustmentVouchers.ToList();
        foreach (AdjustmentVoucher a in adjustments)
        {
            foreach (AdjustmentItem aitem in a.AdjustmentItems)
            {
                if (a.approvercode.HasValue)
                {
                    Transaction t = new Transaction();
                    t.Item = aitem.Item;
                    items.Add(aitem.Item);
                    t.date = a.approvaldate.Value;
                    t.deptsupplier = "Stock Adjustment " + a.vouchernumber;
                    t.quantitychange = aitem.quantity;
                    transactions.Add(t);
                }
            }
        }

        //Generate transactions from supplier orders
        List<SOrder> orders = ctx.SOrders.ToList();
        foreach (SOrder o in orders)
        {
            foreach (OrderItem oitem in o.OrderItems)
            {
                if (o.deliverydate.HasValue)
                {
                    Transaction t = new Transaction();
                    t.Item = oitem.Item;
                    items.Add(oitem.Item);
                    t.date = o.deliverydate.Value;
                    t.deptsupplier = "Supplier - " + o.suppliercode;
                    t.quantitychange = oitem.orderquantity;
                    transactions.Add(t);
                }
            }
        }

        //Arrange transactions by date
        transactions.Sort(new CompareByDate());


        foreach (Item i in items)
        {
            List<Transaction> itrans = new List<Transaction>();
            foreach (Transaction t in transactions)
            {
                if (t.Item == i)
                {
                    itrans.Add(t);
                }
                //Console.WriteLine(t.date.ToString() + "\t" + i.itemcode + "\t" + t.deptsupplier + "\t" + t.quantitychange);
            }
            int qty = i.quantityonhand;
            for (int j = itrans.Count - 1; j >= 0; j--)
            {
                itrans[j].balance = qty;
                qty -= itrans[j].quantitychange;
            }
            //foreach (Transaction t in itrans)
            //{
            //    Console.WriteLine(t.date.ToString() + "\t" + t.Item.itemcode + "\t" + t.deptsupplier + "\t" + t.quantitychange + "\t" + t.balance);
            //}
            //Console.WriteLine();
        }
        ctx.Transactions.AddRange(transactions);
        ctx.SaveChanges();
    }

    public static void addTransactionFromDisbursement(Disbursement d)
    {
        team6adprojectdbEntities ctx = new team6adprojectdbEntities();
        foreach (DisbursementItem ditem in d.DisbursementItems)
        {
            if (d.collectiondate.HasValue)
            {
                Transaction t = new Transaction();
                t.itemcode = ditem.Item.itemcode;
                t.date = d.collectiondate.Value;
                t.deptsupplier = d.Department.deptname;
                t.quantitychange = -ditem.allocatedquantity;
                ctx.Transactions.Add(t);
                ditem.Item.quantityonhand = ditem.Item.quantityonhand - ditem.allocatedquantity;
            }
        }
        ctx.SaveChanges();
    }
    public static void addTransactionFromAdjustment(AdjustmentVoucher a)
    {
        team6adprojectdbEntities ctx = new team6adprojectdbEntities();
        foreach (AdjustmentItem aitem in a.AdjustmentItems)
        {
            if (a.approvercode.HasValue)
            {
                Transaction t = new Transaction();
                t.itemcode = aitem.Item.itemcode;
                t.date = a.approvaldate.Value;
                t.deptsupplier = "Stock Adjustment " + a.vouchernumber;
                t.quantitychange = aitem.quantity;
                ctx.Transactions.Add(t);
                aitem.Item.quantityonhand = aitem.Item.quantityonhand + aitem.quantity;
            }
        }
        ctx.SaveChanges();
    }
    public static void addTransactionFromOrder(SOrder o)
    {
        team6adprojectdbEntities ctx = new team6adprojectdbEntities();
        foreach (OrderItem oitem in o.OrderItems)
        {
            if (o.deliverydate.HasValue)
            {
                Transaction t = new Transaction();
                t.itemcode = oitem.Item.itemcode;
                t.date = o.deliverydate.Value;
                t.deptsupplier = "Supplier - " + o.suppliercode;
                t.quantitychange = oitem.orderquantity;
                ctx.Transactions.Add(t);
                oitem.Item.quantityonhand = oitem.Item.quantityonhand + oitem.orderquantity;
            }
        }
        ctx.SaveChanges();
    }
}

public class CompareByDate : IComparer<Transaction>
{
    public int Compare(Transaction x, Transaction y)
    {
        return x.date.CompareTo(y.date);
    }
}