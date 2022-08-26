using System;
using System.Collections.Generic;

namespace rolebased.Models
{
    public partial class Personel
    {
        public int PersonelId { get; set; }
        public string PersonelName { get; set; } = null!;
        public string? PersonelSurname { get; set; }
    }
}
