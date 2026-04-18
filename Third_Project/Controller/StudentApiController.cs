using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Third_Project.Model;
using Third_Project.Data;
using Microsoft.EntityFrameworkCore;

namespace Third_Project.Controller
{
    [ApiController]
    [Route("StudentApi")]


    public class StudentApiController : ControllerBase
    {

        private readonly AddDBContext _context;
        public StudentApiController(AddDBContext context)  // dependency injection er maddhome database context ke inject kora hocche
        {
            _context = context;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllStudentInfo()
        {
            var students = await _context.StudentInfo.ToListAsync();
            return Ok(students);
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetStudentInfoById(Guid id)
        {
            var student = await _context.StudentInfo.FindAsync(id); // find student by id in database
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> AddStudentInfo(StudentModel student)
        {
            var newStudent = new StudentModel
            {
                ID = Guid.NewGuid(),
                Name = student.Name,
                Department = student.Department,
                Cgpa = student.Cgpa
            };

            await _context.StudentInfo.AddAsync(newStudent); // add to database 
            await _context.SaveChangesAsync(); // save chages to database

            return Ok(newStudent);

        }

        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> UpdateStudentInfo(Guid id, StudentModel student)
        {
            var existingStudent = await _context.StudentInfo.FindAsync(id);
            if (existingStudent == null)
            {
                return NotFound();
            }

            existingStudent.Name = student.Name;
            existingStudent.Department = student.Department;
            existingStudent.Cgpa = student.Cgpa;

            _context.StudentInfo.Update(existingStudent); // update to database
            await _context.SaveChangesAsync(); // save changes to database

            return Ok(existingStudent);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> DeleteStudentInfo(Guid id)
        {
            var student = await _context.StudentInfo.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            _context.StudentInfo.Remove(student);
            await _context.SaveChangesAsync();

            return Ok($"Student Information deleted for ID: {id}");
        }

    }
}