using Microsoft.EntityFrameworkCore;
using Modules.Catalog;
using Modules.Order;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CatalogDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddDbContext<OrderDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddScoped<ProductService>();
builder.Services.AddMediatR(typeof(CreateOrderHandler));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/products", async (ProductService service)
    => await service.GetAllAsync());

app.MapPost("/products", async (ProductService service, Product product) =>
{
    await service.AddAsync(product);
    return Results.Ok();
});

app.MapPost("/orders", async (IMediator mediator, CreateOrderCommand command)
    => await mediator.Send(command));

app.Run();