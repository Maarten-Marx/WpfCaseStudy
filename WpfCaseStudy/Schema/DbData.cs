using Microsoft.EntityFrameworkCore;

namespace WpfCaseStudy.Schema;

public class DbData : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source = data.db");
    }
}