using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Third_Project.Data
{
    public class AddDBContext : DbContext
    {
        public AddDBContext(DbContextOptions<AddDBContext> options) : base(options){}

        public DbSet<Model.StudentModel> StudentInfo { get; set; }
        
           
    }
}