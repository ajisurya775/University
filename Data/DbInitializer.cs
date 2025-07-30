using Microsoft.EntityFrameworkCore;
using University.Models;

namespace University.Data
{
    public static class DbInitializer
    {
        public static void Initialize(SchoolContext context)
        {
            // Terapkan migration
            context.Database.Migrate();

            if (!context.Students.Any())
            {
                var students = new Student[]
                {
                    new Student{FirstMidName="Carson",LastName="Alexander",EnrollmentDate=DateTime.Parse("2005-09-01").ToUniversalTime()},
                    new Student{FirstMidName="Meredith",LastName="Alonso",EnrollmentDate=DateTime.Parse("2002-09-01").ToUniversalTime()},
                    new Student{FirstMidName="Arturo",LastName="Anand",EnrollmentDate=DateTime.Parse("2003-09-01").ToUniversalTime()},
                    new Student{FirstMidName="Gytis",LastName="Barzdukas",EnrollmentDate=DateTime.Parse("2002-09-01").ToUniversalTime()},
                    new Student{FirstMidName="Yan",LastName="Li",EnrollmentDate=DateTime.Parse("2002-09-01").ToUniversalTime()},
                    new Student{FirstMidName="Peggy",LastName="Justice",EnrollmentDate=DateTime.Parse("2001-09-01").ToUniversalTime()},
                    new Student{FirstMidName="Laura",LastName="Norman",EnrollmentDate=DateTime.Parse("2003-09-01").ToUniversalTime()},
                    new Student{FirstMidName="Nino",LastName="Olivetto",EnrollmentDate=DateTime.Parse("2005-09-01").ToUniversalTime()}
                };
                context.Students.AddRange(students);
                context.SaveChanges();
            }

            if (!context.Courses.Any())
            {
                var courses = new Course[]
                {
                    new Course{CourseID=1050,Title="Chemistry",Credits=3},
                    new Course{CourseID=4022,Title="Microeconomics",Credits=3},
                    new Course{CourseID=4041,Title="Macroeconomics",Credits=3},
                    new Course{CourseID=1045,Title="Calculus",Credits=4},
                    new Course{CourseID=3141,Title="Trigonometry",Credits=4},
                    new Course{CourseID=2021,Title="Composition",Credits=3},
                    new Course{CourseID=2042,Title="Literature",Credits=4}
                };
                context.Courses.AddRange(courses);
                context.SaveChanges();
            }

            if (!context.Enrollments.Any())
            {
                var enrollments = new Enrollment[]
                {
                    new Enrollment{StudentID=context.Students.First().ID,CourseID=1050,Grade=Grade.A},
                    new Enrollment{StudentID=context.Students.Skip(1).First().ID,CourseID=1045,Grade=Grade.B},
                    // tambahkan lainnya sesuai kebutuhan
                };
                context.Enrollments.AddRange(enrollments);
                context.SaveChanges();
            }
        }
    }
}
