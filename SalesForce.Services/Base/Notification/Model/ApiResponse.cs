namespace SalesForce.Services.Notification.Model;

public class ApiResponse
{
    public string StatusCode { get; set; }
    public List<Notifications> Notifications { get; set; }

    public ApiResponse(string statusCode, List<Notifications> notifications)
    {
        StatusCode = statusCode;
        Notifications = notifications;
    }
}
