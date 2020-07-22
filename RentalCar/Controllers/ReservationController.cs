using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using RentalCar.Data;
using RentalCar.Data.ReservationData.IReservationData;
using RentalCar.Data.VehicleData.IVehicleData;
using RentalCar.Models;
using RentalCar.Models.DTO;

namespace RentalCar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationDataRemove _reservationRemove;
        private readonly IVehicleDataRead _vehicleRead;
        private readonly IReservationDataRead _reservationRead;
        private readonly IReservationDataWrite _reservationWrite;
        private readonly IVehicleSetAvailability _vehicleSet;
        private readonly IMapper _mapper;
        private readonly IReservationReadUserRecords _userRecords;
        private readonly ISave _save;

        public ReservationController(IReservationDataRead reservationRead, IVehicleDataRead vehicleRead,
                                     IReservationDataWrite reservationWrite, IReservationDataRemove reservationRemove,
                                     IVehicleSetAvailability vehicleSet, IMapper mapper, ISave save,
                                     IReservationReadUserRecords userRecords)
        {
            _reservationRemove = reservationRemove;
            _vehicleRead = vehicleRead;
            _reservationRead = reservationRead;
            _reservationWrite = reservationWrite;
            _vehicleSet = vehicleSet;
            _mapper = mapper;
            _userRecords = userRecords;
            _save = save;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult<IEnumerable<ReservationDTO>> GetAll()
        {
            return Ok(_mapper.Map<IEnumerable<ReservationReadDTO>>(_reservationRead.GetAll()));
        }

        [HttpGet]
        [Route("MyReservations")]
        [Authorize]
        public ActionResult<IEnumerable<ReservationDTO>> GetAllLoggedUserReservations()
        {
            var vehicles = _userRecords.GetUserRes(User.Claims.First(x => x.Type == "UserID").Value);
            return Ok(_mapper.Map<IEnumerable<ReservationReadDTO>>(vehicles));
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        [Route("UserReservation/{id}")]
        public async Task<ActionResult<ReservationDTO>> Get(int id)
        {
            var reservation = await _reservationRead.GetAsync(id);
            return _mapper.Map<ReservationReadDTO>(reservation);
            
        }

        [HttpGet("{id}")]
        [Route("MyReservation/{id}")]
        public async Task<ActionResult<ReservationDTO>> GetUserReservation(int id)
        {
            var reservation = await _reservationRead.GetAsync(id);
            if (reservation.UserId == User.Claims.First(x => x.Type == "UserID").Value)
            {
                return _mapper.Map<ReservationReadDTO>(reservation);
            }
            return Forbid();
        }

        [HttpPost("{id}")] //vehicle id
        public async Task<ActionResult> MakeReservation(int id, ReservationUpsertDTO reservationDTO)
        {
            var vehicle = await _vehicleRead.GetAsync(id);
            var reservation = new Reservation
            {
                RentDate = reservationDTO.RentDate,
                ExpectingRetriveDate = reservationDTO.RentDate.AddDays(reservationDTO.NumberOfDays),
                ActualRetriveDate = null,
                NumberOfDays = reservationDTO.NumberOfDays,
                VehicleId = vehicle.VehicleId,
                UserId = User.Claims.First(x => x.Type == "UserID").Value
            };
            _vehicleSet.ChangeAvailability(vehicle);
            await _reservationWrite.MakeReservationAsync(reservation);
            return CreatedAtAction(nameof(Get), new { id = reservation.ReservationId }, _mapper.Map<ReservationReadDTO>(reservation));
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        [Route("ConfirmRetriveDate/{id}")]
        public async Task<ActionResult> ConfirmRetriveDate(int id)
        {
            var reservation = await _reservationRead.GetAsync(id);
            if (reservation == null)
                return NotFound();
            reservation.ActualRetriveDate = DateTime.Now;
            _vehicleSet.ChangeAvailability(reservation.Vehicle);
            await _save.SaveChangesAsync();
            return Ok();
        }



        [HttpPatch("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Update(int id, JsonPatchDocument<ReservationUpsertDTO> patchDocument)
        {
            var reservation = await _reservationRead.GetAsync(id);
            if(reservation == null)
            {
                return NotFound();
            }
            var reservationToPatch = _mapper.Map<ReservationUpsertDTO>(reservation);
            patchDocument.ApplyTo(reservationToPatch, ModelState);
            if (!TryValidateModel(reservationToPatch))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(reservationToPatch, reservation);
            await _save.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete]
        [Authorize(Roles = "Adimn")]
        public async Task<ActionResult<ReservationDTO>> Remove(int id)
        {
            var reservation = await _reservationRemove.Remove(id);
            if(reservation == null)
            {
                return NotFound();
            }
            return _mapper.Map<ReservationReadDTO>(reservation);
        }
    }
}
