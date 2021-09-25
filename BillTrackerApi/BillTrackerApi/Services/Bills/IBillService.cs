using BillTrackerApi.Data.Models;
using BillTrackerApi.Models.Bills;
using System.Collections.Generic;

namespace BillTrackerApi.Services.Bills
{
    public interface IBillService
    {
        IEnumerable<Bill> GetAllBills();

        Bill GetBillById(int id);

        void CreateBill(InsertBillModel bill);

        bool EditBill(EditBillModel bill);

        void DeleteBill(Bill bill);
    }
}
