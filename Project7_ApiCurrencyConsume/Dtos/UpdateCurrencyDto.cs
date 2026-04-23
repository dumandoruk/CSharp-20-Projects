using System;
using System.Collections.Generic;
using System.Text;

namespace Project7_ApiCurrencyConsume.Dtos
{
    public class UpdateCurrencyDto
    {
        public int currencyID { get; set; }
        public string currencyCode { get; set; }
        public decimal exchangeRate { get; set; }
    }
}
