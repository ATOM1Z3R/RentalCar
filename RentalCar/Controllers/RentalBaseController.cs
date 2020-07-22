using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using RentalCar.Data;
using RentalCar.Data.RentalBaseData.IRentalBaseData;
using RentalCar.Models;
using RentalCar.Models.DTO;

namespace RentalCar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalBaseController : ControllerBase
    {
        private readonly IRentalBaseDataRead _rentalBaseRead;
        private readonly IRentalBaseDataWrite _rentalBaseWrite;
        private readonly IRentalBaseDataRemove _rentalBaseRemove;
        private readonly IMapper _mapper;
        private readonly ISave _save;

        public RentalBaseController(IRentalBaseDataRead rentalBaseRead, IRentalBaseDataWrite rentalBaseWrite,
                                    IRentalBaseDataRemove rentalBaseRemove, IMapper mapper, ISave save)
        {
            _rentalBaseRead = rentalBaseRead;
            _rentalBaseWrite = rentalBaseWrite;
            _rentalBaseRemove = rentalBaseRemove;
            _mapper = mapper;
            _save = save;
        }

        [HttpGet]
        public ActionResult<IEnumerable<RentalBaseDTO>> GetAll()
        {
            var rentalBases = _rentalBaseRead.GetAll();
            return Ok(_mapper.Map<IEnumerable<RentalBaseReadDTO>>(rentalBases));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RentalBaseDTO>> Get(int id)
        {
            var rentalBase = await _rentalBaseRead.GetAsync(id);
            if (rentalBase == null)
            {
                return NotFound();
            }
            return _mapper.Map<RentalBaseReadDTO>(rentalBase);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Create(RentalBaseUpsertDTO rentalBaseWriteDTO)
        {
            var rentalBase = await _rentalBaseWrite.Create(_mapper.Map<RentalBase>(rentalBaseWriteDTO));
            return CreatedAtAction(nameof(Get), new { id = rentalBase.RentalBaseId }, _mapper.Map<RentalBaseReadDTO>(rentalBase));
        }

        [HttpPatch("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Update(int id, JsonPatchDocument<RentalBaseUpsertDTO> patchDocument)
        {
            var rentalBase = await _rentalBaseRead.GetAsync(id);
            if(rentalBase == null)
            {
                return NotFound();
            }
            var rentalBasePatch = _mapper.Map<RentalBaseUpsertDTO>(rentalBase);
            patchDocument.ApplyTo(rentalBasePatch, ModelState);
            if (!TryValidateModel(patchDocument))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(rentalBasePatch, rentalBase);
            await _save.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<RentalBaseReadDTO>> Delete(int id)
        {
            var rentalBase = await _rentalBaseRemove.Remove(id);
            if(rentalBase == null)
            {
                return NotFound();
            }
            return _mapper.Map<RentalBaseReadDTO>(rentalBase);
        }

    }
}
