namespace SGE.Repositorios;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using AL.Repositorios.RepositoriosSQLite;
using SGE.Aplicacion;
public class ExpedienteSqlite : IExpedienteRepositorio
{

    public void ActualizarEstado(int idUsuario, int idExpediente, EstadoExpediente estado)
    {
        using SGEContext _context = new();
        Expediente expediente = BuscarPorId(idExpediente);
        if (expediente != null)
        {
            expediente.UsuarioUltModificacion = idUsuario;
            expediente.Estado = (EstadoExpediente)estado;
            _context.SaveChanges();
        }
        else
        {
            throw new RepositorioException("No se encontro el expediente");
        }
    }

    public void Alta(Expediente expediente)
    {
        using var _context = new SGEContext();
        _context.Expedientes.Add(expediente);
        _context.SaveChanges();
    }

    public void Baja(int idExpediente)
    {
        using var _context = new SGEContext();
        var expedienteBorrar = _context.Expedientes.Where(a => a.Id == idExpediente).SingleOrDefault();
        var tramiteBorrar = _context.Tramites.Where(t => t.ExpedienteId == idExpediente).ToList();
        if (expedienteBorrar != null)
        {
            _context.Remove(expedienteBorrar);
            _context.RemoveRange(tramiteBorrar);
        }
        _context.SaveChanges();
    }

    public Expediente BuscarPorId(int idExpediente)
    {
        using var _context = new SGEContext();
        Expediente? e = _context.Expedientes.Include(e => e.Tramites).Where(a => a.Id == idExpediente).SingleOrDefault();
        if (e != null)
        {
            return e;
        }
        else
        {
            throw new RepositorioException("No se encontro el expediente");
        }
    }

    public List<Expediente> ListarPorEstado(EstadoExpediente estado)
    {
        using var _context = new SGEContext();

        return _context.Expedientes.Where(e => e.Estado == estado).ToList();
    }

    public List<Expediente> ListarTodos()
    {
        using var _context = new SGEContext();
        return _context.Expedientes.ToList();
    }

    public void Modificacion(int idUsuario, Expediente expediente)
    {
        using var _context = new SGEContext();

        var expedienteModificar = _context.Expedientes.Where(a => a.Id == expediente.Id).SingleOrDefault();
        if (expedienteModificar != null)
        {
            expedienteModificar.Caratula = expediente.Caratula;
            expedienteModificar.Estado = expediente.Estado;
            _context.SaveChanges();
        }
        else
        {
            throw new RepositorioException("No se encontro el expediente");
        }



    }
}
