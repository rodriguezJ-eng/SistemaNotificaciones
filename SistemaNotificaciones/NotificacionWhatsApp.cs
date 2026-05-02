/// <summary>
/// Representa una notificación enviada a través de WhatsApp, incluyendo la validación y el envío del mensaje al número
/// de teléfono especificado.
/// </summary>
/// <remarks>Esta clase hereda de Notificacion y proporciona la lógica específica para el envío de mensajes
/// mediante WhatsApp. El número de teléfono debe cumplir con el formato internacional E.164, es decir, contener
/// exactamente 15 dígitos, incluyendo el código de país. Se lanzarán excepciones si el número no cumple con los
/// requisitos de formato o contiene caracteres no numéricos.</remarks>

public class NotificacionWhatsApp : Notificacion
{
    // Se establece el atributo de la clase hija
    private string? _numeroTelefono;

    public NotificacionWhatsApp(string? mensaje, string? numeroTelefono) : base(mensaje, numeroTelefono)
    {
        NumeroTelefono = numeroTelefono;

    }

    // Propiedad
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

    protected override void Validar()
    {
        
        if (NumeroTelefono.Length != 15) // Segun el formato internacional, el número de teléfono de WhatsApp debe tener 15 dígitos (incluyendo el código de país). Estandarizado por UIT-T en la recomendación E. 164
            throw new ArgumentException("El número debe tener 15 dígitos como máximo. Incluyendo el código de país.");
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