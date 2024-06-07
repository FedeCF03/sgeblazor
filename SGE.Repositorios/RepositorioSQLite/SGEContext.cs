namespace AL.Repositorios.RepositoriosSQLite;
using SGE.Aplicacion;
using Microsoft.EntityFrameworkCore;
public class SGEContext : DbContext
{
    public DbSet<Expediente> Expedientes { get; set; }
    public DbSet<Tramite> Tramites { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=sge.sqlite");
    }


}
