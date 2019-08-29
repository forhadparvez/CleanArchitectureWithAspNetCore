using App.Application.Interfaces.Mapping;
using App.Domain.Entities;
using AutoMapper;

namespace App.Application.Students.Queries.GetStudentList
{
    public class StudentDto : IHaveCustomMapping
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte Age { get; set; }
        public string Roll { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<Student, StudentDto>();
        }
    }
}
