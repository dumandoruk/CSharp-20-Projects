using System;
using System.Collections.Generic;
using System.Text;

namespace Project7_ApiCurrencyConsume.Dtos
{
    public class CreateCurrencyDto
    {
        public string currencyCode{ get; set; }
        public decimal exchangeRate{ get; set; }
    }
}
