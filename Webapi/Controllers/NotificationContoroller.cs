using MassTransit;
using Microsoft.AspNetCore.Mvc;

using Shared;
using Webapi.Models;

namespace webapi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NotificationController(IPublishEndpoint publishEndpoint) : ControllerBase
{
    public readonly IPublishEndpoint publishEndpoint = publishEndpoint;

    [HttpPost]
    public async Task<IActionResult> Notify(NotificationTransactionDto notificationDto)
    {
        await publishEndpoint.Publish<INotificationTransaction>(new {
            notificationDto.NotificationDate,
            notificationDto.NotificationMessage,
            notificationDto.NotificationType
        });

        return Ok();
    }
}