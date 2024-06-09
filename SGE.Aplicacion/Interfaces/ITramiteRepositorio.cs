namespace SGE.Aplicacion;

public interface ITramiteRepositorio
{
    void Alta(Tramite tramite);
    void Baja(int idTramite, out int idExpediente);
    void Modificar(Tramite tramite);
    Tramite BuscarPorId(int idTramite);
    List<Tramite> ListarTodos();
    List<Tramite> ListarPorEtiqueta(EtiquetaTramite etiqueta);
    List<Tramite> ListarTodosDeIdExpediente(int expedienteId);
    void BorrarTodosDeIdExpediente(int idExpediente);
    Tramite? BuscarUltimo(int idExpediente);



}