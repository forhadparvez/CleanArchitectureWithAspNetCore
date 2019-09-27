using System.Threading;
using System.Threading.Tasks;
using App.Application.Exceptions;
using App.Application.Interfaces;
using App.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace App.Application.Departments.Commands.UpdateStudent
{
    public class UpdateDepartmentCommand:IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Code { get; set; }

        public class Handler :IRequestHandler<UpdateDepartmentCommand>
        {
            private readonly IAppDbContext _context;

            public Handler(IAppDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.Departments
                    .SingleOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Department), request.Id);
                }

                entity.Name = request.Name;
                entity.ShortName = request.ShortName;
                entity.Code = request.Code;

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}