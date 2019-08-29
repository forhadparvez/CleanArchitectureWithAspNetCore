using App.Application.Notifications.Models;
using System.Threading.Tasks;

namespace App.Application.Interfaces
{
    public interface INotificationService
    {
        Task SendAsync(Message message);

        Task SendAsync(string message);
    }
}
