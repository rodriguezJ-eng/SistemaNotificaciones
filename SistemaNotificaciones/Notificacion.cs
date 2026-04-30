public abstract class Notificacion
{
    // prueba de PR
    private string _mensaje;
    private string _destinatario;
    private string _estado;
    private DateTime _fechaEnvio;

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

    public string Estado
    {
        get => _estado;
        protected set => _estado = value; //solo modificado por la clase o sus derivadas
    }

    public DateTime FechaEnvio
    {
        get => _fechaEnvio;
        protected set => _fechaEnvio = value; //solo modificado por la clase o sus derivadas
    }

    // Constructor
    public Notificacion(string mensaje, string destinatario)
    {
        Mensaje = mensaje;
        Destinatario = destinatario;
        Estado = "Pendiente";
        FechaEnvio = DateTime.MinValue; // aún no enviado
    }

    /// <summary>
    /// método tipo plantilla de diseño para las notificaciones push
    /// </summary>
    public void Enviar()
    {
        try
        {
            Validar();
            Preparar();
            RealizarEnvio();
            MostrarInformación();
            Finalizar();

            Estado = "Enviado";
        }
        catch (Exception ex)
        {
            Estado = "Error";
            Console.WriteLine($"Error al enviar la notificación: {ex.Message}");
        }
    }

    // Métodos opcionales que pueden o no ser sobrescritos por las clases derivadas
    // Indican unicamente los "estados" del proceso de envio
    protected virtual void Preparar()
    {
        Console.WriteLine("Preparando el envio...");
    }

    protected virtual void Finalizar()
    {
        FechaEnvio = DateTime.Now.Date;
        Console.WriteLine("\nProceso finalizado.\n");
    }

    // Métodos abstractos obligatorios para las clases derivadas

    protected abstract void Validar();
    protected abstract void RealizarEnvio();

    protected abstract void MostrarInformación();
}