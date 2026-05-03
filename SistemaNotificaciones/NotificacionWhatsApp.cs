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
    private string? _codigoTelfono;

    public NotificacionWhatsApp(string? mensaje, string? numeroTelefono, string? codigoTelefono) : base(mensaje, numeroTelefono)
    {
        CodigoTelefono = codigoTelefono;
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
            _numeroTelefono = CodigoTelefono + " " + value;
        }
    }
    //.Substring(1)
    public string? CodigoTelefono
    {
        get => _codigoTelfono;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("El código de teléfono no puede estar vacío.");

            if (value.StartsWith("+")) // // El código de país generalmente tiene entre 1 y 3 dígitos, asumiendo que se le haya puesto o no puesto el +.
            {
                string numeros = value.Substring(1);

                if (numeros.Length < 1 || numeros.Length > 3)
                    throw new ArgumentException("El código de teléfono debe tener entre 1 y 3 dígitos.");
            }
            else
            {
                if (value.Length < 1 || value.Length > 3)
                    throw new ArgumentException("El código de teléfono debe tener entre 1 y 3 dígitos.");
            }

            int posicion = 0;
            foreach (char c in value)
            {
                posicion++;
                if (c < '0' || c > '9')
                    throw new ArgumentException("El código de teléfono debe contener solo dígitos.");
                if(c == '+' && posicion == 1)
                    _codigoTelfono = value;
            }
            _codigoTelfono = "+" + value;
        }
    }

    protected override void Validar()
    {
        
        if (NumeroTelefono.Trim().Length > 15) // Segun el formato internacional, el número de teléfono de WhatsApp debe tener 15 dígitos (incluyendo el código de país). Estandarizado por UIT-T en la recomendación E. 164.
            throw new ArgumentException("El número debe tener 15 dígitos como máximo. Incluyendo el código de país.");
        if (NumeroTelefono.Length < 7)
            throw new ArgumentException("El número debe tener al menos 7 dígitos para ser válido.");// Tiene que ser mayor a 7 dígitos para evitar números muy cortos que no son válidos.
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