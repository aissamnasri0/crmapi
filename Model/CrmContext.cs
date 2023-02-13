
using Microsoft.EntityFrameworkCore;


namespace tpcrm.Models
{
    public class CrmContext : DbContext
    {
        public DbSet<Clients> clients { get; set; }
        public DbSet<Orders> orders { get; set; }
        public DbSet<USers> users { get; set; }
        
        public CrmContext() {
             Database.EnsureCreated();
         }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=BOR-12XVSG3;Database=tpcrm;Trusted_Connection=True;MultipleActiveResultSets=true;trustServerCertificate=true;");
        }
    }
}