using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project8_RapidApiCurrency
{
    public partial class Form1 : Form
    {

        decimal dollarRate, euroRate, gbpRate;

        private void btnCalculateClick_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtUnitAmount.Text, out decimal unitAmount))
            {
                decimal totalAmount = 0;
                if (rbUSD.Checked)
                {
                    totalAmount = unitAmount * dollarRate;
                }
                else if (rbEUR.Checked)
                {
                    totalAmount = unitAmount * euroRate;
                }
                else if(rbGBP.Checked)
                {
                    totalAmount = unitAmount * gbpRate;
                }
                else
                {
                    MessageBox.Show("Please select a currency type.");
                }

                txtTotalAmount.Text = totalAmount.ToString("N2");
            }
            else
            {
              MessageBox.Show("Please enter a valid number for the unit amount.");
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {

            #region Dollar
            var client = new HttpClient();
            var requestDollar = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://currency-converter5.p.rapidapi.com/currency/convert?format=json&from=USD&to=TRY&amount=1&language=en"),
                Headers = {
                { "x-rapidapi-key", "24d4e3b785mshe7c6175c7882943p1dafc9jsnc0d718e7d819" },
                { "x-rapidapi-host", "currency-converter5.p.rapidapi.com" },
            },
            };
            using (var response = await client.SendAsync(requestDollar))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var json = JObject.Parse(body);
                lblDollar.Text = "Dollar: " + json["rates"]["TRY"]["rate"].ToString();
                dollarRate = decimal.Parse(json["rates"]["TRY"]["rate"].ToString(), System.Globalization.CultureInfo.InvariantCulture);
            }
            #endregion

            await Task.Delay(1000);

            #region Euro
            var client2 = new HttpClient();
            var requestEuro = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://currency-converter5.p.rapidapi.com/currency/convert?format=json&from=EUR&to=TRY&amount=1&language=en"),
                Headers = {
                { "x-rapidapi-key", "24d4e3b785mshe7c6175c7882943p1dafc9jsnc0d718e7d819" },
                { "x-rapidapi-host", "currency-converter5.p.rapidapi.com" },
            },
            };
            using (var response = await client.SendAsync(requestEuro))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var json1 = JObject.Parse(body);
                lblEuro.Text = "Euro: " + json1["rates"]["TRY"]["rate"].ToString();
                euroRate = decimal.Parse(json1["rates"]["TRY"]["rate"].ToString(), System.Globalization.CultureInfo.InvariantCulture);
            }
            #endregion

            await Task.Delay(1000);

            #region GBP
            var client3 = new HttpClient();
            var requestGBP = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://currency-converter5.p.rapidapi.com/currency/convert?format=json&from=GBP&to=TRY&amount=1&language=en"),
                Headers = {
                { "x-rapidapi-key", "24d4e3b785mshe7c6175c7882943p1dafc9jsnc0d718e7d819" },
                { "x-rapidapi-host", "currency-converter5.p.rapidapi.com" },
            },
            };
            using (var response = await client.SendAsync(requestGBP))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var json2 = JObject.Parse(body);
                lblGBP.Text = "GBP: " + json2["rates"]["TRY"]["rate"].ToString();
                gbpRate = decimal.Parse(json2["rates"]["TRY"]["rate"].ToString(), System.Globalization.CultureInfo.InvariantCulture);
            }
            #endregion
        }
    }
}
