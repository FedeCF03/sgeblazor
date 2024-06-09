using SGE.Aplicacion;
namespace SGE.Aplicacion;

public class CasoDeUsoUsuarioAlta(IUsuarioRepositorio usuarioRepositorio)
{

    public void Ejecutar(Usuario usuario)
    {
        usuarioRepositorio.Alta(usuario);
    }

}
