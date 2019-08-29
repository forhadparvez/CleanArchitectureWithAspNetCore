
using App.Application.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace App.Application.Students.Queries.GetStudentDetail
{
    public class GetStudentDetailQuery : IRequest<StudentDetailModel>
    {
        public int Id { get; set; }

        public class Handler : IRequestHandler<GetStudentDetailQuery, StudentDetailModel>
        {
            private readonly IAppDbContext _context;

            public Handler(IAppDbContext context)
            {
                _context = context;
            }

            public async Task<StudentDetailModel> Handle(GetStudentDetailQuery request, CancellationToken cancellationToken)
            {
                var entity = await _context.Students
                .FindAsync(request.Id);

                if (entity == null)
                {
                    //throw new NotFoundException(nameof(Student), request.Id);
                    throw new Exception();
                }

                return StudentDetailModel.Create(entity);
            }
        }
    }
}
