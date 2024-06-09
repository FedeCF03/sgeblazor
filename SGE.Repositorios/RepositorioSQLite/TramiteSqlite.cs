namespace SGE.Repositorios;
using System.Collections.Generic;
using AL.Repositorios.RepositoriosSQLite;
using SGE.Aplicacion;
public class TramiteSqlite : ITramiteRepositorio
{
    readonly SGEContext context = new();
    public void Alta(Tramite tramite)
    {
        context.Tramites.Add(tramite);
        context.SaveChanges();

    }

    public void Baja(int idTramite, out int idExpediente)
    {
        var tramiteBorrar = context.Tramites.Where(t => t.Id == idTramite).SingleOrDefault();
        if (tramiteBorrar != null)
        {
            idExpediente = tramiteBorrar.ExpedienteId;
            context.Remove(tramiteBorrar);
        }
        else
        {
            throw new RepositorioException("No se encontro el tramite");
        }
        context.SaveChanges();
    }

    public void BorrarTodosDeIdExpediente(int idExpediente)
    {

        var tramitesBorrar = context.Tramites.Where(t => t.ExpedienteId == idExpediente).ToList();
        if (tramitesBorrar != null)
        {
            context.RemoveRange(tramitesBorrar);
        }
        context.SaveChanges();
    }

    public Tramite BuscarPorId(int idTramite)
    {
        Tramite? t = context.Tramites.Find(idTramite);
        if (t != null)
        {
            return t;
        }
        else
        {
            throw new RepositorioException("No se encontro el tramite");
        }
    }

    public Tramite? BuscarUltimo(int idExpediente)
    {
        return context.Tramites.Where(t => t.ExpedienteId == idExpediente).LastOrDefault();
    }

    public List<Tramite> ListarPorEtiqueta(EtiquetaTramite etiqueta)
    {
        return context.Tramites.Where(t => t.Etiqueta == etiqueta).ToList();
    }

    public List<Tramite> ListarTodos()
    {
        return context.Tramites.ToList();
    }

    public List<Tramite> ListarTodosDeIdExpediente(int expedienteId)
    {
        return context.Tramites.Where(t => t.ExpedienteId == expedienteId).ToList();
    }

    public void Modificar(Tramite tramite)
    {
        var tramiteModificar = context.Tramites.Where(t => t.Id == tramite.Id).SingleOrDefault();
        if (tramiteModificar != null)
        {
            tramiteModificar.Etiqueta = tramite.Etiqueta;
            tramiteModificar.FechaUltModificacion = tramite.FechaUltModificacion;
            tramiteModificar.Contenido = tramite.Contenido;
            tramiteModificar.UsuarioUltModificacion = tramite.UsuarioUltModificacion;
            tramiteModificar.ExpedienteId = tramite.ExpedienteId;
        }
        context.SaveChanges();
    }
}
