using MediatR;
using Microsoft.AspNetCore.Mvc;
using SalesForce.Services.Notification.Handler;
using SalesForce.Services.Notification.Model;
using System.Net;

namespace SalesForce.Api.Controllers.Base
{
    public class BaseController : Controller
    {
        private readonly NotifyHandler _messageHandler;

        protected BaseController(INotificationHandler<Notifications> notification)
        {
            _messageHandler = (NotifyHandler)notification;
        }
        protected IActionResult CreatedResponseOnPostAsync(string route, object result = null)
        {
            if (!HasNotifications())
            {
                if (result != null)
                    return Created(Url.Action(), new
                    {
                        success = true,
                        data = result
                    });

                return Created(route, new
                {
                    success = true
                });
            }

            return NoticationsEntity();
        }
        protected IActionResult ResponseOkResult(object result = null)
        {
            if (!HasNotifications())
            {
                if (result != null)
                    return Ok(new
                    {
                        success = true,
                        data = result
                    });

                return Ok(new
                {
                    success = true
                });

            }
            return NoticationsEntity();
        }
        protected IActionResult ResponseOkResultLookup(object result = null)
        {
            if (result != null)
                return Ok(new
                {
                    success = true,
                    items = result
                });

            return Ok(new
            {
                success = true
            });
        }

        protected bool HasNotifications()
        {
            return _messageHandler.HasNotifications();
        }

        protected IActionResult NoticationsEntity()
        {
            var notifications =
                _messageHandler.GetNotifications();

            if (notifications.Any())
            {
                return BadRequest(new ApiResponse(HttpStatusCode.BadRequest.ToString(), notifications.ToList()));
            }

            return BadRequest(new ApiResponse(HttpStatusCode.BadRequest.ToString(), notifications.ToList()));
        }
    }
}
