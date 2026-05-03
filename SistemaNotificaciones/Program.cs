
// ========================================= Casos Correctos ======================================

//EMAIL
NotificacionEmail notificacionEmail = new NotificacionEmail(
    "example@gmail.com",
    "Registro de nueva cuenta",
    "Hola, su cuenta ha sido creada correctamente. Puede iniciar sesión cuando desee.!");

notificacionEmail.Enviar();
Console.WriteLine("\n\n");

//WHATSAPP
Notificacion whatsApp = new NotificacionWhatsApp(
    "775780 is your Acount password reset code",
    "+505",
    "87154642");
whatsApp.Enviar();
Console.WriteLine("\n\n");

//SMS
Notificacion smsValido = new NotificacionSMS(
    "Su código de verificación es 7743672",
    "87154642");
smsValido.Enviar();
Console.WriteLine("\n\n");

// =================================== Casos Incorrectos ================================

Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine("CASOS INCORRECTOS\n");
Console.ResetColor();

// ======================================= Email =========================================
Console.WriteLine("\nPRUEBAS CON EMAIL\n");
// Caso Asunto Vacío
try
{
    Notificacion correo = new NotificacionEmail(
    "example@gmail.com",
    "",
    "saludo1");
    correo.Enviar();
}
catch (Exception ex)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(ex.Message);
    Console.ResetColor();
}

// Caso Mensaje Vacío
try
{
    Notificacion notificacionEmail1 = new NotificacionEmail(
    "example@gmail.com",
    "Registro de Cuenta",
    "");
    notificacionEmail1.Enviar();

}
catch (Exception ex)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(ex.Message);
    Console.ResetColor();
}
// Valida el formato del correo electrónico antes del envío.

// CASO CORREO/DESTINATARIO VACIO
try
{
    Notificacion nEmail = new NotificacionEmail(
        "", "Inicio de sesión", "Sesión inciada");
}
catch(Exception ex)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(ex.Message);
    Console.ResetColor();
}

//CASO EMAIL CON ESPACIOS
Notificacion email2 = new NotificacionEmail(
    "example @gmail.com", "Asunto", "Mensaje");
email2.Enviar();

//CASO MAS DE UN @
Notificacion email3 = new NotificacionEmail(
    "example@@gmail.com", "Asunto", "Mensaje");
email3.Enviar();

//CASO EMPIEZA CON @
Notificacion email4 = new NotificacionEmail(
    "@gmail.com", "Asunto", "Mensaje");
email4.Enviar();

//CASO TERMINA CON @
Notificacion email5 = new NotificacionEmail(
    "example@", "Asunto", "Mensaje");
email5.Enviar();

//CASO EMPIEZA CON '.'

Notificacion email6 = new NotificacionEmail(
    ".example@gmail.com", "Asunto", "Mensaje");

//CASO TERMINA CON '.'
Notificacion email7 = new NotificacionEmail(
    "example@gmail.com.", "Asunto", "Mensaje");
email7.Enviar();

//CASO DOMINIO SIN '.'
Notificacion email8 = new NotificacionEmail(
    "example@gmailcom", "Asunto", "Mensaje");
email8.Enviar();


// ======================== WhatsApp ======================
Console.WriteLine("\nPRUEBAS CON WHATSAPP\n");

// CASO NUMERO VACIO
try
{
    Notificacion whats1 = new NotificacionWhatsApp(
    "Mensaje",
    "+505",
    "");
    whats1.Enviar();
}
catch (Exception ex)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(ex.Message);
    Console.ResetColor();
}

// CASO MENSAJE VACIO
try
{
    Notificacion whats2 = new NotificacionWhatsApp(
    "",
    "+505",
    "87154642");
    whats2.Enviar();

}
catch (Exception ex)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(ex.Message);
    Console.ResetColor();
}

//CASO CODIGO VACIO
try
{
    Notificacion w1 = new NotificacionWhatsApp(
    "Hola", "", "87154642");
    w1.Enviar();

}
catch(Exception ex)
{
    Console.ForegroundColor= ConsoleColor.Red;
    Console.WriteLine(ex.Message);
    Console.ResetColor();
}

//CODIGO CON LETRAS
try
{
    Notificacion w2 = new NotificacionWhatsApp(
        "Hola", "+50A", "87154642");
    w2.Enviar();
}
catch(Exception ex)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(ex.Message);
    Console.ResetColor();
}


//CODIGO DEMASIADO LARGO
try
{
    Notificacion w3 = new NotificacionWhatsApp(
    "Hola", "+50555", "87154642");
    w3.Enviar();
}
catch(Exception ex)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(ex.Message);
    Console.ResetColor();
}


//CODIGO CON SIMBOLOS INVALIDOS
try
{
    Notificacion w4 = new NotificacionWhatsApp(
    "Hola", "+50@", "87154642");
    w4.Enviar();
}
catch (Exception ex)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(ex.Message);
    Console.ResetColor();
}


//CASO NUMERO CON LETRAS

try
{
    Notificacion w5 = new NotificacionWhatsApp(
    "Hola", "+505", "87A54642");
    w5.Enviar();
}
catch(Exception ex)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(ex.Message);
    Console.ResetColor();
}


//CASO NUMERO MUY CORTO

try
{
    Notificacion w6 = new NotificacionWhatsApp(
    "Hola", "+505", "123");
    w6.Enviar();
}
catch(Exception ex)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(ex.Message);
    Console.ResetColor();
}

//NUMERO DEMASIADO LARGO (E.164)
Notificacion w7 = new NotificacionWhatsApp(
    "Hola", "+505", "1234567890123456");
w7.Enviar();

//NUMERO QUE EXCEDE 15 DIGITOS 
Notificacion w8 = new NotificacionWhatsApp(
    "Hola", "+505", "1234567890123");
w8.Enviar();




// ====================== SMS =============================
//CASO NUMERO VACIO
Console.WriteLine("\nPRUEBAS CON SMS\n");
try
{
    Notificacion sms = new NotificacionSMS("Hola", "");
    sms.Enviar();
}
catch(Exception ex)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(ex.Message);
    Console.ResetColor();
}

//CASO NUMERO CON LETRAS
try
{
    Notificacion sms1 = new NotificacionSMS("Hola", "87A54642");
    sms1.Enviar();
}
catch(Exception ex)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(ex.Message);
    Console.ResetColor();
}

//NUMERO CON ESPACIOS
try
{
    Notificacion sms2 = new NotificacionSMS("Hola", "87 54 64 2");
    sms2.Enviar();
}
catch(Exception ex)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(ex.Message);
    Console.ResetColor();
}

//CASO NUMERO DEMASIADO CORTO
Notificacion sms3 = new NotificacionSMS(
    "Mensaje corto",
    "1234"
);
sms3.Enviar();

//CASO DEMASIADO LARGO
Notificacion sms4 = new NotificacionSMS(
    "Bueno esto se supone que debe ser un mensaje largo que tenga mas de 160 caracteres incluyendo espacios pero ya no se que tanto mas escribir asi que mejor hasta aca lo dejo.",
    "88888888"
);
sms4.Enviar();

//CASO MENSAJE VACIO
try
{
    Notificacion sms5 = new NotificacionSMS("", "87154642");
    sms5.Enviar();
}
catch(Exception ex)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(ex.Message);
    Console.ResetColor();
}
