public class NotificacionEmail : Notificacion
{
    public NotificacionEmail(string mensaje, string destinatario, string remitente) : base(mensaje, destinatario, remitente)
    {
    }

    public override void Enviar()
    {
        throw new NotImplementedException();
    }

    public override void Finalizacion()
    {
        throw new NotImplementedException();
    }

    public override void PrepararMensaje()
    {
        throw new NotImplementedException();
    }

    public override void Validar()
    {
        throw new NotImplementedException();
    }
}