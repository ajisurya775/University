using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace University.Models;

public class Student
{
    public int ID { get; set; }
    public string LastName { get; set; } = string.Empty;
    public string FirstMidName { get; set; } = string.Empty;
    [DataType(DataType.Date)]
    public DateTime EnrollmentDate { get; set; } = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);


    public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}
