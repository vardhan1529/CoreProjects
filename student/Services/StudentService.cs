namespace student.Services
{
    using student.DomainModals;
    using System.Collections.Generic;

    public interface IStudentService{
        List<StudentDomainModal> GetStudents();
    }

    public class StudentService : IStudentService{
        public List<StudentDomainModal> GetStudents(){
            return new List<StudentDomainModal>(){new StudentDomainModal(){Name = "Vardhan", Id
            = 1}};
        }
    }
}