/// <summary>
/// Representa una notificación de tipo Email.
/// </summary>
/// <remarks>
/// Esta clase implementa la lógica específica para el envío de correos electrónicos.
/// Incluye validaciones de formato como la presencia de '@', dominio válido, y ausencia de espacios.
/// </remarks>

public class NotificacionEmail : Notificacion
{
    private string _asunto;

    /// <summary>
    /// Asunto del correo electrónico.
    /// No puede estar vacío.
    /// </summary>
    public string Asunto
    {
        get => _asunto;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("El asunto no puede estar vacío.");
                return;
            }
            _asunto = value;
        }
    }

    /// <summary>
    /// Inicializa una nueva instancia de NotificacionEmail.
    /// </summary>
    /// <param name="correo">Dirección de correo del destinatario</param>
    /// <param name="asunto">Asunto del mensaje</param>
    /// <param name="mensaje">Contenido del correo</param>
    public NotificacionEmail(string correo, string asunto, string mensaje) : base(mensaje, correo)
    {
        Asunto = asunto;
    }

    /// <summary>
    /// Valida el formato del correo electrónico antes del envío.
    /// </summary>
    protected override void Validar()
    {
        string direccionEmail = Destinatario;

        // Caso vacío
        if (string.IsNullOrWhiteSpace(direccionEmail))
            throw new ArgumentException("El correo electrónico no puede estar vacío.");

        // caso con espacios
        if(direccionEmail.Contains(" "))
            throw new ArgumentException("El correo electrónico no puede contener espacios.");

        // caso con mas de un @
        if(direccionEmail.Count(c => c == '@') != 1)
            throw new ArgumentException("El correo electrónico debe contener exactamente un símbolo '@'.");

        // Caso de inicio o fin con @ o .
        if(direccionEmail.StartsWith("@") || direccionEmail.EndsWith("@") || direccionEmail.StartsWith(".") || direccionEmail.EndsWith("."))
            throw new ArgumentException("El correo electrónico no puede comenzar o terminar con '@' o '.'.");

        //validar estructura básica del correo electrónico (usuario/dominio)
        string[] partes = direccionEmail.Split('@');
        string dominio = partes[1];

        //validación dominio dirección de correo electrónico
        if(!dominio.Contains("."))
            throw new ArgumentException("El dominio del correo electrónico debe contener al menos un punto '.'.");
    }

    /// <summary>
    /// Simula el envío del correo electrónico al destinatario.
    /// </summary>
    protected override void RealizarEnvio()
    {
        Console.WriteLine($"Enviando email a {Destinatario}");
        Console.WriteLine("Email enviado.");
    }

    /// <summary>
    /// Muestra la información formateada del correo electrónico enviado.
    /// </summary>
    protected override void MostrarInformación()
    {
        Console.WriteLine(new string('-', 40));
        Console.WriteLine("--- EMAIL ---");
        Console.WriteLine($"De        : {Remitente}");
        Console.WriteLine($"Para      : {Destinatario}");
        Console.WriteLine($"Asunto    : {Asunto}");
        Console.WriteLine("Mensaje   :\n");
        Console.WriteLine($"{Mensaje}\n");

        Console.WriteLine($"Estado    : {(Estado ? "Enviado" : "No enviado")}");
        Console.WriteLine($"Fecha     : {FechaEnvio:dd/MM/yyyy HH:mm}");
        Console.WriteLine(new string('-', 40));
    }
}