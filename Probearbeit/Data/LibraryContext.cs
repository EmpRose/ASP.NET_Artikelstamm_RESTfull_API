using Microsoft.EntityFrameworkCore;
using Probearbeit.Context;

namespace Probearbeit.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {

        }

        public DbSet<Artikel> Artikels { get; set; }

    }
}
