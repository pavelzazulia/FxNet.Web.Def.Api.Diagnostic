using Microsoft.EntityFrameworkCore;
using FxNet.Web.Def.Api.Diagnostic.DAL.Db.Tables;

namespace FxNet.Web.Def.Api.Diagnostic.DAL.Db
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options) {}

        public DbSet<JournalTable> Journal { get; set; }
        public DbSet<NodeTable> Node { get; set; }
        public DbSet<TreeTable> Tree { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TreeTable>().ToTable("Tree");
            modelBuilder.Entity<NodeTable>().ToTable("Node");
            modelBuilder.Entity<JournalTable>().ToTable("Journal");
        }
    }
}