using System.Threading;
using System.Threading.Tasks;
using App.Application.Interfaces;
using App.Application.Students.Commands.CreateStudent;
using MediatR;

namespace App.Application.Departments.Commands.CreateDepartment
{
    public class DepartmentCreated : INotification
    {
        public int Id { get; set; }

        public class DepartmentCreatedHandler : INotificationHandler<DepartmentCreated>
        {
            private readonly INotificationService _notificationService;

            public DepartmentCreatedHandler(INotificationService notificationService)
            {
                _notificationService = notificationService;
            }

            public async Task Handle(DepartmentCreated notification, CancellationToken cancellationToken)
            {
                await _notificationService.SendAsync("Save Success");
            }

        }
    }
}