using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Interfaces;
using App.Application.Students.Queries.GetStudentList;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace App.Application.Departments.Queries.GetAllDepartmentQuery
{
    public class GetAllDepartmentQuery:IRequest<DepartmentListViewModel>
    {

        public class Handler : IRequestHandler<GetAllDepartmentQuery, DepartmentListViewModel>
        {
            private readonly IAppDbContext _context;
            private readonly IMapper _mapper;


            public Handler(IAppDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<DepartmentListViewModel> Handle(GetAllDepartmentQuery request, CancellationToken cancellationToken)
            {
                var entities = await _context.Departments.OrderBy(s => s.Name).ToListAsync(cancellationToken);

                var model = new DepartmentListViewModel()
                {
                    Departments = _mapper.Map<IEnumerable<DepartmentDto>>(entities),
                    CreateEnabled = true
                };
                return model;
            }
        }
    }
}