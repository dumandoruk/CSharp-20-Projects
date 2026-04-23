using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Project7_ApiCurrencyConsume.Dtos;
using System.Net.Http.Headers;



string url = "https://localhost:7058/api/Currencies";
using HttpClient client = new HttpClient();
HttpResponseMessage response= new HttpResponseMessage();

while (true)
{
    Console.WriteLine("Api Consume İşlemine Hoş Geldiniz.");
    Console.WriteLine();
    Console.WriteLine("### Yapmak İstediğiniz İşlemi Seçiniz ###");
    Console.WriteLine();
    Console.WriteLine("1-Döviz Kurları");
    Console.WriteLine("2-Yeni Döviz Kuru Ekle");
    Console.WriteLine("3-Döviz Silme İşlemi");
    Console.WriteLine("4-Döviz Güncelleme İşlemi");
    Console.WriteLine("5-ID'ye Göre Döviz Getirme");
    Console.WriteLine("6-Çıkış");
    Console.WriteLine();
    Console.Write("Tercihiniz: ");
    string number = Console.ReadLine();

    if (number == "1")
    {

        response = await client.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {

            if (response.IsSuccessStatusCode) { 
                string responseBody = await response.Content.ReadAsStringAsync();

            var values = JsonConvert.DeserializeObject<List<ResultCurrencyDto>>(responseBody);

            Console.WriteLine("-----------------------------------------");
            Console.WriteLine(string.Format("{0,-5} | {1,-10} | {2,-10}", "ID", "Code", "Rate"));
            Console.WriteLine("-----------------------------------------");

            foreach (var item in values)
            {
                Console.WriteLine(string.Format("{0,-5} | {1,-10} | {2,-10}",
                    item.currencyID,
                    item.currencyCode,
                    item.exchangeRate));
            }

            }
            else
            {
                Console.WriteLine("API ile bağlantı kurulamadı. Durum Kodu: " + response.StatusCode);
            }
        }

    }

    else if (number == "2")
    {
        Console.Write("Döviz Kodunu Giriniz (Örn: USD): ");
        string code = Console.ReadLine();

        Console.Write("Kur Değerini Giriniz: ");
        decimal rate = decimal.Parse(Console.ReadLine());

        var newCurrency = new CreateCurrencyDto
        {
            currencyCode = code.ToUpper(),
            exchangeRate = rate
        };

        string json = JsonConvert.SerializeObject(newCurrency);
        StringContent content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

        response = await client.PostAsync(url, content);

        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine("Döviz kuru başarıyla eklendi!");
        }
        else
        {
            Console.WriteLine("Hata oluştu: " + response.StatusCode);
        }
    }

    else if (number == "3")
    {
        Console.Write("Silmek İstediğiniz Döviz ID Değerini Giriniz: ");
        string id = Console.ReadLine();

        response = await client.DeleteAsync($"{url}/{id}");

        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine("\n[!] Döviz başarıyla silindi.");
        }
        else
        {
            Console.WriteLine("\n[!] Silme işlemi başarısız. Durum: " + response.StatusCode);
        }
    }

    else if (number == "4")
    {
        Console.Write("Güncellenecek ID: ");
        int id = int.Parse(Console.ReadLine());
        Console.Write("Yeni Kod: ");
        string code = Console.ReadLine();
        Console.Write("Yeni Kur: ");
        decimal rate = decimal.Parse(Console.ReadLine());

        var updateDto = new UpdateCurrencyDto { currencyID = id, currencyCode = code.ToUpper(), exchangeRate = rate };
        var json = JsonConvert.SerializeObject(updateDto);
        var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

        response = await client.PutAsync(url, content);
        if (response.IsSuccessStatusCode) Console.WriteLine("\n[!] Güncelleme Tamamlandı.");
    }

    else if (number == "5")
    {
        Console.Write("Getirmek İstediğiniz ID: ");
        string id = Console.ReadLine();

        response = await client.GetAsync($"{url}/{id}");

        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            // DİKKAT: Burada List değil, tek bir nesne (Single Object) bekliyoruz
            var value = JsonConvert.DeserializeObject<GetByIdCurrencyDto>(jsonData);

            Console.WriteLine("\n--- Aranan Döviz ---");
            Console.WriteLine($"ID: {value.currencyID} | Kod: {value.currencyCode} | Kur: {value.exchangeRate}");
        }
    }

    else if (number == "6")
    {
        Console.WriteLine("\n[!] API Consumer Sistemi Kapatılıyor...");
        Console.WriteLine("İyi çalışmalar dileriz. Görüşmek üzere!");
        Thread.Sleep(1500);
        Environment.Exit(0);
    }

    Console.WriteLine("\n-----------------------------------------");
    Console.WriteLine("Ana menüye dönmek için herhangi bir tuşa basın...");
    Console.ReadKey();
}