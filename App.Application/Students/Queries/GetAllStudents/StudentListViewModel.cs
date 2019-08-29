using System.Collections.Generic;

namespace App.Application.Students.Queries.GetStudentList
{
    public class StudentListViewModel
    {
        public IEnumerable<StudentDto> Students { get; set; }

        public bool CreateEnabled { get; set; }
    }
}
