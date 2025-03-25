using CheapFlights.Domain.Contracts;
using CheapFlights.Application.Contracts;
using CheapFlights.Application.Implementation;
using CheapFlights.Infrastructure.Implementation;
using CheapFlights.Infrastructure.Cache;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<ICacheService, CacheService>();
builder.Services.AddTransient<IBookingService, BookingService>();
builder.Services.AddTransient<IAvailabilityService, AvailabilityService>();
builder.Services.AddTransient<IFlightService, FlightService>();
builder.Services.AddControllers().AddNewtonsoftJson();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program));

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
