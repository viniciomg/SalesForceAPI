using MediatR;
using SalesForce.Services.Notification.Model;

namespace SalesForce.Services.Notification.Handler
{
    public class NotifyHandler : INotificationHandler<Notifications>
    {
        private List<Notifications> _notifications;
        public NotifyHandler()
        {
            _notifications = new List<Notifications>();
        }
        public Task Handle(Notifications message, CancellationToken cancellationToken)
        {
            _notifications.Add(message);
            return Task.CompletedTask;
        }

        public virtual List<Notifications> GetNotifications()
        {
            return _notifications.Where(not =>
                not.GetType() == typeof(Notifications)).ToList();
        }

        public virtual bool HasNotifications()
        {
            return GetNotifications().Any();
        }
        public void Dispose()
        {
            _notifications = new List<Notifications>();
        }
    }
}
