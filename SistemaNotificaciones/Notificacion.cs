public abstract class Notificacion
{
    private string _Mensaje;
    private string _Destinatario;
    private string  _Remitente;
    private DateTime _FechaEnvio;
    private bool _Estado;

    public Notificacion(string mensaje, string destinatario, string remitente)
    {
        Mensaje = mensaje;
        Destinatario = destinatario;
        Remitente = remitente;
        FechaEnvio = DateTime.Now;
        Estado = false;
    }

    //Faltan validar propiedades
    public string Mensaje
    {
        get { return _Mensaje; }
        set { _Mensaje = value; }
    }

    public string Destinatario
    {
        get { return _Destinatario; }
        set { _Destinatario = value; }
    }

    public string Remitente
    {
        get { return _Remitente; }
        set { _Remitente = value; }
    }

    public DateTime FechaEnvio
    {
        get { return _FechaEnvio; }
        set { _FechaEnvio = value; }
    }

    public bool Estado
    {
        get { return _Estado; }
        set { _Estado = value; }
    }

    public virtual void ImprimirNotificacion()//Tendra que cambiar el formato de salida dependiendo el mensaje
    {
        MenuTop(100);
        EmptyBody(100);
        BodyInMiddleShadow(100);
        //BodyTime((string)FechaEnvio, 100);
        Title($"Destinatario: {Destinatario}", 100);
        Title($"Remitente: {Remitente}", 100);
        BodyInMiddleShadow(100);
        Subtitle(Mensaje, 100);
        BodyInMiddleShadow(100);
        EmptyBody(100);
        BodyLeave("Leido",100);
        MenuBottom(100);
    }

    public abstract void Enviar();

    public abstract void Validar();

    public abstract void PrepararMensaje();

    public abstract void Finalizacion();


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