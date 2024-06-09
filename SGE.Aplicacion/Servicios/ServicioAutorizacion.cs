namespace SGE.Aplicacion;
using SGE.Aplicacion;
public class ServicioAutorizacion(IUsuarioRepositorio repositorioUsuario) : IServicioAutorizacion
{


    public bool PoseeElPermiso(int IdUsuario, Permiso permiso)
    {
        if (IdUsuario == 1)
        {
            return true;
        }
        var usuario = repositorioUsuario.ObtenerUsuarioId(IdUsuario);
        return usuario.Permisos[(int)permiso];
    }
}