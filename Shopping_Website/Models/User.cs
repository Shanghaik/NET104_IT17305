namespace Shopping_Website.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public Guid RoleId { get; set; }
        public string Password { get; set; }
        public int Status { get; set; }
        public virtual IEnumerable<Bill> Bills { get; set; }
        public virtual Role Role { get; set; }

    }
}
