﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoUniTARgv23.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [StringLength(50)]
        [Column("FirstName")]
        [Display(Name = "Last Name")]
        public string FirstMidName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy - MM - dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "EnrollmentDate")]
        public DateTime EnrollmentDate { get; set; }

        [Display(Name = "Full Name")]

        public string FullName { get
                                 {
                return LastName + ", " + FirstMidName;
                                    }
        }
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
