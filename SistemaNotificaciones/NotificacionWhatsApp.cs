/// <summary>
/// Representa una notificación enviada por WhatsApp.
/// </summary>
/// <remarks>
/// Esta clase implementa la lógica específica para el envío de mensajes mediante WhatsApp.
/// El número de teléfono debe cumplir el formato internacional E.164. https://www.twilio.com/docs/glossary/what-e164
/// </remarks>

public class NotificacionWhatsApp : Notificacion
{
    // Se establece el atributo de la clase hija
    private string? _numeroTelefono;
    private string? _codigoTelfono;

    public NotificacionWhatsApp(string? mensaje, string? codigoTelefono, string? numeroTelefono) : base(mensaje, numeroTelefono)
    {
        CodigoTelefono = codigoTelefono;
        NumeroTelefono = numeroTelefono;
    }

    /// <summary>
    /// Número de teléfono del destinatario.
    /// Debe contener únicamente dígitos.
    /// </summary>
    public string? NumeroTelefono
    {
        get => _numeroTelefono;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("El número no puede estar vacío.");
            
            if(!value.All(char.IsDigit))
                throw new ArgumentException("El número debe contener solo dígitos.");

            _numeroTelefono = value;
        }
    }

    /// <summary>
    /// Código de país del número de teléfono.
    /// </summary>
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

                if(!numeros.All(char.IsDigit))
                    throw new ArgumentException("El código de teléfono debe contener solo dígitos después del símbolo '+'.");

                if (numeros.Length < 1 || numeros.Length > 3)
                    throw new ArgumentException("El código de teléfono debe tener entre 1 y 3 dígitos.");

                _codigoTelfono = value;
            }
            else
            {
                if(!value.All(char.IsDigit))
                    throw new ArgumentException("El código de teléfono debe contener solo dígitos.");

                if (value.Length < 1 || value.Length > 3)
                    throw new ArgumentException("El código de teléfono debe tener entre 1 y 3 dígitos.");

                _codigoTelfono = "+" + value;
            }
        }
    }

    /// <summary>
    /// Número completo en formato internacional.
    /// </summary>
    public string NumeroCompleto => $"{CodigoTelefono} {NumeroTelefono}";


    /// <summary>
    /// Valida el número de WhatsApp según el formato estándar E.164.
    /// </summary>
    protected override void Validar()
    {
        if (NumeroTelefono.Length < 6 || NumeroTelefono.Length > 15) // Segun el formato internacional, el número de teléfono de WhatsApp debe tener 15 dígitos (incluyendo el código de país). Estandarizado por UIT-T en la recomendación E. 164.
            throw new ArgumentException("El número debe tener 15 dígitos como máximo. Incluyendo el código de país.");

        //Validación E.164 
        //https://www.twilio.com/docs/glossary/what-e164

        int totalDigits = CodigoTelefono.Substring(1).Length + NumeroTelefono.Length;

        if(totalDigits > 15)
            throw new ArgumentException("El número es demasiado largo");
    }

    /// <summary>
    /// Simula el envío de mensaje por WhatsApp.
    /// </summary>
    protected override void RealizarEnvio()
    {
        Console.WriteLine($"Enviando mensaje por WhatsApp a {NumeroCompleto}...\n");

        Console.WriteLine("Mensaje enviado.");
    }

    /// <summary>
    /// Muestra la información formateada del mensaje enviado.
    /// </summary>
    protected override void MostrarInformación()
    {
        Console.WriteLine(new string('-', 40));
        Console.WriteLine("\n--- WHATSAPP ---");
        Console.WriteLine($"De        : {Remitente}");
        Console.WriteLine($"Para      : {NumeroCompleto}");
        Console.WriteLine("Mensaje   :\n");
        Console.WriteLine($"{Mensaje}\n");
        Console.WriteLine($"Estado    : {Estado}");
        Console.WriteLine($"Fecha     : {FechaEnvio:dd/MM/yyyy HH:mm}");
        Console.WriteLine(new string('-', 40));
    }
}