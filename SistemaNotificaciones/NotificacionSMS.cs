/// <summary>
/// una representacion de notificacion de tipo SMS.
/// donde se encarga de validar y enviar mensajes de texto a un número telefónico,
/// verificando que el número contenga solo dígitos y que el mensaje no exceda los caracteres permitidos son hasta 160.
/// </summary>

public class NotificacionSMS : Notificacion
{
    private string _numeroTelefono;

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

    public NotificacionSMS(string mensaje, string numeroTelefono)
        : base(mensaje, numeroTelefono)
    {
        NumeroTelefono = numeroTelefono;
    }

    protected override void Validar()
    {
        
        if (NumeroTelefono.Length != 8)
            throw new ArgumentException("El número debe tener 8 dígitos.");

        if (Mensaje.Length > 160)
            throw new ArgumentException("El mensaje no puede superar los 160 caracteres.");
    }

    protected override void RealizarEnvio()
    {
        Console.WriteLine($"Enviando SMS a {NumeroTelefono}...\n");
    }

    protected override void MostrarInformación()
    {
        Console.WriteLine(new string('-', 40));
        Console.WriteLine("\n--- SMS ---");
        Console.WriteLine($"De        : {Remitente}");
        Console.WriteLine($"Para      : {NumeroTelefono}");
        Console.WriteLine("Mensaje   :\n");
        Console.WriteLine($"{Mensaje}\n");

        Console.WriteLine($"Estado    : {Estado}");
        Console.WriteLine($"Fecha     : {FechaEnvio:dd/MM/yyyy HH:mm}");
        Console.WriteLine(new string('-', 40));
    }
}