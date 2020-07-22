using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using RentalCar.Data;
using RentalCar.Data.VehicleData.IVehicleData;
using RentalCar.Models;
using RentalCar.Models.DTO;

namespace RentalCar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IVehicleDataRead _vehicleRead;
        private readonly IVehicleDataWrite _vehicleWrite;
        private readonly IVehicleDataRemove _vehicleRemove;
        private readonly ISave _save;

        public VehicleController(IMapper mapper, IVehicleDataRead vehicleRead, IVehicleDataWrite vehicleWrite, 
                                 IVehicleDataRemove vehicleRemove, ISave save)
        {
            _mapper = mapper;
            _vehicleRead = vehicleRead;
            _vehicleWrite = vehicleWrite;
            _vehicleRemove = vehicleRemove;
            _save = save;
        }


        [HttpGet]
        public ActionResult<IEnumerable<VehicleDTO>> GetAll()
        {
            var vehicles = _vehicleRead.GetAll();
            return  Ok(_mapper.Map<IEnumerable<VehicleReadDTO>>(vehicles));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VehicleDTO>> Get(int id)
        {
            var vehicle = await _vehicleRead.GetAsync(id);

            if(vehicle == null)
            {
                return NotFound();
            }

            return _mapper.Map<VehicleReadDTO>(vehicle);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Create(VehicleUpsertDTO vehicleDTO)
        {
            var vehicle = _mapper.Map<Vehicle>(vehicleDTO);
            var vehicleReadDTO = _mapper.Map<VehicleReadDTO>(await _vehicleWrite.Create(vehicle));
            return CreatedAtAction(nameof(Get), new { id = vehicleReadDTO.VehicleId }, vehicleReadDTO);
        }

        [HttpPatch("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Update(int id, JsonPatchDocument<VehicleUpsertDTO> patchDocument)
        {
            var vehicle = await _vehicleRead.GetAsync(id);
            if(vehicle == null)
            {
                return NotFound();
            }
            var vehicleToPatch = _mapper.Map<VehicleUpsertDTO>(vehicle);
            patchDocument.ApplyTo(vehicleToPatch, ModelState);
            if (!TryValidateModel(vehicleToPatch))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(vehicleToPatch, vehicle);
            await _save.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<VehicleDTO>> Delete(int id)
        {
            var vehicle = await _vehicleRemove.Remove(id);
            if(vehicle == null)
            {
                return NotFound();
            }
            return _mapper.Map<VehicleReadDTO>(vehicle);
        }
    }
}
