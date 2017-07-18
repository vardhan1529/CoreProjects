namespace student.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using student.Services;
    using student.DomainModals;

    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        protected  readonly IStudentService _student_service;
        public ValuesController(IStudentService student_service)
        {
            _student_service = student_service;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<StudentDomainModal> Get()
        {
            return _student_service.GetStudents();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
