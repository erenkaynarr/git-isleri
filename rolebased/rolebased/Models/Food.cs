using System;
using System.Collections.Generic;


namespace rolebased.Models
{
    public partial class Food
    {
        
        public int FoodId { get; set; }
        public string? FoodName { get; set; }
        public int? FoodPrice { get; set; }
    }
}
