using App.Application.Interfaces.Mapping;
using App.Application.Students.Queries.GetStudentList;
using App.Domain.Entities;
using AutoMapper;

namespace App.Application.Departments.Queries.GetAllDepartmentQuery
{
    public class DepartmentDto:IHaveCustomMapping
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Code { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<Department, DepartmentDto>();
        }
    }
}