using SalesForce.Services.Notification.Implementation;

namespace SalesForce.Services.Notification.Interface
{
    public interface INotify
    {
        Notify Invoke();
        void NewNotification(string key, string message);
       
    }
}
