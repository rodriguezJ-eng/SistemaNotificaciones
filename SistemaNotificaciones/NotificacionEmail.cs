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

    public NotificacionEmail(string mensaje, string correo, string asunto) : base(mensaje,correo)
    {
        Asunto = asunto;
    }
    protected override void Validar()
    {
        if(!Destinatario.Contains("@"))
        {
            throw new ArgumentException("El correo electrónico no es válido.");
        }
    }
    
    protected override void RealizarEnvio()
    {
        Console.WriteLine($"Enviando email a {Destinatario} con asunto '{Asunto}' y mensaje: {Mensaje}");
    }

    protected override void MostrarInformación()
    {
        Console.WriteLine("=================================");
        Console.WriteLine($"|fecha: {FechaEnvio}|"); 
        Console.WriteLine($"|Para: {Destinatario}|");
        Console.WriteLine($"| Estado: {Estado}|");
        Console.WriteLine("=================================");
    }
}