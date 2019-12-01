
closeOverlay = () => {
    document.getElementById("myNav").style.width = "0%";
}

endOverlay = () => {
    document.getElementById("myx").classList.remove('hide');
    document.getElementById("mydetalle").classList.add('hide');
}


// Mensaje que aparece abajo cuando se guarda, edita, ocurre un error

snackbar = (message) => {
    var notify = document.querySelector('#snackbar');
    notify.innerText = message;
    notify.className = 'show';

    setTimeout(function () {
        notify.className = notify.className.replace('show', '');
    }, 3000);
};


var app = angular.module('template-app', ['ngRoute']);

// Cuando se va a subir el proyecto descomentar esta linea y adaptarlo
// al nombre de su proyecto en el servidor

//var uriApi = 'http://schi-iis1zem/ZCUU_ZEM_Activos';
var uriApi = 'http://schi-web1zem/ZCUU_ZEM_Activos';

// Mientras trabaje de forma local utilice la siguiente linea y al momento
// de subir su proyecto comentela dejando solo la de arriba sin comentar
// No olvide cambiar el puerto de su localhost

//var uriApi = 'http://localhost:64057/';

var errorMessage = 'Ocurrio un error! El servidor dejo de responder, intente de nuevo.';

app.config(function ($routeProvider) {
    $routeProvider
        .when('/NationalsView', {
            templateUrl: 'NationalsView'
        })
        .when('/Foreign', {
            templateUrl: 'Foreign'
        })
        .when('/UsuariosSistemas', {
            templateUrl: 'UsuariosSistemas'
        })
        .otherwise({
            templateUrl: 'NationalsView'
        });
});

/*############################ EXTRANJEROS CONTROLLER ############################################*/
app.controller('foreign-controller', ($scope, $http) => {
    // Get all from extranjeros 
    $http.get(`${uriApi}/api/Extranjeros`).then((response) => {
        $scope.foreigns = response.data;
    }).catch((error) => {
        snackbar("Data can't be loaded");
    });

    // Get one
    $scope.selectForeign = (id) => {
        $scope.modal_title = "edit";
        document.getElementById('foreignModalLabel').innerHTML = '<ion-icon name="create"></ion-icon> Editar Activo';
        $http.get(`${uriApi}/api/Extranjeros/${id}`).then((response) => {
            $scope.no_parte = response.data.NoParte;
            $scope.no_factura = response.data.NoFactura;
            $scope.fecha = response.data.Fecha;
            $scope.cantidad = response.data.Cantidad;
            $scope.costo_unit = response.data.CostoUnit;
            $scope.tipo_mcia = response.data.TipoMcia;
            $scope.cve_pais = response.data.CvePais;
            $scope.desc_esp = response.data.DescEsp;
            $scope.desc_ing = response.data.DescIng;
            $scope.marca = response.data.Marca;
            $scope.modelo = response.data.Modelo;
            $scope.serie = response.data.Serie;
            $scope.fr_mex_imp = response.data.FrMexImp;
            $scope.cve_um = response.data.CveUm;
            $scope.pedimento = response.data.Pedimento;
            $scope.proveedor = response.data.Proveedor;
            $scope.eqiqueta = response.data.Etiqueta;
            $scope.placas = response.data.Placas;
            $scope.no_packing = response.data.NoPacking;
            $scope.comment1 = response.data.Comment1;
            $scope.comment2 = response.data.Comment2;
            $scope.comment3 = response.data.Comment3;
            $scope.tipo_imp = response.data.TipoImp;
            $scope.test1 = response.data.Test1;
            $scope.division = response.data.Division;
            $scope.no_zem = response.data.NoZEM;
            $scope.no_ext = response.data.NoExt;
            $scope.location = response.data.Location;
            $scope.status = response.data.Status;
        }).then((error) => {
            snackbar(errorMessage);
        });
    }

    // Delete one
    $scope.deleteForeing = (id) => {
        Swal.fire({
            type: "question",
            title: "Eliminar",
            text: `¿Seguro qué deseas eliminar el registro?`,
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Confirmar'
        }).then((result) => {
            if (result.value) {
                $http.delete(`${uriApi}/api/Extranjeros/${id}`).then((response) => {
                    $scope.idNumero = 0;
                    $scope.numero = '';
                }).catch((error) => {
                    snackbar(errorMessage)
                });
                $http.get(`${uriApi}/api/Extranjeros/`).then((response) => {
                    Swal.fire(
                        'Eliminado',
                        `Registro sido eliminado`,
                        'success'
                    )
                }).catch((error) => {
                    snackbar(errorMessage)
                });
            }
            $http.get(`${uriApi}/api/Extranjeros`).then((response) => {
                $scope.foreigns = response.data;

            });
        })
    }

    // Insert of edit
    $scope.addorupdateForeign = () => {
        if ($scope.foreignForm.$valid) {
            //debugger;
            if ($scope.modal_title == 'edit') {
                $http.put(`${uriApi}/api/Extranjeros/${$scope.no_parte}`, {
                    NoParte: $scope.no_parte,
                    NoFactura: $scope.no_factura,
                    Fecha: $scope.fecha,
                    Cantidad: $scope.cantidad,
                    CostoUnit: $scope.costo_unit,
                    TipoMcia: $scope.tipo_mcia,
                    CvePais: $scope.cve_pais,
                    DescEsp: $scope.desc_esp,
                    DescIng: $scope.desc_ing,
                    Marca: $scope.marca,
                    Modelo: $scope.modelo,
                    Serie: $scope.serie,
                    FrMexImp: $scope.fr_mex_imp,
                    CveUm: $scope.cve_um,
                    Pedimento: $scope.pedimento,
                    Proveedor: $scope.proveedor,
                    Etiqueta: $scope.eqiqueta,
                    Placas: $scope.placas,
                    NoPacking: $scope.no_packing,
                    Comment1: $scope.comment1,
                    Comment2: $scope.comment2,
                    Comment3: $scope.comment3,
                    TipoImp: $scope.tipo_imp,
                    Test1: $scope.test1,
                    Division: $scope.division,
                    NoZEM: $scope.no_zem,
                    NoExt: $scope.no_ext,
                    Location: $scope.location,
                    Status: $scope.status,
                }).then((response) => {
                    snackbar('Datos Guardados');
                    Swal.fire(
                        'Guardado',
                        `Registro sido guardado`,
                        'success'
                    )
                    $http.get(`${uriApi}/api/Extranjeros`).then((response) => {
                        $scope.foreigns = response.data;
                    });
                }).catch((error) => {
                    alert(error.statusText)
                    if (error.statusText === 'Conflict') {
                        snackbar("El activo ya habia sido guradado anteriormente")
                    } else {
                        snackbar(errorMessage)
                    }
                });
                $scope.modal_title = "";
                return;
            }
            $http.post(`${uriApi}/api/Extranjeros`, {
                NoParte: $scope.no_parte,
                NoFactura: $scope.no_factura,
                Fecha: $scope.fecha,
                Cantidad: $scope.cantidad,
                CostoUnit: $scope.costo_unit,
                TipoMcia: $scope.tipo_mcia,
                CvePais: $scope.cve_pais,
                DescEsp: $scope.desc_esp,
                DescIng: $scope.desc_ing,
                Marca: $scope.marca,
                Modelo: $scope.modelo,
                Serie: $scope.serie,
                FrMexImp: $scope.fr_mex_imp,
                CveUm: $scope.cve_um,
                Pedimento: $scope.pedimento,
                Proveedor: $scope.proveedor,
                Etiqueta: $scope.eqiqueta,
                Placas: $scope.placas,
                NoPacking: $scope.no_packing,
                Comment1: $scope.comment1,
                Comment2: $scope.comment2,
                Comment3: $scope.comment3,
                TipoImp: $scope.tipo_imp,
                Test1: $scope.test1,
                Division: $scope.division,
                NoZEM: $scope.no_zem,
                NoExt: $scope.no_ext,
                Location: $scope.location,
                Status: $scope.status
            }).then((response) => {
                snackbar('Datos Guardados');
                Swal.fire(
                    'Guardado',
                    `Registro sido guardado`,
                    'success'
                )
                $http.get(`${uriApi}/api/Extranjeros`).then((response) => {
                    $scope.foreigns = response.data;
                });
            }).catch((error) => {
                alert(error.statusText)
                if (error.statusText === 'Conflict') {
                    Swal.fire(
                        'Error',
                        `El activo ya se encuentra en la DB.`,
                        'error'
                    )
                } else {
                    snackbar(errorMessage);
                }
            });
        }
    };

    // Clean modal form
    $scope.cleanForeign = () => {
        document.getElementById('foreignModalLabel').innerHTML = '<ion-icon name="add"></ion-icon> Nuevo Activo';
        $scope.no_parte = "";
        $scope.no_factura = "";
        $scope.fecha = "";
        $scope.cantidad = "";
        $scope.costo_unit = "";
        $scope.tipo_mcia = "";
        $scope.cve_pais = "";
        $scope.desc_esp = "";
        $scope.desc_ing = "";
        $scope.marca = "";
        $scope.modelo = "";
        $scope.serie = "";
        $scope.fr_mex_imp = "";
        $scope.cve_um = "";
        $scope.pedimento = "";
        $scope.proveedor = "";
        $scope.eqiqueta = "";
        $scope.placas = "";
        $scope.no_packing = "";
        $scope.comment1 = "";
        $scope.comment2 = "";
        $scope.comment3 = "";
        $scope.tipo_imp = "";
        $scope.test1 = "";
        $scope.division = "";
        $scope.no_zem = "";
        $scope.no_ext = "";
        $scope.location = "";
        $scope.status = "";
    };
});





app.controller('test-controller', ($scope, $http) => {

    // Download Database
    $scope.uploadNationalData = () => {
        window.open('../MotherFucker.xls');
        $http.get(`${uriApi}/api/Data/`).then((response) => {
            alert(response);
            console.log(response);
        });
    };


    ////////////////////////////////////  TRAERSE LOS REGISTROS DE LA BASE DE DATOS  ///////////////////////////////////////

    $http.get(`${uriApi}/api/Nacionales`).then((response) => {
        $scope.examples = response.data;
    }).catch((error) => {
        snackbar(errorMessage)
    });

    ////////////////////////////////////  SELECCIONAR UN REGISTRO  ///////////////////////////////////////

    $scope.select = (id) => {
        $scope.modal_title = "edit";
        document.getElementById('exampleModalLabel').innerHTML = '<ion-icon name="create"></ion-icon> Editar Activo'; 
        $http.get(`${uriApi}/api/Nacionales/${id}`).then((response) => {
            $scope.no_asset = response.data.NoActivo;
            $scope.company = response.data.Company;
            $scope.division = response.data.Division;
            $scope.subnumber = response.data.SubNumber;
            $scope.status = response.data.Status;
            $scope.name = response.data.Name;
            $scope.textline1 = response.data.TextLine1;
            $scope.dimension4 = response.data.AccountingDimension4;
            $scope.dimension6 = response.data.AccountingDimension6;
            $scope.lifetime = response.data.LifetimeInMonths;
            $scope.price = response.data.AcquisitionPrice;
            $scope.cost = response.data.AcquisitionCost;
            $scope.linear = response.data.ForecastLinear;
            $scope.derogatory = response.data.ForecastDerogatory;
            $scope.final_status = response.data.StatusFinal;
            $scope.comment = response.data.Comment;
            
        }).catch((error) => {
            snackbar(errorMessage)
        });
    };

    ////////////////////////////////////  ELIMINAR UN REGISTRO  /////////////////////////////////////// 

    $scope.delete = (id) => {
        Swal.fire({
            type: "question",
            title: "Eliminar",
            text: `¿Seguro qué deseas eliminar el registro?`,
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Confirmar'
        }).then((result) => {
            if (result.value) {
                $http.delete(`${uriApi}/api/Nacionales/${id}`).then((response) => {
                    $scope.idNumero = 0;
                    $scope.numero = '';
                    $http.get(`${uriApi}/api/Nacionales/`).then((response) => {
                        $scope.examples = response.data;
                        Swal.fire(
                            'Eliminado',
                            `Registro sido eliminado`,
                            'success'
                        )
                    }).catch((error) => {
                        snackbar(errorMessage)
                    });
                }).catch((error) => {
                    snackbar(errorMessage)
                });
                
            }
            $http.get(`${uriApi}/api/Nacionales`).then((response) => {
                $scope.examples = response.data;

            });
        })
    };

    ////////////////////////////////////  CREAR O EDITAR UN REGISTRO  ////////////////////////////////////////

    $scope.addorupdate = () => {
        if ($scope.nuevoForm.$valid) {
            //debugger;
            if ($scope.modal_title == 'edit') {
                $http.put(`${uriApi}/api/Nacionales/${$scope.no_asset}`, {
                    NoActivo: $scope.no_asset,
                    Company: $scope.company,
                    Division: $scope.division,
                    SubNumber: $scope.subnumber,
                    Status: $scope.status,
                    Name: $scope.name,
                    TextLine1: $scope.textline1,
                    AccountingDimension4: $scope.dimension4,
                    AccountingDimension6: $scope.dimension6,
                    LifetimeInMonths: $scope.lifetime,
                    AcquisitionPrice: $scope.price,
                    AcquisitionCost: $scope.cost,
                    ForecastLinear: $scope.linear,
                    ForecastDerogatory: $scope.derogatory,
                    StatusFinal: $scope.final_status,
                    Comment: $scope.comment
                }).then((response) => {
                    snackbar('Datos Guardados');
                    Swal.fire(
                        'Guardado',
                        `Registro sido guardado`,
                        'success'
                    )
                    $http.get(`${uriApi}/api/Nacionales`).then((response) => {
                        $scope.examples = response.data;
                    });
                }).catch((error) => {
                    alert(error.statusText)
                    if (error.statusText === 'Conflict') {
                        snackbar("El activo ya habia sido guradado anteriormente")
                    } else {
                        snackbar(errorMessage)
                    }
                    });
                $scope.modal_title = "";
                return;
            }
            $http.post(`${uriApi}/api/Nacionales`, {
                NoActivo: $scope.no_asset,
                Company: $scope.company,
                Division: $scope.division,
                SubNumber: $scope.subnumber,
                Status: $scope.status,
                Name: $scope.name,
                TextLine1: $scope.textline1,
                AccountingDimension4: $scope.dimension4,
                AccountingDimension6: $scope.dimension6,
                LifetimeInMonths: $scope.lifetime,
                AcquisitionPrice: $scope.price,
                AcquisitionCost: $scope.cost,
                ForecastLineart: $scope.linear,
                StatusFial: $scope.finalStatus,
                Comment: $scope.comment
            }).then((response) => {
                snackbar('Datos Guardados');
                Swal.fire(
                    'Guardado',
                    `Registro sido guardado`,
                    'success'
                )
                $http.get(`${uriApi}/api/Nacionales`).then((response) => {
                    $scope.examples = response.data;
                });
                }).catch((error) => {
                    alert(error.statusText)
                    if (error.statusText === 'Conflict') {
                        Swal.fire(
                            'Error',
                            `El activo ya se encuentra en la DB.`,
                            'error'
                        )
                    } else {
                        snackbar(errorMessage);
                    }
            });
            
        }
    };

    ////////////////////////////////////  LIMPIAR VENTANA UN REGISTRO  /////////////////////////////////////// 

    $scope.clean = (id) => {
        document.getElementById('exampleModalLabel').innerHTML = '<ion-icon name="add"></ion-icon> Nuevo Activo';
        $scope.no_asset = "";
        $scope.company = "";
        $scope.division = "";
        $scope.subnumber = "";
        $scope.status = "";
        $scope.name = "";
        $scope.textline1 = "";
        $scope.dimension4 = "";
        $scope.dimension6 = "";
        $scope.lifetime = "";
        $scope.price = "";
        $scope.cost = "";
        $scope.linear = "";
        $scope.final_status = "";
        $scope.comment = "";
    };

});

//////////////////////////////////////////////// CONTROLADOR DE USUARIOS ////////////////////////////////////////////////////////////////////////////
var id_sistema = 4;
app.controller("usuarios-sistemas-Controller", function ($scope, $http, $routeParams) {
    $scope.accion = "Crear Usuario";
    $scope.nuevo = true;
    $scope.id_usuario = 0;
    $scope.usuario = "";

    $http.get(`${uriApi}/api/FiltrosUsuarios/getValor?tipo=3&id1=${id_sistema}`).then((response) => {

        $scope.usuarios = response.data;
    });

    $http.get(`${uriApi}/api/FiltrosUsuarios/getValor?tipo=6&id1=${id_sistema}`).then((response) => {

        $scope.usuariosdivisiones = response.data;
    });

    $http.get(`${uriApi}/api/FiltrosUsuarios/getValor?tipo=1&id1=${id_sistema}`).then(function (response) {
        $scope.rolesporsistema = response.data;
        var index = $scope.rolesporsistema.find(x => x.Descripcion == "Operativo Sistemas");
        $scope.rolusuario = index;
    });

    $http.get(`${uriApi}/api/Divisiones`).then(function (response) {
        $scope.divisiones = response.data;
    });

    $scope.empleadoDivisiones = [];
    $scope.Editar = function (id_usuario) {
        $scope.accion = "Editar Usuario";
        $scope.LimpiarUsuario();
        $http.get(`${uriApi}/api/Usuarios/${id_usuario}`).then(function (response) {
            $scope.id_usuario = response.data.Id;
            $scope.usuario = response.data.Usuario;
            $scope.correo = response.data.Email;


            $http.get(`${uriApi}/api/FiltrosUsuarios/getValor?tipo=2&id1=${id_sistema}&id2=${id_usuario}`).then(function (response) {
                var Id_rol = "";
                if (response.data.length > 0) {
                    Id_rol = "" + response.data[0].Id_Rol;
                }
                //$scope.myVar = Id_rol;
                var index = $scope.rolesporsistema.find(x => x.Id == Id_rol);
                $scope.rolusuario = index;

                $http.get(`${uriApi}/api/FiltrosUsuarios/getValor?tipo=5&id1=${id_sistema}&strValor=${$scope.usuario}`).then(function (response) {
                    usuarioDivisiones = response.data;
                    $scope.empleadoDivisiones = response.data;
                });



            });
        });
    }

    $scope.chageValue = function (Id_rol) {
        $scope.myVar = Id_rol;
    };

    $scope.BuscarUsuario = function () {

        var usuario = $scope.usuario;
        $scope.LimpiarUsuario();
        $scope.usuario = usuario;
        $http.get(`${uriApi}/api/FiltrosUsuarios/getValor?tipo=4&strValor=${$scope.usuario}`).then(function (response) {
            var Id_rol = "";
            if (response.data.length === 0) {
                $http.get(`${uriApi}/api/FiltrosUsuarios/getInfo?strValor=${$scope.usuario}`).then(function (response) {
                    if (response.data.usuario === "") {
                        snackbar("Usuario no encontrado");
                        $scope.usuario = "";
                        $scope.correo = "";
                    } else {
                        $scope.usuario = response.data.usuario;
                        $scope.correo = response.data.correo;
                    }
                }).catch(function (response) {
                    snackbar(strMensajeError);
                });
            }
            else {
                $scope.id_usuario = response.data[0].Id;
                $scope.usuario = response.data[0].Usuario;
                $scope.correo = response.data[0].Email;
            }
        });


    }

    $scope.LimpiarUsuario = function () {
        $scope.id_usuario = 0;
        $scope.usuario = "";
        $scope.correo = "";
        $scope.myVar = "";
        $scope.empleadoDivisiones = [];
        $scope.rolusuario = [];
        usuarioDivisiones = [];
        $http.get(`${uriApi}/api/Divisiones`).then(function (response) {
            $scope.divisiones = response.data;
        });
        $http.get(`${uriApi}/api/FiltrosUsuarios/getValor?tipo=1&id1=${id_sistema}`).then(function (response) {
            $scope.rolesporsistema = response.data;
            var index = $scope.rolesporsistema.find(x => x.Descripcion == "Operativo Sistemas");
            $scope.rolusuario = index;
        });
    }

    $scope.delete = function (id_usuario) {

        $http.get(`${uriApi}/api/Usuarios/${id_usuario}`).then(function (response) {
            var usuario = response.data.Usuario;
            var id_usuario = response.data.Id;
            Swal.fire({
                title: `Deseas dar de baja el usuario ${response.data.Usuario}?`,
                //text: "Baja Usuario",
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Aceptar'
            }).then((result) => {
                if (result.value) {
                    $http.delete(`${uriApi}/api/FiltrosUsuarios/delete?tipo=1&id1=${id_sistema}&strValor=${usuario}`).then(function (response) {
                        $http.get(`${uriApi}/api/FiltrosUsuarios/getValor?tipo=2&id1=${id_sistema}&id2=${id_usuario}`).then(function (response) {
                            var id_usuario_rol = response.data[0].Id;
                            $http.delete(`${uriApi}/api/UsuarioRoles/${id_usuario_rol}`).then(function (data) {
                                $scope.LimpiarUsuario();
                                Swal.fire(
                                    'Eliminado',
                                    `Usuario Eliminado`,
                                    'success'
                                )
                                $http.get(`${uriApi}/api/FiltrosUsuarios/getValor?tipo=3&id1=${id_sistema}`).then((response) => {
                                    $scope.usuarios = response.data;
                                });
                                $http.get(`${uriApi}/api/FiltrosUsuarios/getValor?tipo=6&id1=${id_sistema}`).then((response) => {
                                    $scope.usuariosdivisiones = response.data;
                                });
                            }).error(function (data) {
                                snackbar(strMensajeError);
                            });
                        });
                    });
                }
            })
        });
    }

    $scope.addorupdateUser = function () {
        if ($scope.mainForMasterUsuario.$valid) {
            var Usuario = {
                Id: $scope.id_usuario,
                Usuario: $scope.usuario,
                Email: $scope.correo
            };

            //Guardar y/o actualizar usuario
            $http.post(`${uriApi}/api/Usuarios`, Usuario).then(function (response) {
                $scope.id_usuario = response.data.Id;
                $http.get(`${uriApi}/api/FiltrosUsuarios/getValor?tipo=2&id1=${id_sistema}&id2=${$scope.id_usuario}`).then(function (response) {
                    var Id = 0;
                    if (response.data.length > 0) {
                        Id = response.data[0].Id;
                    }
                    var usuariorol = {
                        Id: Id,
                        Id_Usuario: $scope.id_usuario,
                        Id_rol: $scope.rolusuario.Id,
                    };
                    $http.post(`${uriApi}/api/UsuarioRoles`, usuariorol).then(function (data) {
                        $scope.guardardivisiones(0);
                    }).error(function (data) {
                        snackbar(strMensajeError);
                    });
                });
                debugger;
                $http.get(`${uriApi}/api/FiltrosUsuarios/getValor?tipo=3&id1=${id_sistema}`).then((response) => {
                    $scope.usuarios = response.data;
                });
                $http.get(`${uriApi}/api/FiltrosUsuarios/getValor?tipo=6&id1=${id_sistema}`).then((response) => {
                    $scope.usuariosdivisiones = response.data;
                });
            }).error(function (data) {
                snackbar(strMensajeError);
            });
        }
    }

    $scope.guardardivisiones = function (index) {
        if (index < usuarioDivisiones.length) {
            if (usuarioDivisiones[index].Valor) {
                var usuariorol = {
                    Id: usuarioDivisiones[index].Id,
                    Id_Usuario: $scope.id_usuario,
                    Id_Division: usuarioDivisiones[index].Id_Division,
                    Id_Sistema: id_sistema,
                };

                $http.post(`${uriApi}/api/UsuarioDivisiones`, usuariorol).then(function (data) {
                    index++;

                    $scope.guardardivisiones(index);

                }).error(function (data) {
                    snackbar(strMensajeError);
                });


            }
            else {


                $http.delete(`${uriApi}/api/UsuarioDivisiones/${usuarioDivisiones[index].Id}`, usuariorol).then(function (data) {
                    index++;

                    $scope.guardardivisiones(index);

                }).error(function (data) {
                    snackbar(strMensajeError);
                });

            }

        }
        else {
            $scope.LimpiarUsuario();
            snackbar(strMensaje);
            $http.get(`${uriApi}/api/FiltrosUsuarios/getValor?tipo=3&id1=${id_sistema}`).then((response) => {
                $scope.usuarios = response.data;
            });

            debugger;
            $http.get(`${uriApi}/api/FiltrosUsuarios/getValor?tipo=3&id1=${id_sistema}`).then((response) => {
                $scope.usuarios = response.data;
            });

            $http.get(`${uriApi}/api/FiltrosUsuarios/getValor?tipo=6&id1=${id_sistema}`).then((response) => {
                $scope.usuariosdivisiones = response.data;
            });
        }
    }


});


var usuarioDivisiones = [];
function addordeletedivision(checkbox) {
    var blnValue = checkbox.checked;
    var Id_Division = checkbox.id.replace("chk-", "");
    var index = usuarioDivisiones.find(x => x.Id_Division == Id_Division);
    if (index === undefined) {

        usuarioDivisiones.push({ Id: 0, Id_Division: Id_Division, Valor: true, Existe: 0 });
    }
    else {

        if (index.Existe === 0) {
            var index = usuarioDivisiones.findIndex(x => x.Id_Division == Id_Division);
            usuarioDivisiones.splice(index, 1);
        }
        else {
            index.Valor = blnValue;
        }
    }
}
