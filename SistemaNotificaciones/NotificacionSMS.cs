public class NotificacionSMS : Notificacion
{
    private string _NumeroTelefono;
    private string _Proveedor;

    public NotificacionSMS(string mensaje, string numeroTelefono, string proveedor)
        : base(mensaje, numeroTelefono, "SMS")
    {
        NumeroTelefono = numeroTelefono;
        Proveedor = proveedor;
    }

    public string NumeroTelefono
    {
        get { return _NumeroTelefono; }
        set { _NumeroTelefono = value; }
    }

    public string Proveedor
    {
        get { return _Proveedor; }
        set { _Proveedor = value; }
    }

    public override void Validar()
    {
        if (string.IsNullOrEmpty(NumeroTelefono) || NumeroTelefono.Length != 8)
        {
            throw new Exception("Número inválido");
        }

        if (!long.TryParse(NumeroTelefono, out _))
        {
            throw new Exception("El número debe contener solo dígitos");
        }

        if (Mensaje.Length > 160)
        {
            throw new Exception("El mensaje excede los 160 caracteres");
        }
    }

    public override void PrepararMensaje()
    {
        Console.WriteLine("Preparando mensaje SMS...");
    }

    public override void Enviar()
    {
        Validar();
        PrepararMensaje();
        ImprimirNotificacion();
        Finalizacion();
    }

    public override void Finalizacion()
    {
        Estado = true;
        FechaEnvio = DateTime.Now;
        Console.WriteLine("SMS enviado correctamente");
    }
}