<<<<<<< HEAD
﻿
=======
﻿using System.Diagnostics;

Notificacion notificacionEmail = new NotificacionEmail(
    "Hola Bienvenido",
    "jonathan.rodriguez674@std.uni.edu.ni",
    "registro de estudiante en curso"); 

notificacionEmail.Enviar();

Notificacion correo = new NotificacionEmail(
    "Saludos",
    "correo.ejemploInvalido.com",
    "prueba error");

correo.Enviar();
>>>>>>> 4c49437bcc3204c433061f60e96f415c7e5d8641
