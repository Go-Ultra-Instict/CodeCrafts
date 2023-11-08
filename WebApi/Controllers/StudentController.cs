using Application.StudentTopic.Commands.CreateStudents;
using Application.StudentTopic.Queries.GetStudents;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CodeCrafts.WebAPI.Controllers
{
  
   
    public class StudentController : ApiControllerBase
    {
        private readonly IMediator _mediator;
       
        // GET: api/<StudentController>
        [HttpGet]
        public async Task<StudentDto> Get([FromQuery]GetStudentQuery query)
        {
            return await Mediator.Send(query);
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<StudentController>
        [HttpPost]
        public void Post([FromBody] CreateStudentCommand createStudent)
        {
            Mediator.Send( createStudent);
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
