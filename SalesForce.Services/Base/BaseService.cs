using MediatR;
using SalesForce.Services.Notification.Handler;
using SalesForce.Services.Notification.Implementation;
using SalesForce.Services.Notification.Model;

namespace SalesForce.Services.Base;
public class BaseService<TEntity>
{
    public Notify _notify;
    private readonly NotifyHandler _messageHandler;

    public BaseService(Notify notify, INotificationHandler<Notifications> notification)
    {
        _notify = notify.Invoke();
        _messageHandler = (NotifyHandler)notification; ;
    }
    public bool HasNotifications()
    {
        return _messageHandler.HasNotifications();
    }
}
