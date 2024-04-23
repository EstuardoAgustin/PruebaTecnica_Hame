 
    const modeloBase =
    {
        idCliente:0,
    nombreCliente:"",
    codigoCliente:"",
    direccionCliente:"",
    telefonoCliente:"",
    estadoCliente:""
        }

    const modeloBaseServicioAsociado =
    {
        idClienteServicio: 0,
    idClienteFk: "",
    nombreClienteAsociado: "",
    idServicioFk: "",
    tipoClienteServicio: "",
    estadoClienteServicio: "",
    direccionClienteServicio: "",
    ubicacionClienteServicio: "",
    velocidadClienteServicio: "",
    paqueteClienteServicio: "",
    detallesClienteServicio: ""
        }

        $(document).ready(() => {
        listaClientes();
    cargarServicios();
            
        })

    function showModal(modelo)
    {
        $("#txtIdCliente").val(modelo.idCliente);
    $("#txtNombre").val(modelo.nombreCliente);
    $("#txtCodCliente").val(modelo.codigoCliente);
    $("#txtTelefono").val(modelo.telefonoCliente);
    $("#txtDireccion").val(modelo.direccionCliente);
    $("#txtEstado").val(modelo.estadoCliente);
    $('#modalCliente').modal('show');
        }


        $("#btnAgregarServicio").click(() => {
        let NuevoModeloServicioAsociado = modeloBaseServicioAsociado;
    NuevoModeloServicioAsociado["idClienteServicio"] = 0;
    NuevoModeloServicioAsociado["idClienteFk"] = $("#txtIdCliente").val();
    NuevoModeloServicioAsociado["nombreClienteAsociado"] = $("#txtNombre").val();
    NuevoModeloServicioAsociado["tipoClienteServicio"] = "";
    NuevoModeloServicioAsociado["estadoClienteServicio"] = "";
    NuevoModeloServicioAsociado["direccionClienteServicio"] = "";
    NuevoModeloServicioAsociado["ubicacionClienteServicio"] = "";
    NuevoModeloServicioAsociado["velocidadClienteServicio"] = "";
    NuevoModeloServicioAsociado["paqueteClienteServicio"] = "";
    NuevoModeloServicioAsociado["detallesClienteServicio"] = "";
    showModalServiciosAsociados(NuevoModeloServicioAsociado);
        })

    //Show Modal Servicios Asociados
    function showModalServiciosAsociados(modelo) {
        $("#txtIdServicioASociado").val(modelo.idClienteServicio);
    $("#txtIdClienteASociado").val(modelo.idClienteFk);
    $("#txtNombreClienteAsociado").val(modelo.nombreClienteAsociado);
    $("#txtTipoServicioAsociado").val(modelo.tipoClienteServicio);
    $("#txtDirInstalacionServicioAsociado").val(modelo.direccionClienteServicio);
    $("#txtCoordenadasServicioAsociado").val(modelo.ubicacionClienteServicio);
    $("#txtVelocidadServicioAsociado").val(modelo.velocidadClienteServicio);
    $("#txtPaqueteServicioAsociado").val(modelo.paqueteClienteServicio);
    $("#txtDetalleServicioAsociado").val(modelo.detallesClienteServicio);
    $("#modalServiciosAsociados").modal('show');
        }

        // modeloBase el modal con el boton Nuevo Cliente
        $("#btnNuevo").click(() => {
        $("#tblServicioAsociados tbody").html("");
    $("#GrupoServiciosAsociados").hide(); // Ocultar el div
    showModal(modeloBase);
        })

        // Guardar un cliente nuevo 
        $("#btnGuardar").click(() => {
        let NuevoModelo = modeloBase;
    NuevoModelo["idCliente"] = $("#txtIdCliente").val();
    NuevoModelo["nombreCliente"] = $("#txtNombre").val();
    // NuevoModelo["fechaAltaCliente"] = $("#txtFechaAlta").val();
    NuevoModelo["codigoCliente"] = $("#txtCodCliente").val();
    NuevoModelo["direccionCliente"] = $("#txtDireccion").val();
    NuevoModelo["telefonoCliente"] = $("#txtTelefono").val();
    NuevoModelo["estadoCliente"] = $("#txtEstado").val();

    if ($("#txtIdCliente").val() == 0) {
        $.ajax({
            url: "Home/insertarCliente",
            type: "POST",
            contentType: "application/json;charset=utf-8",
            data: JSON.stringify(NuevoModelo),
            success: function (dataJson) {
                if (dataJson.valor) {
                    alert("Registrado correctamente");
                    $('#modalCliente').modal('hide');
                    listaClientes();
                }
            },
            error: function (xhr, status, error) {
                console.error("Error en la solicitud AJAX:", status, error);
            }
        });

            } else if ($("#txtIdCliente").val() != 0) //actualizamos el registro de nuestro cliente
    {
        $.ajax({
            url: "Home/actualizarCliente",
            type: "PUT",
            contentType: "application/json;charset=utf-8",
            data: JSON.stringify(NuevoModelo),
            success: function (dataJson) {
                if (dataJson.valor) {
                    alert("Datos Actualizados");
                    $('#modalCliente').modal('hide');
                    listaClientes();
                }
            },
            error: function (xhr, status, error) {
                console.error("Error en la solicitud AJAX:", status, error);
            }
        });

            }

        })

    //listar todos los clientes en el table
    function listaClientes() {
        $.ajax({
            url: "Home/listarClientes",
            type: "GET",
            dataType: "json",
            success: function (dataJson) {
                $("#tblCliente tbody").html("");

                dataJson.forEach(function (item) {
                    $("#tblCliente tbody").append(
                        $("<tr>").append(
                            $("<td>").text(item.idCliente),
                            $("<td>").text(item.codigoCliente),
                            $("<td>").text(item.nombreCliente),
                            $("<td>").text(item.direccionCliente),
                            $("<td>").text(item.telefonoCliente),
                            $("<td>").append(
                                $("<button>").addClass("btn btn-success btn-sm me-2 btn-ver").data("modelo", item).text("Ver Servicios"),
                                $("<button>").addClass("btn btn-primary btn-sm me-2 btn-editar").data("modelo", item).text("Editar"),
                                $("<button>").addClass("btn btn-danger btn-sm btn-eliminar").data("id", item.idCliente).text("Eliminar")
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

    //editar cliente
    $("#tblCliente tbody").on("click", ".btn-editar", function () {
        let cliente = $(this).data("modelo");
    console.log(cliente);
    $("#GrupoServiciosAsociados").hide(); // Ocultar el div
    // Limpiar tabla
    $("#tblServicioAsociados tbody").html("");
    showModal(cliente);
        })

    //Eliminar Cliente
    $("#tblCliente tbody").on("click", ".btn-eliminar", function () {
        let idCliente = $(this).data("id");
    console.log(idCliente);
    let resultado = window.confirm("¿Desea eliminar el Cliente?");
    if (resultado) {
        $.ajax({
            url: "Home/deleteCliente",
            type: "DELETE",
            data: { id: idCliente },
            success: function (dataJson) {
                if (dataJson.valor) {
                    alert("Cliente Eliminado Correctamente");
                    listaClientes();
                } else {
                    // Manejar otro comportamiento si es necesario
                }
            },
            error: function (xhr, status, error) {
                if (xhr.status === 500) {
                    alert("No se puede eliminar, Cliente tiene servicios Activos");
                } else {
                    console.error("Error:", error);
                }
            }
        });
            }
        });


    //Ver Informacion Cliente
    $("#tblCliente tbody").on("click", ".btn-ver", function () {
        let cliente = $(this).data("modelo");
    let idCliente = cliente.idCliente; // Aquí debes obtener el id del cliente de alguna manera
    console.log(idCliente);
    $("#GrupoServiciosAsociados").show(); // Mostrar el div
    listaServiciosAsociadosCliente(idCliente);
    showModal(cliente);
        })



    //funcion para mostrar todos los serviciosAsociados a un cliente
    function listaServiciosAsociadosCliente(idCliente) {


        $.ajax({
            url: "../Home/listarServiciosAsociadosCliente?idCliente=" + idCliente,
            type: "GET",
            dataType: "json",
            success: function (dataJson) {
                // Limpiar tabla
                $("#tblServicioAsociados tbody").html("");

                // Agregar filas a la tabla
                dataJson.forEach(function (item) {

                    $("#tblServicioAsociados tbody").append(
                        $("<tr>").append(
                            $("<td>").text(item.idClienteServicio),
                            $("<td>").text(item.servicioAsociado.nombreServicio),
                            $("<td>").text(item.servicioAsociado.tipoServicio),
                            $("<td>").text(item.servicioAsociado.costoServicio),
                            // $("<td>").text(item.estadoServicio),
                            $("<td>").append(
                                $("<button>").addClass("btn btn-primary btn-sm me-2 btn-editarServicoAsociado").data("modelo", item).text("Editar"),
                                $("<button>").addClass("btn btn-danger btn-sm btn-eliminarServicoAsociado").data("id", item.idClienteServicio).text("Eliminar")
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


    // Función para cargar los servicios en un select
    function cargarServicios() {
        $.ajax({
            url: "../Home/listarServicios",
            type: "GET",
            dataType: "json",
            success: function (dataJson) {
                // Limpiar el select
                $("#selectServicios").empty();

                // Agregar opciones al select
                dataJson.forEach(function (item) {
                    $("#selectServicios").append(
                        $("<option>").val(item.idServicio).text(item.nombreServicio)
                    );
                });
            },
            error: function (xhr, status, error) {
                console.error("Error en la solicitud AJAX:", status, error);
            }
        });
        }


        // Guardar un cliente nuevo
        $("#btnGuardarServicioAsociado").click(() => {

        let idCliente = $("#txtIdClienteASociado").val(); // Aquí debes obtener el id del cliente de alguna manera

    let NuevoModelo = modeloBaseServicioAsociado;
    NuevoModelo["idClienteServicio"] = $("#txtIdServicioASociado").val();
    NuevoModelo["idClienteFk"] = $("#txtIdClienteASociado").val();
    // NuevoModelo["nombreClienteAsociado"] = $("#txtNombreClienteAsociado").val();
    NuevoModelo["idServicioFk"] = $("#selectServicios").val();
    NuevoModelo["tipoClienteServicio"] = $("#txtTipoServicioAsociado").val();
    NuevoModelo["estadoClienteServicio"] = $("#selectEstadoServicioAsociado").val();
    NuevoModelo["direccionClienteServicio"] = $("#txtDirInstalacionServicioAsociado").val();
    NuevoModelo["ubicacionClienteServicio"] = $("#txtCoordenadasServicioAsociado").val();
    NuevoModelo["velocidadClienteServicio"] = $("#txtVelocidadServicioAsociado").val();
    NuevoModelo["paqueteClienteServicio"] = $("#txtPaqueteServicioAsociado").val();
    NuevoModelo["detallesClienteServicio"] = $("#txtDetalleServicioAsociado").val();

    console.log(NuevoModelo);




    if ($("#txtIdServicioASociado").val() == 0) {

        $.ajax({
            url: "Home/insertarServicioAsociado_Cliente",
            type: "POST",
            contentType: "application/json;charset=utf-8",
            data: JSON.stringify(NuevoModelo),
            success: function (dataJson) {
                if (dataJson.valor) {
                    alert("Servicio Asociado Correctamente");
                    $('#modalServiciosAsociados').modal('hide');
                    listaServiciosAsociadosCliente(idCliente);
                }
            },
            error: function (xhr, status, error) {
                console.error("Error en la solicitud AJAX:", status, error);
            }
        });

            } else if ($("#txtIdCliente").val() != 0) //actualizamos el registro de nuestro cliente
    {
        $.ajax({
            url: "../Home/actualizarServicioASociado",
            type: "PUT",
            contentType: "application/json;charset=utf-8",
            data: JSON.stringify(NuevoModelo),
            success: function (dataJson) {
                if (dataJson.valor) {
                    alert("Servicio Actualizado Correctamente");
                    $('#modalServiciosAsociados').modal('hide');

                    listaServiciosAsociadosCliente(idCliente);
                }
            },
            error: function (xhr, status, error) {
                console.error("Error en la solicitud AJAX:", status, error);
            }
        });
            }

        })

    //editar Servicio Asociado
    $("#tblServicioAsociados tbody").on("click", ".btn-editarServicoAsociado", function () {
        let servicioAsociado = $(this).data("modelo");
    console.log(servicioAsociado);

    $("#txtIdServicioASociado").val(servicioAsociado.idClienteServicio);
    $("#txtIdClienteASociado").val(servicioAsociado.idClienteFk);
    $("#txtNombreClienteAsociado").val(servicioAsociado.clienteAsociado.nombreCliente);
    $("#selectServicios").val(servicioAsociado.idServicioFk);
    $("#txtTipoServicioAsociado").val(servicioAsociado.tipoClienteServicio);
    $("#txtDirInstalacionServicioAsociado").val(servicioAsociado.direccionClienteServicio);
    $("#txtCoordenadasServicioAsociado").val(servicioAsociado.ubicacionClienteServicio);
    $("#txtVelocidadServicioAsociado").val(servicioAsociado.velocidadClienteServicio);
    $("#txtPaqueteServicioAsociado").val(servicioAsociado.paqueteClienteServicio);
    $("#txtDetalleServicioAsociado").val(servicioAsociado.detallesClienteServicio);
    $("#selectEstadoServicioAsociado").val(servicioAsociado.estadoClienteServicio);
    $("#modalServiciosAsociados").modal('show');
            
        })

    //metodo para eliminar servicio Asociado a un Cliente
    $("#tblServicioAsociados tbody").on("click", ".btn-eliminarServicoAsociado", function () {
        let idServicio = $(this).data("id");
    let idCliente = $("#txtIdCliente").val(); // Aquí debes obtener el id del cliente
    console.log(idCliente);
    let resultado = window.confirm("¿Desea eliminar el Servicio?");
    if (resultado) {


        $.ajax({
            url: "../Home/deleteServicioAsociado",
            type: "DELETE",
            data: { id: idServicio },
            success: function (dataJson) {
                if (dataJson.valor) {
                    alert("Servicio Eliminado Correctamente");
                    listaServiciosAsociadosCliente(idCliente);
                }
            },
            error: function (xhr, status, error) {
                console.error("Error en la solicitud AJAX:", status, error);
            }
        });
            } 
        })
 