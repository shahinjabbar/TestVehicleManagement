using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using VehicleManagament.API.DTO;
using VehicleManagament.API.Repositories;
using VehicleManagement.Data.Entities;

namespace VehicleManagament.API.Controllers
{
    [Route("api/vehicles")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleRepository _vehicleRepository;

        public VehicleController(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Vehicle))]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var result = await _vehicleRepository.GetById(id);
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Vehicle>))]
        public async Task<IActionResult> Get()
        {
            var result = await _vehicleRepository.GetAll();
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        public async Task<IActionResult> Post([FromBody] VehicleDTO vehicledto)
        {
            var result = await _vehicleRepository.Create(vehicledto);
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _vehicleRepository.Delete(id);
            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id,[FromBody] VehicleDTO vehicleDTO )
        {
            await _vehicleRepository.Update(id,vehicleDTO);
            return Ok();
        }
    }
}
