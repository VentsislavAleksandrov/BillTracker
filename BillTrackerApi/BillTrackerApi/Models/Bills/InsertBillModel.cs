namespace BillTrackerApi.Models.Bills
{
    public class InsertBillModel
    {
        public string Company { get; set; }

        public double Anount { get; set; }

        public string Deadline { get; set; }

        public bool IsPaid { get; set; }
    }
}
