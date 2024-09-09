using Microsoft.AspNetCore.Mvc;

namespace ContosoUniTARgv23.Models
{
    public class InstructorIndexData
    {
       public IEnumerable<Instructor> Instructors { get; set; }
        public IEnumerable<Course> Courses { get; set; }

        public IEnumerable<Enrollment> Enrollments { get; set; }
        public object Instructor { get; internal set; }
    }
}
