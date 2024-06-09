namespace SGE.Aplicacion;

public class CasoDeUsoTramiteBaja(ITramiteRepositorio tramiteRepositorio, IExpedienteRepositorio expedienteRepositorio, IServicioAutorizacion servicioAutorizacionProvisorio, IEspecificacionCambioDeEstado especificacionCambioDeEstado)
{

    public void Ejecutar(int usuario, int idTramite)
    {
        if (!servicioAutorizacionProvisorio.PoseeElPermiso(usuario, Permiso.TramiteBaja))
            throw new AutorizacionExcepcion("No posee el permiso");

        tramiteRepositorio.Baja(idTramite, out int idExpediente);
        ServicioActualizacionEstado.ActualizarEstado(tramiteRepositorio, expedienteRepositorio, especificacionCambioDeEstado, idExpediente, usuario);
    }
}



