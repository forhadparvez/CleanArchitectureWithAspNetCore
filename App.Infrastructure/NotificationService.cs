using App.Application.Interfaces;
using App.Application.Notifications.Models;
using System.Threading.Tasks;

namespace App.Infrastructure
{
    public class NotificationService : INotificationService
    {
        public Task SendAsync(Message message)
        {
            return Task.CompletedTask;
        }

        public Task SendAsync(string message)
        {
            return Task.CompletedTask;
        }
    }
}
