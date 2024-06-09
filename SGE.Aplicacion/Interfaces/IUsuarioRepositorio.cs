namespace SGE.Aplicacion;
public interface IUsuarioRepositorio
{
    void Alta(Usuario usuario);
    void Baja(int Id);
    void ModificarUsuario(Usuario usuario);
    Usuario ObtenerUsuario(String nombre, String contraseña);
    List<Usuario> ObtenerUsuarios();
    Usuario ObtenerUsuarioId(int Id);
}
