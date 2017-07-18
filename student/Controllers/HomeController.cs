using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace student.Controllers
{
    public class HomeController : Controller
    {
        protected StudentContext sc;
        public HomeController(StudentContext s)
        {
            sc = s;
        }
        public ActionResult Index()
        {
            sc.Database.EnsureCreated();
            sc.Students.Add(new Student(){StudentName = "vardhan"});
            sc.Courses.Add(new Course() { CourseName = "TestCourse", StudentID = 2});
            sc.SaveChanges();
            return Ok("Test");
        }
    }
}
