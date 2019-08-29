using App.Application.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace App.Application.Students.Queries.GetStudentList
{
    public class GetAllStudentQuery : IRequest<StudentListViewModel>
    {
        public class Handler : IRequestHandler<GetAllStudentQuery, StudentListViewModel>
        {
            private readonly IAppDbContext _context;
            private readonly IMapper _mapper;


            public Handler(IAppDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<StudentListViewModel> Handle(GetAllStudentQuery request, CancellationToken cancellationToken)
            {
                var students = await _context.Students.OrderBy(s => s.Name).ToListAsync(cancellationToken);

                var model = new StudentListViewModel
                {
                    Students = _mapper.Map<IEnumerable<StudentDto>>(students),
                    CreateEnabled = true
                };
                return model;
            }
        }
    }
}
