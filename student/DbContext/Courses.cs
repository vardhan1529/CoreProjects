namespace student{
    public class Course{
        public int CourseID {get;set;}

        public string CourseName {get;set;}

        public int StudentID {get;set;}

        public virtual Student Student {get;set;} 
    }
}