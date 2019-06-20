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

        public  DbSet<File> Files { get; set; }
        public  DbSet<Forum> Forums { get; set; }
        public  DbSet<Torrent> Torrents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
