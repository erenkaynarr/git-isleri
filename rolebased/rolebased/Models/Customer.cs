using System;
using System.Collections.Generic;

namespace rolebased.Models
{
    public partial class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = null!;
        public string? CustomerSurname { get; set; }
    }
}
