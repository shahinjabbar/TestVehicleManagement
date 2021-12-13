using System.Threading.Tasks;
using System.Collections.Generic;
using VehicleManagament.API.DTO;
using VehicleManagement.Data.Entities;

namespace VehicleManagament.API.Repositories
{
    public interface IVehicleRepository
    {
        Task<int> Create(VehicleDTO vehicle);
        Task Update(int id, VehicleDTO vehicle);
        Task Delete(int id);
        Task<Vehicle> GetById(int id);
        Task<IEnumerable<Vehicle>> GetAll();
    }
}
