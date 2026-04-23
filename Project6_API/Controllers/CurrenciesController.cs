using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project6_API.Context;
using Project6_API.Entities;

namespace Project6_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrenciesController : ControllerBase
    {

        private readonly CurrencyContext _currencyContext;

        public CurrenciesController(CurrencyContext currencyContext)
        {
            _currencyContext = currencyContext;
        }

        [HttpGet]
        public IActionResult CurrenciyList()
        {
            var values = _currencyContext.Currencies.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddCurrency(Currency currency)
        {
            _currencyContext.Currencies.Add(currency);
            _currencyContext.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCurrency(int id)
        {
            var value= _currencyContext.Currencies.Find(id);

            if (value == null)
            {
                return NotFound();
            }

            _currencyContext.Currencies.Remove(value);
            _currencyContext.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateCurrency(Currency currency)
        {
            var value = _currencyContext.Currencies.Find(currency.CurrencyID);

            if (value == null)
            {
                return NotFound("Güncellenmek istenen döviz bulunamadı.");
            }

            value.CurrencyCode = currency.CurrencyCode;
            value.ExchangeRate = currency.ExchangeRate;

            _currencyContext.SaveChanges();
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetByIdCurrency(int id)
        {
            var value = _currencyContext.Currencies.Find(id);

            if (value == null)
            {
                return NotFound("Aranan döviz bulunamadı.");
            }

            return Ok(value);
        }

        [HttpGet("TotalCurrencyCount")]
        public IActionResult TotalCurrencyCount()
        {
            var value = _currencyContext.Currencies.Count();
            return Ok(value);
        }

        [HttpGet("MaxExchangeRate")]
        public IActionResult MaxExchangeRate()
        {
            var value = _currencyContext.Currencies.OrderByDescending(x => x.ExchangeRate).Select(y => y.CurrencyCode).FirstOrDefault();

            if (value == null)
            {
                return NotFound("Veritabanında herhangi bir döviz kaydı bulunamadı.");
            }
            return Ok(value);
        }
    }
}
