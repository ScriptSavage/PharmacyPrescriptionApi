using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance;

public class ProjectContext : DbContext
{
    public ProjectContext(DbContextOptions options) : base(options)
    {
    }
    
    
    
}