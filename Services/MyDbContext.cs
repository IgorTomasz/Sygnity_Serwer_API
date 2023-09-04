using CountNextTaskDate.Models;
using Microsoft.EntityFrameworkCore;

namespace CountNextTaskDate.Services
{
    public class MyDbContext : DbContext
    {

        public MyDbContext(DbContextOptions options) : base(options) { }

        public DbSet<NextTaskResponse> Responses { get; set; }


    }
}
