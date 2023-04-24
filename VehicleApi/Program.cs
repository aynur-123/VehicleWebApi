using Microsoft.EntityFrameworkCore;
using VehicleApi;
using VehicleApi.Entities;
using VehicleApi.Services;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<VehicleDbContext>(opt => opt.UseInMemoryDatabase("vehicleDatabase"));
builder.Services.AddScoped<IVehicleService, VehicleService>();

var app = builder.Build();
AddVehicleData(app);


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

static void AddVehicleData(WebApplication app)
{
    var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetService<VehicleDbContext>();

    int index = 1;

    var car = new Car
    {
        Id = index++,
        Color = "Red",
        IsOnHeadlight = true,
        WheelCount = 4
    };

    var carTwo = new Car
    {
        Id = index++,
        Color = "Red",
        IsOnHeadlight = true,
        WheelCount = 4
    };

    var bus = new Bus
    {
        Id = index++,
        Color = "Blue",
        IsOnHeadlight = false,
        WheelCount = 4
    };

    var boat = new Boat
    {
        Id=index++,
        Color ="Black",
        Width = 5
    };



    db.Cars.Add(car);
    db.Cars.Add(carTwo);

    db.Buses.Add(bus);
    db.Boats.Add(boat);
    db.SaveChanges();
}

