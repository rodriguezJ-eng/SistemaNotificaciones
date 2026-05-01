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
            ImprimirNotificacion();
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

    public virtual void ImprimirNotificacion()//Tendra que cambiar el formato de salida dependiendo el mensaje
    {
        MenuTop(100);
        EmptyBody(100);
        BodyInMiddleShadow(100);
        //BodyTime((string)FechaEnvio, 100);
        Title($"Destinatario: {Destinatario}", 100);
        BodyInMiddleShadow(100);
        Subtitle(Mensaje, 100);
        BodyInMiddleShadow(100);
        EmptyBody(100);
        BodyLeave("Leido",100);
        MenuBottom(100);
    }

    // Engel trabajo 

    /*Private void DeterminarWidth()
    {
     idea 1 - Esto deberia de reconocer entre los distintos textos dentro de una lista cual es el mas largo y devolver cuan largo es. se puede hacer con for anidados y contadores.
     idea 2 - establecer una constante de width y mendiate listas, for y validaciones, manejar cuando un mensaje se pasa de la widht establecido, osea si se pasa divide el mensaje y lo pasa a otra linea
    }
    */


    protected void MenuTop(int width)
    {
        Console.WriteLine("╔" + new string('═', width - 2) + "╗");
    } // Parte superior del menú

    protected void MenuBottom(int width)
    {
        Console.WriteLine("╚" + new string('═', width - 2) + "╝");
    } // Parte inferior del menú

    protected void EmptyBody(int width)
    {
        Console.WriteLine("║" + new string(' ', width - 2) + "║");
    } // Línea vacía del cuerpo

    protected void BodyInMiddleShadow(int width)
    {
        Console.WriteLine("║  " + new string('█', width - 6) + "  ║");
    } // Línea con sombra en medio del cuerpo

    protected void Title(string text, int width)
    {
        text = "░░░░ " + text + " ░░░░";

        int space = width - text.Length - 6;
        int leftSide = space / 2;
        int rightSide = space - leftSide;

        Console.WriteLine(
            "║  " + new string(' ', leftSide) + text + new string(' ', rightSide) + "  ║"
        );
    } // Título decorado y centrado

    protected void Subtitle(string text, int width)
    {
        int maxText = width - 12;
        int start = 0;

        while (start < text.Length)
        {
            int finish = Math.Min(start + maxText, text.Length);
            string line = text.Substring(start, finish - start);

            int space = maxText - line.Length;
            int leftSide = space / 2;
            int rightSide = space - leftSide;

            Console.WriteLine(
                "║  ███" + new string(' ', leftSide) + line + new string(' ', rightSide) + "███  ║"
            );

            start = finish;
        }
    } // Subtítulo decorado

    protected void BodyLeave(string text, int width)
    {
        int space = width - text.Length - 6;
        int leftSide = space / 2;
        int rightSide = space - leftSide;

        Console.WriteLine(
            "║  " + new string(' ', leftSide) + text + new string(' ', rightSide) + "  ║"
        );
    }

    protected void BodyTime(string text, int width)
    {
        int space = width - text.Length - 6;
        int leftSide = space / 2;
        int rightSide = space - leftSide;

        Console.WriteLine(
            "║  " + new string(' ', leftSide) + text + new string(' ', rightSide) + "  ║"
        );
    }
     
}