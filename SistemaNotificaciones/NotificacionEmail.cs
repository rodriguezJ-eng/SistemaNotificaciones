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

    public NotificacionEmail(string asunto, string mensaje, string correo) : base(mensaje, correo)
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
        Console.WriteLine($"Enviando email a {Destinatario}\n");
    }

    protected override void MostrarInformación()
    {
        Console.WriteLine(new string('-', 40));
        Console.WriteLine("\n--- EMAIL ---");
        Console.WriteLine($"De        : {Remitente}");
        Console.WriteLine($"Para      : {Destinatario}");
        Console.WriteLine($"Asunto    : {Asunto}");
        Console.WriteLine("Mensaje   :\n");
        Console.WriteLine($"{Mensaje}\n");

        Console.WriteLine($"Estado    : {Estado}");
        Console.WriteLine($"Fecha     : {FechaEnvio:dd/MM/yyyy HH:mm}");
        Console.WriteLine(new string('-', 40));
    }
}