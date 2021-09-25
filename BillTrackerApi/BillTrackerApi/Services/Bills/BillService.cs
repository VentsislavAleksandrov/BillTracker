using BillTrackerApi.Data;
using BillTrackerApi.Data.Models;
using BillTrackerApi.Models.Bills;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BillTrackerApi.Services.Bills
{
    public class BillService : IBillService
    {
        private readonly ApplicationDbContext db;

        public BillService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void CreateBill(InsertBillModel bill)
        {
            var currBill = new Bill
            {
                IsPaid = bill.IsPaid,
                Anount = bill.Anount,
                Company = bill.Company,
                Deadline = bill.Deadline
            };

            db.Bills.Add(currBill);
            db.SaveChanges();
        }

        public void DeleteBill(Bill bill)
        {
            db.Bills.Remove(bill);
            db.SaveChanges();
        }

        public bool EditBill(EditBillModel bill)
        {
            var currBill = db.Bills.FirstOrDefault(x => x.Id == bill.Id);

            if (currBill == null)
            {
                return false;
            }

            currBill.Anount = bill.Anount;
            currBill.Company = bill.Company;
            currBill.Deadline = bill.Deadline;
            currBill.IsPaid = bill.IsPaid;

            db.SaveChanges();

            return true;
        }

        public IEnumerable<Bill> GetAllBills()
        {
            var bills = db.Bills.ToList();

            return bills;
        }

        public Bill GetBillById(int Id)
        {
            var bill = db.Bills.Find(Id);

            return bill;
        }
    }
}
