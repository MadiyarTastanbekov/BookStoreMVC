using System;


namespace BookStoreMVC.Models
{
    public class Purchase
    {
        public int BookId { get; set; }
        public int PurchaseId { get; set; }
        public string Person { get; set; }
        public decimal Phone { get; set; }
        public DateTime DateTime { get; set; }
    }
}