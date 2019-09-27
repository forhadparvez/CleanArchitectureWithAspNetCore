using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Application.Departments.Commands.CreateDepartment;
using App.Application.Departments.Commands.UpdateStudent;
using App.Application.Departments.Queries.GetAllDepartmentQuery;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.WebApi.Controllers
{
    public class DepartmentsController : BaseController
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<DepartmentListViewModel>> Get()
        {
            return Ok(await Mediator.Send(new GetAllDepartmentQuery()));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Create([FromBody]CreateDepartmentCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }


        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromBody]UpdateDepartmentCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }
    }
}