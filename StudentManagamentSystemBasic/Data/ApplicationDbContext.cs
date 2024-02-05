using Microsoft.EntityFrameworkCore;
using StudentManagamentSystemBasic.Models;

namespace StudentManagamentSystemBasic.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<classSection> classSections { get; set; }
    }
}
