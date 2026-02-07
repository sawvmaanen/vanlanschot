using Microsoft.OpenApi;
using VanLanschot.Adapters.Data;
using VanLanschot.Adapters.Handlers;
using VanLanschot.Core;
using VanLanschot.Core.Ports;
using VanLanschot.ServiceDefaults;

var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire client integrations.
builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddProblemDetails();
builder.Services.AddControllers();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "VanLanschot Stock API", Version = "v1" });
});


builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<GetFundsHandler>());

// Custom services.
builder.Services.AddScoped<IFundsService, FundsService>();
builder.Services.AddScoped<IPortfolioService, PortfolioService>();
builder.Services.AddScoped<IStockService, StockService>();

builder.Services.AddSingleton<IFundsRepository, FundsRepository>();
builder.Services.AddSingleton<ISharesRepository, SharesRepository>();
builder.Services.AddSingleton<IStockValuesRepository, StockValuesRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler();
app.UseRouting();
app.MapControllers();
app.MapDefaultEndpoints();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("v1/swagger.json", "VanLanschot Stock API V1");
});

app.Run();
