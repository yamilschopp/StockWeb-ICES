function validarCampos() {
    // Obtener los valores de los campos
    var codigoTributario = document.getElementById('cuilcuit').value;
    var direccion = document.getElementById('direccion').value;
    var provincia = document.getElementById('provincia').value;
    var localidad = document.getElementById('localidad').value;
    var telefono = document.getElementById('telefono').value;
    var mail = document.getElementById('correo').value;
    var denominacion = document.getElementById('denominacion').value;

    // Validar código tributario (solo números y máximo 13 dígitos)
    if (!/^(\d{1,13})$/.test(cuilcuit)) {
        alert('El código tributario debe contener solo números y tener un máximo de 13 dígitos.');
        return false;
    }

    // Validar dirección (máximo 50 caracteres)
    if (direccion.length > 50) {
        alert('La dirección debe tener un máximo de 50 caracteres.');
        return false;
    }

    // Validar provincia (debe haber una opción seleccionada)
    if (provincia === '') {
        alert('Debe seleccionar una provincia.');
        return false;
    }

    // Validar localidad (debe haber una opción seleccionada)
    if (localidad === '') {
        alert('Debe seleccionar una localidad.');
        return false;
    }

    // Validar teléfono (solo números y máximo 10 dígitos)
    if (!/^(\d{1,10})$/.test(telefono)) {
        alert('El teléfono debe contener solo números y tener un máximo de 10 dígitos.');
        return false;
    }

    // Validar correo electrónico (máximo 50 caracteres y debe contener "@")
    if (correo.length > 50 || !correo.includes('@')) {
        alert('El correo electrónico debe tener un máximo de 50 caracteres y contener "@" en su contenido.');
        return false;
    }

    // Validar denominación (máximo 100 caracteres)
    if (denominacion.length > 100) {
        alert('La denominación debe tener un máximo de 100 caracteres.');
        return false;
    }

    // Si todos los campos son válidos, se puede enviar el formulario
    return true;
}