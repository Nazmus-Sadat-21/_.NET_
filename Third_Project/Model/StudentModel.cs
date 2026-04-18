using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Third_Project.Model
{
    public class StudentModel
    {
        public Guid ID { get; set; }
        public string? Name { get; set; }
        public string? Department { get; set; }
        public string? Cgpa { get; set; }
    }
}