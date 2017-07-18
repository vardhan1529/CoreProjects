namespace student
{
    using Microsoft.EntityFrameworkCore;

    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options) : base(options)
        {

        }
        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasKey(m => m.StudentId);
            modelBuilder.Entity<Student>().Property(m => m.StudentName).IsRequired(true);

            modelBuilder.Entity<Course>().HasKey(m => m.CourseID);
            modelBuilder.Entity<Course>().HasOne(m => m.Student).WithMany(x => x.Courses).HasForeignKey(l => l.StudentID);
        }
    }
}