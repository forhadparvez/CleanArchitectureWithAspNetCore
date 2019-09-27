using System.Collections.Generic;

namespace App.Application.Departments.Queries.GetAllDepartmentQuery
{
    public class DepartmentListViewModel
    {
        public IEnumerable<DepartmentDto> Departments { get; set; }

        public bool CreateEnabled { get; set; }
    }
}