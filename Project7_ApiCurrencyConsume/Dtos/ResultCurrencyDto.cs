using System;
using System.Collections.Generic;
using System.Text;

namespace Project7_ApiCurrencyConsume.Dtos
{
    public class ResultCurrencyDto
    {
        public int currencyID { get; set; }
        public string currencyCode { get; set; }
        public decimal exchangeRate { get; set; }
    }
}
