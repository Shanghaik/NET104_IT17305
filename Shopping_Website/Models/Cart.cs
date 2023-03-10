﻿namespace Shopping_Website.Models
{
    public class Cart
    {
        public Guid UserId { get; set; }
        public string Description { get; set; }
        public virtual User User { get; set; }
        public virtual List<CartDetail> Details { get; set; }   
    }
}
