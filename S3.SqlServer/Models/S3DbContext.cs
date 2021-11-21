using Microsoft.EntityFrameworkCore;

namespace S3.SqlServer.Models
{
   public class S3DbContext:DbContext
    {
        public S3DbContext(DbContextOptions<S3DbContext> Options) :base(Options)
        {

        }
        public DbSet<Document> Documents { get; set; }
    }
}
