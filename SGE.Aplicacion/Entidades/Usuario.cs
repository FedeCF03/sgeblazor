using System.Dynamic;

namespace SGE.Aplicacion;

public class Usuario
{
    public int Id { get; set; }
    public required string Nombre { get; set; }
    public required string Apellido { get; set; }
    public required string CorreoElectronico { get; set; }
    public required string Contraseña { get; set; }
    public bool[] Permisos { get; set; } = new bool[6];

    public Usuario()
    {
    }
    public Usuario(string nombre, string contraseña)
    {
        Nombre = nombre;
        Contraseña = contraseña;
    }
}