function validarCampos() {
    // Validar campo "marca"
    var marca = document.getElementById("marca").value;
    if (marca === "") {
        alert("Debe seleccionar una marca.");
        return false;
    }

    // Validar campo "categoria"
    var categoria = document.getElementById("categoria").value;
    if (categoria === "") {
        alert("Debe seleccionar una categoría.");
        return false;
    }

    // Validar campo "descripcion"
    var descripcion = document.getElementById("descripcion").value;
    if (descripcion.trim() === "" || descripcion.length > 50) {
        alert("El campo Descripción es obligatorio y debe tener un máximo de 50 caracteres.");
        return false;
    }

    // Validar campo "precioCompra"
    var precioCompra = document.getElementById("precioCompra").value;
    if (precioCompra.trim() === "" || !/^\d{1,12}(,\d{1,2})?$/.test(precioCompra)) {
        alert("El campo Precio de Compra es obligatorio y debe ser un número válido.");
        return false;
    }

    // Validar campo "stock"
    var stock = document.getElementById("stock").value;
    if (stock.trim() === "" || !/^\d+$/.test(stock)) {
        alert("El campo Stock es obligatorio y debe ser un número entero.");
        return false;
    }

    // Validar campo "codigoBarras"
    var codigoSerie = document.getElementById("codigoSerie").value;
    if (codigoSerie.trim() === "" || !/^\d{1,30}$/.test(codigoSerie)) {
        alert("El campo es obligatorio y debe ser un número válido de máximo 30 caracteres.");
        return false;
    }

    return true;
}