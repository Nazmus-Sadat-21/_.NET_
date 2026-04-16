using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Second_Project.Model;

namespace Second_Project.Controller
{
    [ApiController] // class apicontroller hisebe kaj korbe
    [Route("student_info")] // bydefault route er name student_info hobe
 
    public class Student_Info_Controller:ControllerBase
    {
        public static List<Model.Student_info> student_Infos = new List<Model.Student_info>();

        //GET all student info
        [HttpGet] // get method er jonno
        public IActionResult GetStudentInfo()
        {
            return Ok(student_Infos);
        }

        //Get student info by id
        [HttpGet("{id:guid}")] // get method er jonno
        public IActionResult GetStudentByID(Guid id)
        {
            var info = student_Infos.FirstOrDefault(p => p.Id == id);
            if(info == null)
            {
                return NotFound("Student info not found");
            }
            return Ok(info);
        }

        //Post student info
        [HttpPost] // post method er jonno
        public IActionResult PostStudentInfo(Model.Student_info student_Info)
        {
            var studentInfo = new Model.Student_info
            {
                Id = Guid.NewGuid(),
                Name = student_Info.Name,
                Age = student_Info.Age,
                Department = student_Info.Department,
                Cgpa = student_Info.Cgpa
            };
            student_Infos.Add(studentInfo);
            return Created($"student_Infos/add{studentInfo.Id}",studentInfo);

        }

        //put student info
        [HttpPut("{id:guid}")] // put method er jonno
        public IActionResult PutStudentInfo(Guid id, Model.Student_info student_Info)
        {
            var info = student_Infos.FirstOrDefault(p => p.Id == id);
            if(info == null)
            {
                return NotFound("Student info not found");
            }
            info.Name = student_Info.Name ?? info.Name;
            info.Age = student_Info.Age ?? info.Age;
            info.Department = student_Info.Department ?? info.Department;
            info.Cgpa = student_Info.Cgpa ?? info.Cgpa;
            return Ok(info);
        }

        //Delete student info
        [HttpDelete("{id:guid}")] // delete method er jonno
        public IActionResult DeleteStudentInfo(Guid id)
        {
            var info = student_Infos.FirstOrDefault(p => p.Id == id);
            if(info == null)
            {
                return NotFound("Student info not found");
            }
            student_Infos.Remove(info);
            return Ok("Student info deleted successfully");
        }
    }
}