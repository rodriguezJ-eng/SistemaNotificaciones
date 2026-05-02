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

Notificacion smsValido = new NotificacionSMS(
    "Hola, este es un mensaje SMS :)",
    "88888888"
);
smsValido.Enviar();

Notificacion smsNumeroInvalido = new NotificacionSMS(
    "Mensaje corto",
    "1234"
);
smsNumeroInvalido.Enviar();

Notificacion smsMensajeLargo = new NotificacionSMS(
    "Bueno esto se supone que debe ser un mensaje largo que tenga mas de 160 caracteres incluyendo espacios pero ya no se que tanto mas escribir asi que mejor hasta aca lo dejo.",
    "88888888"
);
smsMensajeLargo.Enviar();