using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Second_Project.Model
{
    public class Student_info
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }
        public string Department { get; set; }
        public string Cgpa { get; set; }
    }
}