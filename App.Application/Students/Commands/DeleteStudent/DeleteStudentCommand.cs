using App.Application.Exceptions;
using App.Application.Interfaces;
using App.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace App.Application.Students.Commands.DeleteStudent
{
    public class DeleteStudentCommand : IRequest
    {
        public int Id { get; set; }


        public class Handler : IRequestHandler<DeleteStudentCommand>
        {
            private readonly IAppDbContext _context;

            public Handler(IAppDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.Students
                    .FindAsync(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Student), request.Id);
                }

                _context.Students.Remove(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
