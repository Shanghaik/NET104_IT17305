namespace Shopping_Website.Models
{
    public class Bill
    {
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
        public Guid UserID { get; set; }
        public int Status { get; set; }
        public virtual IQueryable<BillDetails> Details { get; set; }

    }
}
