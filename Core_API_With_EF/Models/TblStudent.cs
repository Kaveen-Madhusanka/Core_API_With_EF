using System;
using System.Collections.Generic;

#nullable disable

namespace Core_API_With_EF.Models
{
    public partial class TblStudent
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string StudentGender { get; set; }
        public string StudentAddress { get; set; }
    }
}
