
namespace SGE.Repositorios;
using System.Collections.Generic;
using AL.Repositorios.RepositoriosSQLite;
using SGE.Aplicacion;
using System.Security.Cryptography;
using System.Text;

public class UsuarioSqlite : IUsuarioRepositorio
{
    readonly SGEContext _context = new();
    public void Alta(Usuario usuario)
    {
        usuario.Contraseña = Encoding.UTF8.GetString(SHA256.HashData(Encoding.UTF8.GetBytes(usuario.Contraseña)));
        _context.Usuarios.Add(usuario);
        _context.SaveChanges();
    }
    public void Baja(int Id)
    {
        var user = _context.Usuarios.Where(x => x.Id == Id).FirstOrDefault();
        if (user != null)
        {
            _context.Usuarios.Remove(user);
            _context.SaveChanges();
        }
        throw new RepositorioException("Usuario no encontrado");
    }
    public void ModificarUsuario(Usuario usuario)
    {
        var user = _context.Usuarios.Where(x => x.Id == usuario.Id).FirstOrDefault();
        if (user != null)
        {
            user.Nombre = usuario.Nombre;
            user.Contraseña = Encoding.UTF8.GetString(SHA256.HashData(Encoding.UTF8.GetBytes(usuario.Contraseña)));
            _context.SaveChanges();
        }
        throw new RepositorioException("Usuario no encontrado");
    }
    public Usuario ObtenerUsuario(string nombre, string contraseña)
    {
        var user = _context.Usuarios.Where(x => x.Nombre == nombre && x.Contraseña == Encoding.UTF8.GetString(SHA256.HashData(Encoding.UTF8.GetBytes(contraseña)))).FirstOrDefault();
        if (user != null)
        {
            return user;
        }
        throw new RepositorioException("Usuario no encontrado");
    }
    public Usuario ObtenerUsuarioId(int Id)
    {
        var user = _context.Usuarios.Where(x => x.Id == Id).FirstOrDefault();
        if (user != null)
        {
            return user;
        }
        else
            throw new RepositorioException("Usuario no encontrado");
    }
    public List<Usuario> ObtenerUsuarios()
    {
        return _context.Usuarios.ToList();
    }
    public void OtorgarPermiso(Usuario usuario, Permiso permiso)
    {
        var user = _context.Usuarios.Where(x => x.Id == usuario.Id).FirstOrDefault();
        if (user != null)
        {
            user.Permisos[(int)permiso] = true;
            _context.SaveChanges();
        }
    }
}