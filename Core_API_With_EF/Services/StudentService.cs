using Core_API_With_EF.Iservices;
using Core_API_With_EF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_API_With_EF.Services
{
    public class StudentService: IStudentService
    {
        Student1Context DbContext;
        public StudentService(Student1Context _db)
        {
            DbContext = _db;
        }

        public TblStudent AddStudent(TblStudent student)
        {
            if (student != null)
            {
                DbContext.TblStudents.Add(student);
                DbContext.SaveChanges();
                return student;
            }
            return null;
        }

        public TblStudent DeleteStudent(int id)
        {
            var student = DbContext.TblStudents.FirstOrDefault(x => x.StudentId == id);
            DbContext.Entry(student).State = EntityState.Deleted;
            DbContext.SaveChanges();
            return student;
        }

        public TblStudent GetStudentById(int id)
        {
            return DbContext.TblStudents.FirstOrDefault(x => x.StudentId == id);
        }

        public List<TblStudent> GetStudents()
        {
            return DbContext.TblStudents.ToList();
        }

        public TblStudent UpdateStudent(TblStudent student)
        {
            DbContext.Entry(student).State = EntityState.Modified;
            DbContext.SaveChanges();
            return student;
        }
    }
}
