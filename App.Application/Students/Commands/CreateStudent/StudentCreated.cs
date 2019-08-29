using App.Application.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace App.Application.Students.Commands.CreateStudent
{
    /// <summary>
    /// This Class User for Notification Service
    /// </summary>
    public class StudentCreated : INotification
    {
        public int Id { get; set; }

        public class StudentCreatedHandler : INotificationHandler<StudentCreated>
        {
            private readonly INotificationService _notificationService;

            public StudentCreatedHandler(INotificationService notificationService)
            {
                _notificationService = notificationService;
            }

            public async Task Handle(StudentCreated notification, CancellationToken cancellationToken)
            {
                await _notificationService.SendAsync("Save Success");
            }

        }
    }
}
