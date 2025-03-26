using CheapFlights.Domain.Contracts;
using CheapFlights.Application.Contracts;
using CheapFlights.Application.Implementation;
using CheapFlights.Infrastructure.Implementation;
using CheapFlights.Infrastructure.Cache;
using Autofac.Extensions.DependencyInjection;
using Autofac;

var builder = WebApplication.CreateBuilder(args);

// Logging
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program));

// Add services to the container.
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Services.AddControllers()
    .AddDataAnnotationsLocalization()
    .AddNewtonsoftJson();

builder.Host.ConfigureContainer<ContainerBuilder>(ContainerBuilder =>
{
    ContainerBuilder.RegisterType<CacheService>().As<ICacheService>().SingleInstance();
    ContainerBuilder.RegisterType<BookingService>().As<IBookingService>();
    ContainerBuilder.RegisterType<AvailabilityService>().As<IAvailabilityService>();
    ContainerBuilder.RegisterType<FlightService>().As<IFlightService>();
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
