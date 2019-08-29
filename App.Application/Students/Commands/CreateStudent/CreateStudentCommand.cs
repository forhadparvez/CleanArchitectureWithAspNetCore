using App.Application.Interfaces;
using App.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace App.Application.Students.Commands.CreateStudent
{
    public class CreateStudentCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte Age { get; set; }
        public string Roll { get; set; }


        public class Handler : IRequestHandler<CreateStudentCommand, Unit>
        {
            private readonly IAppDbContext _context;
            private readonly IMediator _mediator;

            public Handler(IAppDbContext context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
            }

            public async Task<Unit> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
            {
                var entity = new Student
                {
                    Id = request.Id,
                    Name = request.Name,
                    Age = request.Age,
                    Roll = request.Roll
                };

                _context.Students.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);

                // for sms/ mail/ message
                await _mediator.Publish(new StudentCreated { Id = entity.Id }, cancellationToken);

                return Unit.Value;
            }
        }
    }
}
