using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;


namespace Ifrastructure
{
    public partial class torrentsdbContext : DbContext
    {
        public torrentsdbContext()
        {
        }

        public torrentsdbContext(DbContextOptions<torrentsdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<File> Files { get; set; }
        public virtual DbSet<Forum> Forums { get; set; }
        public virtual DbSet<Torrent> Torrents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
