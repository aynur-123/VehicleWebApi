using Microsoft.EntityFrameworkCore;
using VehicleApi.Entities;

namespace VehicleApi.Services;

public class VehicleService : IVehicleService
{
    private readonly VehicleDbContext _vehicleDbContext;

    public VehicleService(VehicleDbContext vehicleDbContext)
    {
        _vehicleDbContext = vehicleDbContext;
    }

    public async Task<List<Car>> GetCarsByColor(string color)
    {
        var list = await _vehicleDbContext.Cars.Where(x => x.Color.ToLower() == color.ToLower()).ToListAsync();
        return list;
    }

    public async Task<List<Bus>> GetBusesByColor(string color)
    {
        var list = await _vehicleDbContext.Buses.Where(x => x.Color.ToLower() == color.ToLower()).ToListAsync();
        return list;
    }

    public async Task<List<Boat>> GetBoatsByColor(string color)
    {
        var list = await _vehicleDbContext.Boats.Where(x => x.Color.ToLower() == color.ToLower()).ToListAsync();
        return list;
    }

    public async Task TurnOnOrOffHeadLightsOfCarById(int id)
    {
        var car = await _vehicleDbContext.Cars.FirstOrDefaultAsync(x => x.Id == id);
        if (car == null)
            return;

        car.IsOnHeadlight = !car.IsOnHeadlight;
        await _vehicleDbContext.SaveChangesAsync();
    }

    public async Task DeleteCarById(int id)
    {
        var car = await _vehicleDbContext.Cars.FirstOrDefaultAsync(x=> x.Id == id);
        if (car != null)
        {
            _vehicleDbContext.Remove(car);
            await _vehicleDbContext.SaveChangesAsync();
        }
    }

}
