using todoAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace todoAPI.DbContexts
{
    public class ListInfoContext : DbContext
    {
        public DbSet<List> Lists { get; set; }



    }
}
