var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCatalogModule();
builder.Services.AddOrderModule();    
builder.Services.AddPaymentModule();
builder.Services.AddInventoryModule();

var app = builder.Build();
app.Run();