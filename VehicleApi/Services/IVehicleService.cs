using VehicleApi.Entities;

namespace VehicleApi.Services;

public interface IVehicleService
{
    Task<List<Car>> GetCarsByColor(string color);
    Task<List<Bus>> GetBusesByColor(string color);
    Task<List<Boat>> GetBoatsByColor(string color);
    Task TurnOnOrOffHeadLightsOfCarById(int id);
    Task DeleteCarById(int id);
}
