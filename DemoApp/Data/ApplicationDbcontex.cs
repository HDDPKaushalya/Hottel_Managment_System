using DemoApp.Model;
using Microsoft.EntityFrameworkCore;


namespace DemoApp.Data
{
    public class ApplicationDbcontex : DbContext
    {
        public ApplicationDbcontex(DbContextOptions<ApplicationDbcontex>options) : base(options)
        { 
        
        }
        public DbSet<RoomModel> RoomModels { get; set; }

    }
}
