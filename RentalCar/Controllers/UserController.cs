using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using RentalCar.Data;
using RentalCar.Data.UserData.IUserData;
using RentalCar.Models;
using RentalCar.Models.DTO;

namespace RentalCar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserDataLogin _userDataLogin;
        private readonly IUserDataRead _userDataRead;
        private readonly IUserDataRemove _userRemove;
        private readonly IMapper _mapper;
        private readonly ISave _save;
        private readonly IUserDataRegister _userDataRegister;

        public UserController(IUserDataLogin userDataLogin, IUserDataRegister userDataRegister, 
                              IUserDataRead userDataRead, IUserDataRemove userRomove, ISave save, IMapper mapper)
        {
            _userDataRegister = userDataRegister;
            _userDataLogin = userDataLogin;
            _userDataRead = userDataRead;
            _userRemove = userRomove;
            _mapper = mapper;
            _save = save;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(UserRegisterModel userModel)
        {
            var user = new User
            {
                UserName = userModel.UserName,
                Email = userModel.Email,
                EmailConfirmed = true,
                PhoneNumber = userModel.PhoneNumber,
                PhoneNumberConfirmed = true,
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                Address = userModel.Address,
                City = userModel.City
            };
            var result = await _userDataRegister.UserRegisterAsync(user, userModel.Password);
            return Ok(result);
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(UserLogin userLogin)
        {
            var token = await _userDataLogin.LoginAsync(userLogin);
            if(token == null)
            {
                return BadRequest();
            }
            return Ok(token);
        }

        [HttpGet]
        [Route("MyData")]
        [Authorize]
        public async Task<ActionResult<UserDTO>> LoggedUserData()
        {
            var user = await _userDataRead.GetAsync(User.Claims.First(x => x.Type == "UserID").Value);
            if (user == null)
                return NotFound();
            return _mapper.Map<UserReadDTO>(user);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<UserDTO>> UserData(string id)
        {
            var user = await _userDataRead.GetAsync(id);
            if (user == null)
                return NotFound();
            return _mapper.Map<UserReadDTO>(user);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<UserDTO>> UserRemove(string id)
        {
            var user = await _userRemove.Remove(id);
            if (user == null)
                return NotFound();
            return _mapper.Map<UserReadDTO>(user);
        }

        [HttpPatch("{id}")]
        [Authorize(Roles = "Admin")]
        [Route("DataUpdate/{id}")]
        public async Task<IActionResult> UserUpdate(string id, JsonPatchDocument<UserUpdateDTO> patchDocument)
        {
            var user = await _userDataRead.GetAsync(id);
            if (user == null)
                return NotFound();
            var userToPatch = _mapper.Map<UserUpdateDTO>(user);
            patchDocument.ApplyTo(userToPatch, ModelState);
            if (!TryValidateModel(userToPatch))
                return ValidationProblem(ModelState);
            _mapper.Map(userToPatch, user);
            await _save.SaveChangesAsync();
            return NoContent();
        }

        [HttpPatch]
        [Authorize]
        [Route("MyDataUpdate")]
        public async Task<IActionResult> SelfUserUpdate(JsonPatchDocument<UserUpdateDTO> patchDocument)
        {
            var user = await _userDataRead.GetAsync(User.Claims.First(x => x.Type == "UserID").Value);
            
            if (user == null)
                return NotFound();
            var userToPatch = _mapper.Map<UserUpdateDTO>(user);
            patchDocument.ApplyTo(userToPatch, ModelState);
            if (!TryValidateModel(userToPatch))
                return ValidationProblem(ModelState);
            _mapper.Map(userToPatch, user);
            await _save.SaveChangesAsync();
            return NoContent();
        }
    }
}
