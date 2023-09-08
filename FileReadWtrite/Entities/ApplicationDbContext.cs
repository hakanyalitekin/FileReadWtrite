using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FileReadWtrite.Entities
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        public DbSet<FileStore> PdfFiles { get; set; }
    }
}
