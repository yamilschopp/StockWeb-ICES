function validarCampos() {
    // Obtener los valores de los campos
    var codigoTributario = document.getElementById('cuilcuit').value;
    var direccion = document.getElementById('direccion').value;
    var provincia = document.getElementById('provincia').value;
    var localidad = document.getElementById('localidad').value;
    var telefono = document.getElementById('telefono').value;
    var mail = document.getElementById('correo').value;
    var denominacion = document.getElementById('denominacion').value;

    // Validar c�digo tributario (solo n�meros y m�ximo 13 d�gitos)
    if (!/^(\d{1,13})$/.test(cuilcuit)) {
        alert('El c�digo tributario debe contener solo n�meros y tener un m�ximo de 13 d�gitos.');
        return false;
    }

    // Validar direcci�n (m�ximo 50 caracteres)
    if (direccion.length > 50) {
        alert('La direcci�n debe tener un m�ximo de 50 caracteres.');
        return false;
    }

    // Validar provincia (debe haber una opci�n seleccionada)
    if (provincia === '') {
        alert('Debe seleccionar una provincia.');
        return false;
    }

    // Validar localidad (debe haber una opci�n seleccionada)
    if (localidad === '') {
        alert('Debe seleccionar una localidad.');
        return false;
    }

    // Validar tel�fono (solo n�meros y m�ximo 10 d�gitos)
    if (!/^(\d{1,10})$/.test(telefono)) {
        alert('El tel�fono debe contener solo n�meros y tener un m�ximo de 10 d�gitos.');
        return false;
    }

    // Validar correo electr�nico (m�ximo 50 caracteres y debe contener "@")
    if (correo.length > 50 || !correo.includes('@')) {
        alert('El correo electr�nico debe tener un m�ximo de 50 caracteres y contener "@" en su contenido.');
        return false;
    }

    // Validar denominaci�n (m�ximo 100 caracteres)
    if (denominacion.length > 100) {
        alert('La denominaci�n debe tener un m�ximo de 100 caracteres.');
        return false;
    }

    // Si todos los campos son v�lidos, se puede enviar el formulario
    return true;
}