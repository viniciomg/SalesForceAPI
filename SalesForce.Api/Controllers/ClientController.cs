using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SalesForce.Api.Controllers.Base;
using SalesForce.Domain.Interfaces.Services;
using SalesForce.Services.Notification.Model;

namespace SalesForce.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    //[Authorize]

    public class ClientController : BaseController
    {
        private readonly IClientService _clientService;
        public ClientController(INotificationHandler<Notifications> notification, 
                                IClientService clientService) : base(notification)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClients() => 
            ResponseOkResult(await _clientService.GetAllClients());

    }
}
