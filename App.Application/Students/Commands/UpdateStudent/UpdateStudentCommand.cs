using App.Application.Exceptions;
using App.Application.Interfaces;
using App.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace App.Application.Students.Commands.UpdateStudent
{
    public class UpdateStudentCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte Age { get; set; }
        public string Roll { get; set; }

        public class Handler : IRequestHandler<UpdateStudentCommand>
        {
            private readonly IAppDbContext _context;

            public Handler(IAppDbContext context)
            {
                _context = context;
            }


            public async Task<Unit> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.Students
                    .SingleOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Student), request.Id);
                }

                entity.Name = request.Name;
                entity.Age = request.Age;
                entity.Roll = request.Roll;

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
