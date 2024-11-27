using MediatR;
using SalesForce.Services.Notification.Handler;
using SalesForce.Services.Notification.Interface;
using SalesForce.Services.Notification.Model;

namespace SalesForce.Services.Notification.Implementation
{
    public  class Notify :INotify
    {
        private readonly NotifyHandler _messageHandler;
        public Notify(INotificationHandler<Notifications> notification)
        {
            _messageHandler = (NotifyHandler)notification;
        }
        public Notify Invoke()
        {
            return this;
        }
        public bool IsValid()
        {
            return !_messageHandler.HasNotifications();
        }
        public void NewNotification(string key, string message)
        {
            _messageHandler.Handle(new Notifications(key, message), default(CancellationToken));
        }
    }
}
