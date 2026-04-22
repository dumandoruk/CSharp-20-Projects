
using Project6_API.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer(); // Bunu ekle
builder.Services.AddSwaggerGen();           // Swagger jeneratörünü ekle
builder.Services.AddDbContext<CurrencyContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();   // Swagger JSON dosyasını oluşturur
    app.UseSwaggerUI(); // İŞTE BU! Görsel arayüzü (UI) açan satır
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
