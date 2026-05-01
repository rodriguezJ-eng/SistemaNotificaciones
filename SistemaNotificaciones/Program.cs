using System.Diagnostics;

Notificacion notificacionEmail = new NotificacionEmail(
    "registro de estudiante en curso",
    "Hola Bienvenido",
    "jonathan.rodriguez674@std.uni.edu.ni"); 

notificacionEmail.Enviar();

Notificacion correo = new NotificacionEmail(
    "prueba error",
    "correo.ejemploInvalido.com",
    "saludo1");

correo.Enviar();