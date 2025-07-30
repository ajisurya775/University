using System;

namespace University.Models;

public class Enrollment
{
    public int EnrollmentID { get; set; }
    public int CourseID { get; set; }
    public int StudentID { get; set; }
    public Grade? Grade { get; set; }
    public Student Student { get; set; } = null!;
    public Course Course { get; set; } = null!;
}
public enum Grade
{
    A, B, C, D, F
}
