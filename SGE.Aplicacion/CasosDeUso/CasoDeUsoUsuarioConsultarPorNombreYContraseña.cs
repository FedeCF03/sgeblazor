using SGE.Aplicacion;

namespace SGE.Aplicacion;
public class CasoDeUsoUsuarioConsultarPorNombreYContraseña(IUsuarioRepositorio usuarioRepositorio)
{
    public Usuario Ejecutar(string nombre, string contraseña)
    {
        return usuarioRepositorio.ObtenerUsuario(nombre, contraseña);
    }
}