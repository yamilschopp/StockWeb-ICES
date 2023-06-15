function validarCampos() {
    // Validar campo "nombreUsuario"
    var nombreUsuario = document.getElementById("nombreUsuario").value;
    if (nombreUsuario.trim() === "" || nombreUsuario.length > 50) {
        alert("El campo Nombre de usuario es obligatorio y debe tener un m�ximo de 50 caracteres.");
        return false;
    }

    // Validar campo "clave"
    var clave = document.getElementById("clave").value;
    if (clave.trim() === "" || clave.length > 50) {
        alert("El campo Clave es obligatorio y debe tener un m�ximo de 50 caracteres.");
        return false;
    }

    // Validar campo "nombre"
    var nombre = document.getElementById("nombre").value;
    if (nombre.trim() === "" || nombre.length > 50) {
        alert("El campo Nombre es obligatorio y debe tener un m�ximo de 50 caracteres.");
        return false;
    }

    // Validar campo "apellido"
    var apellido = document.getElementById("apellido").value;
    if (apellido.trim() === "" || apellido.length > 50) {
        alert("El campo Apellido es obligatorio y debe tener un m�ximo de 50 caracteres.");
        return false;
    }

    // Validar campo "mail"
    var mail = document.getElementById("correo").value;
    if (mail.trim() === "" || mail.length > 50 || !mail.includes("@")) {
        alert("El campo Correo es obligatorio, debe tener un m�ximo de 50 caracteres y debe ser v�lido.");
        return false;
    }

    // Validar campo "fechaNacimiento"
    var fechaNacimiento = document.getElementById("fechaNacimiento").value;
    if (fechaNacimiento.trim() === "") {
        alert("Debe seleccionar una fecha de nacimiento.");
        return false;
    }

    return true;
}
