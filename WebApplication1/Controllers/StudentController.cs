using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;
using WebApplication1.Providers;

namespace WebApplication1.Controllers
{
    public class StudentController : ApiController
    {
        private StudentService studentService;

        StudentController()
        {
            studentService = new StudentService();
        }

        [HttpGet]
        [Route("api/students")]
        public IHttpActionResult Get()
        {
            var students = this.studentService.GetStudents();

            if(students == null)
            {
                return NotFound();
            }

            return Ok(students);
        }

        // GET api/values/5
        [HttpGet]
        [Route("api/students/{id}")]
        public IHttpActionResult Get(int id)
        {
            var student = this.studentService.GetStudentById(id);

            if(student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        // POST api/values
        [HttpPost]
        [Route("api/student")]
        public HttpResponseMessage Post([FromBody]Student student)
        {
            int totalRcordInserted = this.studentService.AddStudent(student);

            if(totalRcordInserted <= 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error while adding student");
            }

            return Request.CreateResponse(HttpStatusCode.Created);
        }

        // PUT api/values/5
        [HttpPut]
        [Route("api/student")]
        public HttpResponseMessage Put([FromBody]Student student)
        {
            int totalRecordUpdated = this.studentService.UpdateStudent(student.Id, student);

            if (totalRecordUpdated <= 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error while updating student");
            }

            return Request.CreateResponse(HttpStatusCode.Created);
        }

        // DELETE api/values/5
        [HttpDelete]
        [Route("api/students/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            int totalRecordDeleted = this.studentService.DeleteStudent(id);

            if (totalRecordDeleted <= 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Error while deleting student");
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
