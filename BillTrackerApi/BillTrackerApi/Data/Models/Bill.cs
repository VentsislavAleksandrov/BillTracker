namespace BillTrackerApi.Data.Models
{
    public class Bill
    {
        public int Id { get; set; }

        public string Company { get; set; }

        public double Anount { get; set; }

        public string Deadline { get; set; }

        public bool IsPaid { get; set; }
    }
}
