public class NotificacionSMS : Notificacion
{
    public NotificacionSMS(string mensaje, string destinatario) : base(mensaje, destinatario)
    {
    }

    protected override void RealizarEnvio()
    {
        throw new NotImplementedException();
    }

    protected override void Validar()
    {
        throw new NotImplementedException();
    }
}