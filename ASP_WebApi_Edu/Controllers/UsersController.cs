using ASP_WebApi_Edu.Interfaces;
using ASP_WebApi_Edu.Models.Domain;
using ASP_WebApi_Edu.Models.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ASP_WebApi_Edu.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UsersController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var usersDto = await _userRepository.GetMembersAsync();

            return Ok(usersDto);
        }

        [HttpGet("{username}")]
        public async Task<IActionResult> Get([FromRoute] string username)
        {
            var userDto = await _userRepository.GetMemberAsync(username);
            return Ok(userDto);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(MemberUpdateDto memberUpdateDto)
        {
            var username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (username == null)
            {
                return BadRequest("Cant get username from token");
            }

            var user = await _userRepository.GetUserByUsernameAsync(username);

            if (user == null)
            {
                return NotFound();
            }

            _mapper.Map(memberUpdateDto, user);

            if (await _userRepository.SaveAllAsync())
            {
                return NoContent();
            }

            return BadRequest("Failed to update user");
        }
    }
}
