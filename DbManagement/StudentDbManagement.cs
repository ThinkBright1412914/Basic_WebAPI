using ApiWithDbms.Model;
using Microsoft.EntityFrameworkCore;

namespace ApiWithDbms.DbManagement
{
    public class StudentDbManagement : DbContext
    {
       public StudentDbManagement(DbContextOptions<StudentDbManagement>dbContextOptions): base(dbContextOptions) 
        {
        
        }


        public DbSet<Students> Student { get; set; }
    }
}
