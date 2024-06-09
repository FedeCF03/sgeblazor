using SGE.Aplicacion;

namespace SGE.Aplicacion;

public class CasoDeUsoUsuarioBaja(IUsuarioRepositorio usuarioRepositorio)
{
    public void Ejecutar(int idUsuario)
    {
        usuarioRepositorio.Baja(idUsuario);
    }

}
