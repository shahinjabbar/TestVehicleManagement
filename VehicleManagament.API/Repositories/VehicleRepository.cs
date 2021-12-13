using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using VehicleManagament.API.DTO;
using VehicleManagement.Data;
using VehicleManagement.Data.Entities;

namespace VehicleManagament.API.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly VehicleDbContext _vehicleDbContext;

        public VehicleRepository(VehicleDbContext vehicleDbContext)
        {
            _vehicleDbContext = vehicleDbContext;
        }
        public async Task<int> Create(VehicleDTO vehicle)
        {
            try
            {
                var newVehicle = new Vehicle()
                {
                    Color = vehicle.Color,
                    Equipment = vehicle.Equipment,
                    Make = vehicle.Make,
                    Model = vehicle.Model,
                    Price = vehicle.Price,
                };

                await _vehicleDbContext.Vehicles.AddAsync(newVehicle);
                await _vehicleDbContext.SaveChangesAsync();
                return newVehicle.Id;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                var vehicleExists = _vehicleDbContext.Vehicles.Any(x => x.Id == id);

                if (!vehicleExists)
                {
                    throw new ValidationException($"Vehicle with Id={id} does not exists");
                }

                var existingVehicle = await _vehicleDbContext.Vehicles.FirstOrDefaultAsync(x => x.Id == id);
                _vehicleDbContext.Remove(existingVehicle);
                await _vehicleDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Vehicle>> GetAll()
        {
            var query = _vehicleDbContext.Vehicles.AsQueryable();

            return await query.ToListAsync();
        }

        public async Task<Vehicle> GetById(int id)
        {
            try
            {
                var vehicleExists = _vehicleDbContext.Vehicles.Any(x => x.Id == id);

                if (!vehicleExists)
                {
                    throw new ValidationException($"Vehicle with Id={id} does not exists");
                }

                var vehicle = await _vehicleDbContext.Vehicles.FirstOrDefaultAsync(x => x.Id == id);

                return vehicle;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task Update(int id, VehicleDTO vehicle)
        {
            try
            {
                var vehicleExists = _vehicleDbContext.Vehicles.Any(x => x.Id == id);

                if (!vehicleExists)
                {
                    throw new ValidationException($"Vehicle with Id={id} does not exists");
                }

                var existingVehicle = await _vehicleDbContext.Vehicles.FirstOrDefaultAsync(x => x.Id == id);

                existingVehicle.Make = vehicle.Make;
                existingVehicle.Model = vehicle.Model;
                existingVehicle.Equipment = vehicle.Equipment;
                existingVehicle.Price = vehicle.Price;
                existingVehicle.Color = vehicle.Color;

                _vehicleDbContext.Update(existingVehicle);
                await _vehicleDbContext.SaveChangesAsync();

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
