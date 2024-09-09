﻿using ContosoUniTARgv23.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContosoUniTARgv23.Controllers
{
    public class CourseController : Controller
    {
        private readonly SchoolContext _context;

        public CourseController
            (
            SchoolContext context
            )
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {

            var courses = await _context.Courses
                .Include(c => c.Department)
                .AsNoTracking()
                .ToListAsync();

            return View(courses);
        }


    }
}
