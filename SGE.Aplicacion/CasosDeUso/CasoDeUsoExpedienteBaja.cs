namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteBaja(IExpedienteRepositorio expedienteRepositorio, ITramiteRepositorio tramiteRepositorio, IServicioAutorizacion servicioAutorizacionProvisorio)
{
    public void Ejecutar(int idUsuario, int idExpediente)
    {
        if (!servicioAutorizacionProvisorio.PoseeElPermiso(idUsuario, Permiso.ExpedienteBaja))
            throw new AutorizacionExcepcion("No posee el permiso");
        expedienteRepositorio.Baja(idExpediente);
        tramiteRepositorio.BorrarTodosDeIdExpediente(idExpediente);
    }

}
