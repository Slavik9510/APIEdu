using ASP_WebApi_Edu.Extensions;
using ASP_WebApi_Edu.Helpers;
using ASP_WebApi_Edu.Interfaces;
using ASP_WebApi_Edu.Models.Domain;
using ASP_WebApi_Edu.Models.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASP_WebApi_Edu.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    [ServiceFilter(typeof(LogUserActivity))]
    public class MessagesController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IMessageRepository _messageRepository;
        private readonly IMapper _mapper;

        public MessagesController(IUserRepository userRepository, IMessageRepository messageRepository,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _messageRepository = messageRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMessage(CreateMessageDto createMessageDto)
        {
            var username = User.GetUsername();

            if (username == createMessageDto.RecepientUsername.ToLower())
            {
                return BadRequest("You cannot send messages to yourself");
            }

            var sender = await _userRepository.GetUserByUsernameAsync(username);
            var recepient = await _userRepository.GetUserByUsernameAsync(createMessageDto.RecepientUsername);

            if (recepient == null)
            {
                return NotFound();
            }

            var message = new Message()
            {
                Sender = sender,
                Recepient = recepient,
                SenderUsername = sender.Username,
                RecepientUsername = recepient.Username,
                Content = createMessageDto.Content
            };

            _messageRepository.AddMessage(message);

            if (await _messageRepository.SaveAllAsync())
            {
                return Ok(_mapper.Map<MessageDto>(message));
            }

            return BadRequest("Failed to sent message");
        }

        [HttpGet]
        public async Task<IActionResult> GetMessagesForUser([FromQuery] MessageParams messageParams)
        {
            messageParams.Username = User.GetUsername();

            var messages = await _messageRepository.GetMessagesForUser(messageParams);

            Response.AddPaginationHeader(new PaginationHeader(messages.CurrentPage, messages.PageSize,
                messages.TotalCount, messages.TotalPages));

            return Ok(messages);
        }

        [HttpGet("thread/{username}")]
        public async Task<IActionResult> GetMessagesForUser(string username)
        {
            var currentUsername = User.GetUsername();

            var messagesThread = await _messageRepository.GetMessagesThread(currentUsername, username);

            return Ok(messagesThread);
        }
    }
}
