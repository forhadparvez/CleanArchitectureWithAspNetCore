using System.Threading;
using System.Threading.Tasks;
using App.Application.Interfaces;
using App.Domain.Entities;
using MediatR;

namespace App.Application.Departments.Commands.CreateDepartment
{
    public class CreateDepartmentCommand:IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Code { get; set; }


        public class Handler:IRequestHandler<CreateDepartmentCommand, Unit>
        {
            private readonly IAppDbContext _context;
            private readonly IMediator _mediator;

            public Handler(IAppDbContext context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
            }

            public async Task<Unit> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
            {
                var entity = new Department()
                {
                    Name = request.Name,
                    ShortName = request.ShortName,
                    Code = request.Code
                };

                _context.Departments.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);
                await _mediator.Publish(new DepartmentCreated() { Id = entity.Id }, cancellationToken);

                return Unit.Value;
            }
        }
    }
}