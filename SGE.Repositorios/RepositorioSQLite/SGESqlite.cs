using AL.Repositorios.RepositoriosSQLite;
using Microsoft.EntityFrameworkCore;

namespace SGE.Repositorios;

public class SGESqlite
{
    public static void Inicializar()
    {
        using var context = new SGEContext();
        if (context.Database.EnsureCreated())
        {
            Console.WriteLine("Se creó base de datos");
        }
        var connection = context.Database.GetDbConnection();
        connection.Open();
        using var command = connection.CreateCommand();
        command.CommandText = "PRAGMA journal_mode=DELETE;";
        command.ExecuteNonQuery();
    }
}
