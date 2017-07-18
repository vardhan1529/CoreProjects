using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using student;

namespace student.Migrations
{
    [DbContext(typeof(StudentContext))]
    partial class StudentContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("student.Course", b =>
                {
                    b.Property<int>("CourseID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CourseName");

                    b.Property<int>("StudentID");

                    b.HasKey("CourseID");

                    b.HasIndex("StudentID");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("student.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Age");

                    b.Property<string>("StudentName")
                        .IsRequired();

                    b.HasKey("StudentId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("student.Course", b =>
                {
                    b.HasOne("student.Student", "Student")
                        .WithMany("Courses")
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
