using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core_API_With_EF.Iservices;
using Core_API_With_EF.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Core_API_With_EF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService studentService;
        public StudentController(IStudentService student)
        {
            studentService = student;
        }

        [HttpGet]
        [Route("[action]")]
        //[Route("api/Student/GetStudents")]
        public List<TblStudent> GetStudents()
        {
            return studentService.GetStudents();
        }

        [HttpPost]
        [Route("[action]")]
        //[Route("api/Student/AddStudent")]
        public TblStudent AddStudent(TblStudent student)
        {
            return studentService.AddStudent(student);
        }

        [HttpPut]
        [Route("[action]")]
        //[Route("api/Student/EditStudent")]
        public TblStudent EditStudent(TblStudent student)
        {
            return studentService.UpdateStudent(student);
        }

        [HttpDelete]
        [Route("[action]")]
        //[Route("api/Student/DeleteStudent")]
        public TblStudent DeleteStudent(int id)
        {
            return studentService.DeleteStudent(id);
        }

        [HttpGet]
        [Route("[action]")]
        //[Route("api/Student/GetStudentById")]
        public TblStudent GetStudentById(int id)
        {
            return studentService.GetStudentById(id);
        }
    }
}
