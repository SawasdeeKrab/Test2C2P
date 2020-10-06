using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test2C2P.Api.Models
{
    public class PaymentModel
    {
        public string Id { get; set; }
        public decimal Amount { get; set; }
        public string CurrencyCode { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Status { get; set; }
    }
}