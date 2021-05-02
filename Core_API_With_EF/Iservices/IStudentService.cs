using Core_API_With_EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_API_With_EF.Iservices
{
    public interface IStudentService
    {
        List<TblStudent> GetStudents();
        TblStudent GetStudentById(int id);
        TblStudent AddStudent(TblStudent student);
        TblStudent UpdateStudent(TblStudent student);
        TblStudent DeleteStudent(int id);
    }
}
