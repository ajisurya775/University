using System;

namespace University.Models;

public class Course
{
    public int CourseID { get; set; }
    public string Title { get; set; } = string.Empty;
    public int Credits { get; set; }
    public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}
