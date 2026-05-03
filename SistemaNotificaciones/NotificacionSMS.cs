/// <summary>
/// Representa una notificación de tipo SMS.
/// </summary>
/// <remarks>
/// Esta clase hereda de Notificacion e implementa la lógica específica
/// para el envío de mensajes SMS.
/// </remarks>

public class NotificacionSMS : Notificacion
{
    private string _numeroTelefono;

    /// <summary>
    /// Número de teléfono del destinatario del SMS.
    /// Debe contener únicamente dígitos.
    /// </summary>
    public string NumeroTelefono
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

    /// <summary>
    /// Inicializa una nueva instancia de NotificacionSMS.
    /// </summary>
    /// <param name="mensaje">Contenido del mensaje SMS</param>
    /// <param name="numeroTelefono">Número de teléfono del destinario</param>
    public NotificacionSMS(string mensaje, string numeroTelefono)
        : base(mensaje, numeroTelefono)
    {
        NumeroTelefono = numeroTelefono;
    }

    /// <summary>
    /// Valida las reglas del SMS antes del envío.
    /// </summary>
    protected override void Validar()
    {
        if (NumeroTelefono.Length != 8)
            throw new ArgumentException("El número debe tener 8 dígitos.");

        if (Mensaje.Length > 160)
            throw new ArgumentException("El mensaje no puede superar los 160 caracteres.");
    }

    /// <summary>
    /// Simula el envío del mensaje SMS al destinatario.
    /// </summary>
    protected override void RealizarEnvio()
    {
        Console.WriteLine($"Enviando SMS a {NumeroTelefono}...\n");
    }

    /// <summary>
    /// Muestra la información formateada del SMS enviado.
    /// </summary>
    protected override void MostrarInformación()
    {
        Console.WriteLine(new string('-', 40));
        Console.WriteLine("\n--- SMS ---");
        Console.WriteLine($"De        : {Remitente}");
        Console.WriteLine($"Para      : {NumeroTelefono}");
        Console.WriteLine("Mensaje   :\n");
        Console.WriteLine($"{Mensaje}\n");

        Console.WriteLine($"Estado    : {(Estado ? "Enviado" : "No enviado")}");
        Console.WriteLine($"Fecha     : {FechaEnvio:dd/MM/yyyy HH:mm}");
        Console.WriteLine(new string('-', 40));
    }
}