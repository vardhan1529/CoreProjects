using System.Collections.Generic;

namespace student{
    public class Student{
        public int StudentId { get;set;}

        public string StudentName {get;set;}

        public int Age {get;set;}

        public virtual List<Course> Courses {get;set;}
    }
}