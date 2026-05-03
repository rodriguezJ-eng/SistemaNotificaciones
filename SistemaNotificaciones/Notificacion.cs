/// <summary>
/// Clase base abstracta que representa una notificación
/// Define la estructura común para diferentes tipos de notificaciones,
/// como Email, SMS y WhatsApp, incluyendo propiedades como mensaje, destinatario, remitente, estado y fecha de envío.
/// </summary>
public abstract class Notificacion
{
    // prueba de PR
    private string _mensaje;
    private string _destinatario;
    private string _remitente;
    private bool _estado;
    private DateTime _fechaEnvio;

    /// <summary>
    /// Contenido del mensaje de la notificación.
    /// No puede estar vacío.
    /// </summary>
    public string Mensaje
    {
        get => _mensaje;
        set 
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("El mensaje no puede estar vacío.");
            _mensaje = value; 
        }
    }

    /// <summary>
    /// Destinatario de la notificación (correo o número según el tipo).
    /// No puede estar vacío.
    /// </summary>
    public string Destinatario
    {
        get => _destinatario;
        set 
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("El destinatario no puede estar vacío.");
            _destinatario = value; 
        }
    }

    /// <summary>
    /// Remitente de la notificación (empresa que envía el mensaje).
    /// </summary>
    public string Remitente
    {
        get => _remitente;

        private set => _remitente = value; 
    }

    /// <summary>
    /// Estado de la notificación, indica si ha sido enviada o no.
    /// </summary>
    public bool Estado
    {
        get => _estado;
        private set => _estado = value; 
    }

    /// <summary>
    /// Fecha y hora en que se envió la notificación.
    /// </summary>
    public DateTime FechaEnvio
    {
        get => _fechaEnvio;
        private set => _fechaEnvio = value; 
    }

    /// <summary>
    /// Inicializa una nueva instancia de la Notificación.
    /// </summary>
    /// <param name="mensaje">Contenido del mensaje</param>
    /// <param name="destinatario">Destinatario de la notificación</param>
    public Notificacion(string mensaje, string destinatario)
    {
        Mensaje = mensaje;
        Destinatario = destinatario;
        Remitente = "InfinitiNoty";
        Estado = false;
        FechaEnvio = DateTime.MinValue;
    }

    /// <summary>
    /// Ejecuta el flujo completo para enviar la notificación:
    /// Validación, preparación, envio, actualización de estado,
    /// muestra de información y finalización del proceso.
    /// </summary>
    public void Enviar()
    {
        try
        {
            Validar();
            Preparar();
            RealizarEnvio();
            Estado = true;
            FechaEnvio = DateTime.Now;
            MostrarInformación();
            Finalizar();
        }
        catch (Exception ex)
        {
            Estado = false;
            Console.WriteLine($"Error al enviar la notificación: {ex.Message}");
        }
    }

    /// <summary>
    /// Simulación Realiza tareas previas al envío de la notificación
    /// Puede ser sobreescrito por las clases derivadas si es necesario.
    /// </summary>
    protected virtual void Preparar()
    {
        Console.WriteLine("Preparando el envio...");
    }

    /// <summary>
    /// Simulación de tareas finales después del envío de la notificación
    /// Puede ser sobreescrito por las clases derivadas si es necesario.
    /// </summary>
    protected virtual void Finalizar()
    {
        Console.WriteLine("Proceso finalizado.\n");
    }

    /// <summary>
    /// Valida los datos específicos de cada tipo de notificación.
    /// </summary>
    protected abstract void Validar();

    /// <summary>
    /// Simula el proceso de envío de la notificación
    /// </summary>
    protected abstract void RealizarEnvio();

    /// <summary>
    /// Muestra la información detallada de la notificación.
    /// </summary>
    protected abstract void MostrarInformación();
}