using InventoryModule.Core;
using OrderModule.Core;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Modüllerin Kendi IoC'lerini (Composition Root) Tetikliyoruz
builder.Services.AddInventoryModule(connectionString);
builder.Services.AddOrderModule(connectionString);

var app = builder.Build();

app.Run();