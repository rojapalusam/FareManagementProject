using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace RestAPI.Models
{
    public partial class TblCurrency
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string CurrencyCode { get; set; }
        public string CurrencySymbol { get; set; }
        public string CurrencyOrSymbol { get; set; }
        public string CurrencyPlacement { get; set; }
        public bool? ShowCents { get; set; }
        public string DisplayFormat { get; set; }
    }
}
