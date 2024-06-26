
        $(document).ready(() => {
        listaServicios();
            
        })
    //modelo que seteara valores vacios iniciales al formulario
    const modeloBase =
    {
        idServicio:0,
    nombreServicio:"",
    periodoServicio:"",
    tipoServicio:"",
    costoServicio:"",
    detalleServicio:"",
    estadoServicio:""
        }

    //funcion que recibe un modelo para cargar en campos de modal
    function showModal(modelo) {
        $("#txtIdServicio").val(modelo.idServicio);
    $("#txtNombreServicio").val(modelo.nombreServicio);
    $("#txtPeriodoServicio").val(modelo.periodoServicio);
    $("#txtTipoServicio").val(modelo.tipoServicio);
    $("#txtCostoServicio").val(modelo.costoServicio);
    $("#txtDetalleServicio").val(modelo.detalleServicio);
    $("#txtEstadoServicio").val(modelo.estadoServicio);
    $('.modal').modal('show');
        }
        // modeloBase el modal con el boton
        $("#btnNuevo").click(() => {
        showModal(modeloBase);
        })

    //funcion para mostrar todos los servicios
    function listaServicios()
    {


        $.ajax({
            url: "../Home/listarServicios",
            type: "GET",
            dataType: "json",
            success: function (dataJson) {
                // Limpiar tabla
                $("#tblServicio tbody").html("");

                // Agregar filas a la tabla
                dataJson.forEach(function (item) {
                    $("#tblServicio tbody").append(
                        $("<tr>").append(
                            $("<td>").text(item.idServicio),
                            $("<td>").text(item.nombreServicio),
                            $("<td>").text(item.costoServicio),
                            $("<td>").text(item.tipoServicio),
                            $("<td>").text(item.estadoServicio),
                            $("<td>").append(
                                $("<button>").addClass("btn btn-success btn-sm me-2 btn-ver").data("modelo", item).text("Ver"),
                                $("<button>").addClass("btn btn-primary btn-sm me-2 btn-editar").data("modelo", item).text("Editar"),
                                $("<button>").addClass("btn btn-danger btn-sm btn-eliminar").data("id", item.idServicio).text("Eliminar")
                            )
                        )
                    );
                });
            },
            error: function (xhr, status, error) {
                console.error("Error en la solicitud AJAX:", status, error);
            }
        });
        }

        //funcion que se dispara al hacer click en el btn guardar para guardar un nuevo servicio
        $("#btnGuardar").click(() => {
        let nuevoModelo = modeloBase;
    nuevoModelo["idServicio"] = $("#txtIdServicio").val();
    nuevoModelo["nombreServicio"] = $("#txtNombreServicio").val();
    nuevoModelo["periodoServicio"] = $("#txtPeriodoServicio").val();
    nuevoModelo["tipoServicio"] = $("#txtTipoServicio").val();
    nuevoModelo["costoServicio"] = $("#txtCostoServicio").val();
    nuevoModelo["detalleServicio"] = $("#txtDetalleServicio").val();
    nuevoModelo["estadoServicio"] = $("#txtEstadoServicio").val();

    if ($("#txtIdServicio").val()==0)
    {
        $.ajax({
            url: "../Home/insertarServicio",
            type: "POST",
            contentType: "application/json;charset=utf-8",
            data: JSON.stringify(nuevoModelo),
            success: function (dataJson) {
                if (dataJson.valor) {
                    alert("Servicio registrado");
                    $('.modal').modal('hide');
                    listaServicios();
                }
            },
            error: function (xhr, status, error) {
                console.error("Error en la solicitud AJAX:", status, error);
            }
        });

            }
    else if ($("#txtIdServicio").val() != 0) //actualizamos el registro de nuestro cliente
    {
        $.ajax({
            url: "../Home/actualizarServicio",
            type: "PUT",
            contentType: "application/json;charset=utf-8",
            data: JSON.stringify(nuevoModelo),
            success: function (dataJson) {
                if (dataJson.valor) {
                    alert("Servicio Actualizado Correctamente");
                    $('.modal').modal('hide');
                    listaServicios();
                }
            },
            error: function (xhr, status, error) {
                console.error("Error en la solicitud AJAX:", status, error);
            }
        });
            }
        })

    // Editar un servicio cargado datos a modal desde btn editar
    $("#tblServicio tbody").on("click", ".btn-ver", function () {
        let servicio = $(this).data("modelo");
    console.log(servicio);
    showModal(servicio);
        })
    // Editar un servicio cargado datos a modal desde btn editar
    $("#tblServicio tbody").on("click", ".btn-editar", function () {
        let servicio = $(this).data("modelo");
    console.log(servicio);
    showModal(servicio);
        })


    //metodo para eliminar servicio
    $("#tblServicio tbody").on("click", ".btn-eliminar", function () {
        let idServicio = $(this).data("id");
    console.log(idServicio);
    let resultado = window.confirm("�Desea eliminar el Servicio?");
    if (resultado) {


        $.ajax({
            url: "../Home/deleteServicio",
            type: "DELETE",
            data: { id: idServicio },
            success: function (dataJson) {
                if (dataJson.valor) {
                    alert("Servicio Eliminado Correctamente");
                    listaServicios();
                }
            },
            error: function (xhr, status, error) {
                if (xhr.status === 500) {
                    // Si el error es un error de servidor (status 500), mostrar una alerta de error
                    alert("No se puede eliminar, Servicio tiene Clientes Asociados");
                } else {
                    console.error("Error en la solicitud AJAX:", status, error);
                }
            }
        });
            }
        })
