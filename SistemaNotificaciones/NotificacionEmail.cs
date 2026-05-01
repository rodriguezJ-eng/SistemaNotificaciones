public class NotificacionEmail : Notificacion
{
    private string _asunto;
    public string Asunto
    {
        get => _asunto;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("El asunto no puede estar vacío.");
            }
            _asunto = value;
        }
    }

    public NotificacionEmail(string mensaje, string correo, string asunto) : base(mensaje, correo)
    {
        Asunto = asunto;
    }
    protected override void Validar()
    {
        if (!Destinatario.Contains("@"))
        {
            throw new ArgumentException("El correo electrónico no es válido.");
        }
    }

    protected override void RealizarEnvio()
    {
        Console.WriteLine($"Enviando email a {Destinatario} con asunto '{Asunto}' y mensaje: {Mensaje}");
    }

    public override void ImprimirNotificacion()
    {
        MenuTop(100);
        EmptyBody(100);
        BodyInMiddleShadow(100);
        //BodyTime((string)FechaEnvio, 100);
        Title($"Destinatario: {Destinatario}", 100);
        BodyInMiddleShadow(100);
        Subtitle(Asunto, 100);
        BodyInMiddleShadow(100);
        EmptyBody(100);
        BodyLeave("Leido", 100);
        MenuBottom(100);
    }
}