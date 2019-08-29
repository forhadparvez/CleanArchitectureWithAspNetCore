using App.Domain.Entities;
using System;
using System.Linq.Expressions;

namespace App.Application.Students.Queries.GetStudentDetail
{
    public class StudentDetailModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte Age { get; set; }
        public string Roll { get; set; }

        public static Expression<Func<Student, StudentDetailModel>> Projection
        {
            get
            {
                return student => new StudentDetailModel
                {
                    Id = student.Id,
                    Name = student.Name,
                    Age = student.Age,
                    Roll = student.Roll
                };
            }
        }


        public static StudentDetailModel Create(Student student)
        {
            return Projection.Compile().Invoke(student);
        }
    }
}
