public class NotificacionWhatsApp : Notificacion
{
    // Se establece los atributos de la clase hija y sus get y set con sus respectivas validaciones
    private string? _numeroTelefono;
    private bool _EstaBloqueado;

    public NotificacionWhatsApp(string? mensaje, string? numeroTelefono) : base(mensaje, numeroTelefono)
    {
        NumeroTelefono = numeroTelefono;

    }

    public string? NumeroTelefono
    {
        get => _numeroTelefono;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("El número no puede estar vacío.");
            
            foreach (char c in value)
            {
                if (c < '0' || c > '9')
                    throw new ArgumentException("El número debe contener solo dígitos.");
            }
            _numeroTelefono = value;
        }
    }

    public bool EstaBloqueado
    {
        get => _EstaBloqueado;
        set => _EstaBloqueado = value;
    }

    protected override void Validar()
    {
        
        if (NumeroTelefono.Length != 15) // Segun el formato internacional, el número de teléfono de WhatsApp debe tener 15 dígitos (incluyendo el código de país). Estandarizado por UIT-T en la recomendación E. 164
            throw new ArgumentException("El número debe tener 15 dígitos como máximo. Incluyendo el código de país.");
        if (EstaBloqueado)
            throw new InvalidOperationException("No se puede enviar el mensaje porque el contacto está bloqueado.");
    }

    protected override void RealizarEnvio()
    {
        Console.WriteLine($"Enviando WhatsApp a {NumeroTelefono}...\n");
    }

    protected override void MostrarInformación()
    {
        Console.WriteLine(new string('-', 40));
        Console.WriteLine("\n--- WHATSAPP ---");
        Console.WriteLine($"De        : {Remitente}");
        Console.WriteLine($"Para      : {NumeroTelefono}");
        Console.WriteLine("Mensaje   :\n");
        Console.WriteLine($"{Mensaje}\n");
        Console.WriteLine($"Estado    : {Estado}");
        Console.WriteLine($"Fecha     : {FechaEnvio:dd/MM/yyyy HH:mm}");
        Console.WriteLine(new string('-', 40));
    }
}