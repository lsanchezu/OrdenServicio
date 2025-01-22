<template>
    <div>
          <!-- Datos de la Solicitud --->
            <div class="ibox float-e-margins">
                <div class="ibox-title">
                    <h5>Datos de la Solicitud</h5>
                </div>
                <div class="ibox-content m-b-sm border-bottom">
                    <div class="row">
                        <div class="col-sm-4">
                            <div class="form-group">
                                <label class="control-label" for="customer">Nro. Solicitud</label>
                                <input type="text" id="order_id" name="order_id" v-model="solicitud.numeroSolicitud" class="form-control" readonly="readonly">
                            </div>
                        </div>
                        <div class="col-sm-4">
                            <div class="form-group">
                                <label class="control-label" for="order_id">Nombre del Solicitante</label>
                                <input type="text" id="order_id" name="order_id" v-model="solicitud.usuarioSolicitudDto.nombreApellido" class="form-control" readonly="readonly">
                            </div>
                        </div>
                        <div class="col-sm-4">
                            <div class="form-group">
                                <label class="control-label" for="status">Fecha Solicitud</label>
                                <input type="text" id="status" name="status" v-model="solicitud.fechaSolicitud" class="form-control" readonly>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-4">
                            <div class="form-group">
                                <label class="control-label" for="customer">Compañía</label>
                                <input type="text" id="order_id" name="order_id" v-model="solicitud.companiaDto.descripcion" class="form-control" readonly="readonly">
                            </div>
                        </div>
                        <div class="col-sm-4">
                            <div class="form-group">
                                <label class="control-label" for="order_id">Fuente de Contrato</label>
                                <input type="text" id="order_id" name="order_id" v-model="solicitud.fuenteContratoDto.descripcion" class="form-control" readonly="readonly">
                            </div>
                        </div>
                        <div class="col-sm-4">
                            <div class="form-group">
                                <label class="control-label" for="status">Proyecto</label>
                                <input type="text" id="order_id" name="order_id" v-model="solicitud.proyectoDto.descripcion" class="form-control" readonly="readonly">
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        
                        <div class="col-sm-4">
                            <div class="form-group">
                                <label class="control-label" for="customer">Fase del Proyecto</label>
                                 <input type="text" id="order_id" name="order_id" v-model="solicitud.faseProyectoDto.descripcion" class="form-control" readonly="readonly">
                            </div>
                        </div>
                        <div class="col-sm-4">
                            <div class="form-group">
                                <label class="control-label" for="order_id">Área</label>
                                <input type="text" id="order_id" name="order_id" v-model="solicitud.areaFuncionalDto.descripcion" class="form-control" readonly="readonly">
                            </div>
                        </div>
                        <div class="col-sm-4">
                            <div class="form-group">
                                <label class="control-label" for="customer">Categoría</label>
                                <input type="text" id="order_id" name="order_id" v-model="solicitud.categoriaDto.descripcion" class="form-control" readonly="readonly">
                            </div>
                        </div>
                    </div>
                    <div class="row">               
                        <div class="col-sm-4">
                            <div class="form-group">
                                <label class="control-label" for="customer">Tipo</label>
                                 <input type="text" id="order_id" name="order_id" v-model="solicitud.tipoDto.descripcion" class="form-control" readonly="readonly">
                            </div>
                        </div>
                    </div>                    
                </div>
            </div>
            <!-- Alcance del Servicio a Contratar  --->
            <div class="ibox float-e-margins">
                 <div class="ibox-title">
                    <h5>Alcance del Servicio a Contratar</h5>
                </div>
                <div class="ibox-content">
                    <div class="row">
                        <div class="col-sm-4">
                            <div class="form-group">
                                <label class="control-label" for="order_id">Moneda</label>
                                <input type="text" id="status" name="status" v-model="solicitud.monedaDto.descripcion" class="form-control" readonly="readonly">
                            </div>
                        </div>
                        <div class="col-sm-4">
                            <div class="form-group">
                                <label class="control-label" for="status">Monto Estimado</label>
                                <vue-numeric separator="," v-model="solicitud.montoEstimado" v-bind:precision="2" readonly="readonly"
                                placeholder="Ingresar monto" class="form-control" onkeypress="return validar_Numero_Punto(event)" maxlength="18"></vue-numeric>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-4">
                            <div class="form-group">
                                <label class="control-label" for="customer">Fecha Inicio</label>
                                <input type="text" id="txtfechaInicio" name="status" v-model="solicitud.fechaInicio" class="form-control" readonly="readonly">
                            </div>
                        </div>
                        <div class="col-sm-4">
                            <div class="form-group">
                                <label class="control-label" for="customer">Fecha Término</label>
                                <input type="text" id="txtfechaTermino" name="status" v-model="solicitud.fechaTermino" class="form-control" readonly="readonly">
                            </div>
                        </div>
                        <div class="col-sm-4">
                            <div class="form-group">
                                <label class="control-label" for="customer">Días Calendario</label>
                                <input type="text" id="txtfechaTermino" name="status" v-model="solicitud.diasCalendario" class="form-control" readonly="readonly">
                           </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- Descripción del Servicio --->
            <div class="ibox float-e-margins">
                 <div class="ibox-title">
                    <h5>Descripción del Servicio</h5>
                </div>
                <div class="ibox-content">
                    <div class="row">
                        <div class="col-sm-12">
                            <div class="form-group">
                                <label class="control-label" for="order_id">Denominación del Servicio</label>
                                <textarea class="form-control" rows="3" maxlength="1024" v-model="solicitud.denominacionServicio" 
                                placeholder="Ingrese la denominación del servicio" spellcheck="true" onkeypress="return val_DescripcionQ(event)" readonly="readonly"></textarea>
                            </div>
                        </div>
                        <div class="col-sm-12">
                            <div class="form-group">
                                <label class="control-label" for="status">Descripción del Servicio</label>
                                <textarea class="form-control" rows="3" maxlength="1024" v-model="solicitud.descripcionServicio" 
                                placeholder="Ingrese la descripción del servicio" spellcheck="true" onkeypress="return val_DescripcionQ(event)" readonly="readonly"></textarea>
                            </div>
                        </div>
                        <div class="col-sm-12">
                            <div class="form-group">
                                <label class="control-label" for="customer">Ubicación del Servicio</label>
                                <textarea class="form-control" rows="3" maxlength="1024" v-model="solicitud.ubicacionServicio" 
                                placeholder="Ingrese la ubicación del servicio" spellcheck="true" onkeypress="return val_DescripcionQ(event)" readonly="readonly"></textarea>
                            </div>
                        </div>
                       
                    </div>
                </div>
            </div>
            <!-- Proveedor/Contratista sugerido --->
            <div class="ibox float-e-margins">
                 <div class="ibox-title">
                    <h5>Proveedor/Contratista sugerido</h5>
                </div>
                <div class="ibox-content">
                    <div class="row">
                        <div class="col-sm-12">
                            <div class="table-responsive">
                                <table class="table table-striped">
                                    <thead>
                                        <tr>
                                            <th>ITEM</th>
                                            <th>NOMBRE</th>
                                            <th width="25%">RUC</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr v-for="(item, index) in solicitud.listaSolicitudProveedorContratistaDto" :key="index">
                                            <td>{{index + 1}}</td>
                                            <td>{{item.denominacionSocial}}</td>
                                            <td>{{item.documento}}</td>
                                       </tr>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <!-- Documentos Adjuntos --->
            <div class="ibox float-e-margins">
                 <div class="ibox-title">
                    <h5>Documentos Adjuntos</h5>
                </div>
                <div class="ibox-content">
                    <div class="row">
                        <div class="col-sm-12">
                            <button class="btn btn-sm btn-info" @click="decargarTodo()"><i class="fa fa-cloud-download"></i> <strong>Descargar Todo</strong></button>
                        </div>
                    </div>
                    <div class="row" v-for="item in solicitud.listaSolicitudDocumentoDto" :key="item.idSolicitudDocumento">
                         <div class="col-sm-12">
                            <div class="form-group">
                                <label class="control-label" for="order_id">{{item.tipoDocumentoDto.descripcion}}</label>&nbsp;
                            </div>
                        </div>
                        <div class="col-sm-12" v-if="item.listaSolicitudArchivoAdjuntoDto.length > 0">
                            <div class="col-sm-6">
                                <div class="table-responsive m-t">
                                    <table class="table table-striped">
                                        <thead>
                                            <tr>
                                                <th>ITEM</th>
                                                <th>NOMBRE</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr v-for="(archivo, index) in item.listaSolicitudArchivoAdjuntoDto" :key="index">
                                                <td>{{index + 1}}</td>
                                                <td><a @click="descargarArchivo($event, archivo)"> {{archivo.nombreArchivo}} </a></td>
                                            </tr>
                                        </tbody>                                                
                                    </table>
                                </div>
                            </div>
                        </div>  
                    </div>
                </div>
            </div>
            <!-- SOLE SOURCE:  Justificación de eleción del proveedor --->
            <div class="ibox float-e-margins" v-if="solicitud.fuenteContratoDto.idFuenteContrato === fuenteSoleSource">
                 <div class="ibox-title">
                    <h5>SOLE SOURCE:  Justificación de eleción del proveedor</h5>
                    
                </div>
                <div class="ibox-content">
                    <div class="row">
                        <div class="col-sm-12">
                            <textarea class="form-control" 
                                onkeypress="return val_DescripcionQ(event)"
                                rows="6"
                                maxlength="500" 
                                v-model="solicitud.justificacionSoleSource"
                                spellcheck="true" readonly></textarea>
                        </div>
                    </div>    
                </div>
            </div>
            
            <div class="ibox-content">
                  <!-- VALIDACION --->

                    <solicitud-validacion v-if="solicitud.solicitudValidacionDto.usuarioDto.nombreApellido != null" 
                                        :solicitudValidacion="solicitud.solicitudValidacionDto" 
                                        :flagRegistrar="solicitud.flagRegistrarValidacion"  
                                        @registrarValidacion="registrarValidacion">
                    </solicitud-validacion>

                    <!-- RECOMENDACIÓN DE PROCURA CONTRATO --->
                    <solicitud-recomendacion v-if="solicitud.solicitudRecomendacionDto.usuarioDto.nombreApellido != null" 
                                        :solicitudRecomendacion="solicitud.solicitudRecomendacionDto"
                                        :flagRegistrar="solicitud.flagRegistrarRecomendacion"  
                                        @registrarRecomendacion="registrarRecomendacion">

                    </solicitud-recomendacion>

                    <!-- AUTORIZACIÓN --->
                    <solicitud-autorizacion v-if="solicitud.flagRegistrarAutorizacion || solicitud.listaSolicitudAutorizacionDto.length > 0"
                                            :listaSolicitudAutorizacion= solicitud.listaSolicitudAutorizacionDto
                                            :solicitudAutorizacion= solicitud.solicitudAutorizacionDto
                                            :flagRegistrar="solicitud.flagRegistrarAutorizacion"  
                                            @registrarAprobacionSolicitud="registrarAprobacionSolicitud">

                    </solicitud-autorizacion>
            </div>
    </div>
</template>
<script>

import VueNumeric from 'vue-numeric'
import SolicitudService from '@/services/solicitud.service'
import { FUENTE_CONTRATO_SOLE_SOURCE} from '@/constants/solicitud.constants'

import SolicitudValidacion from './SolicitudValidacion'
import SolicitudRecomendacion from './SolicitudRecomendacion'
import SolicitudAutorizacion from './SolicitudAutorizacion'
import SwalAlert from '@/common/swal.alert'

export default {
    name: "detalle-solicitud-ordenservicio",
    components:{
        VueNumeric,
        SolicitudValidacion,
        SolicitudRecomendacion,
        SolicitudAutorizacion
    },
    props: {
        idSolicitudOrdenServicio: {type: Number,required: false, default : 0}
    },
    data(){
        return {
            solicitud: {},
            solicitudRecomendacion: {},
            listaAutorizacion: {},
            fuenteSoleSource: FUENTE_CONTRATO_SOLE_SOURCE,
            initialSolicitud: {
                companiaDto: {descripcion: ""},
                fuenteContratoDto: {descripcion: ""},
                proyectoDto: {descripcion: ""},
                faseProyectoDto:{descripcion: ""},
                usuarioSolicitudDto: {nombreApellido: ""},
                categoriaDto:{descripcion: ""},
                areaFuncionalDto: {descripcion: ""},
                tipoDto: {descripcion: ""},
                listaSolicitudDocumentoDto: [],
                monedaDto: {descripcion: ""},
                paisDto: {descripcion: ""},
                fechaSolicitud: "",
                montoEstimado: 0.00,
                fechaInicio: "",
                fechaTermino: "",
                diasCalendario: "",
                listaSolicitudAutorizacionDto:[],
                solicitudValidacionDto: {
                    usuarioDto: {nombreApellido: ""}
                },
                solicitudRecomendacionDto: {
                    usuarioDto: {nombreApellido: ""}
                },
                solicitudAutorizacionDto: {}
            }
        }
    },
    created(){
        this.solicitud = Object.assign({}, this.initialSolicitud);
    },
    mounted() {
        this.inicializar();
    },
    methods: {
        cerrarPopupEvent(){
            this.$emit('cerrarPopupEvent');
        },
        inicializar(){
            var self = this
            SolicitudService.obtenerSolicitud({ 'idSolicitudOrdenServicio': this.idSolicitudOrdenServicio})
            .then(response => {
                self.solicitud = response.data.solicitud
            });
        },
        descargarArchivo(event, archivo){
            window.open(`/SolicitudOrdenServicio/DescargarArchivo?idSolicitudArchivoAdjunto=${archivo.idSolicitudArchivoAdjunto}`);
        },
        decargarTodo(){
            window.open(`/SolicitudOrdenServicio/DescargarTodo?numeroSolicitud=${this.solicitud.numeroSolicitud}`);
        },
        registrarValidacion(solicitudValidacion){
            var self = this

            solicitudValidacion.IdSolicitudOrdenServicio = this.solicitud.IdSolicitudOrdenServicio;
            solicitudValidacion.idFuenteContrato = this.solicitud.fuenteContratoDto.idFuenteContrato;

            SolicitudService.registrarSolicitudValidacion(solicitudValidacion).then(response => {
                if(response.data.flagError){
                    swal("Mensaje", response.data.mensaje, "warning");
                    return;
                }

                SwalAlert.successAction(response.data.mensaje, self.cerrarPopup);
                self.inicializar();
                self.$emit('consultarSolicitudEvent');
            });
        },
        registrarRecomendacion(solicitudRecomendacion){
            var self = this
            solicitudRecomendacion.IdSolicitudOrdenServicio = this.solicitud.IdSolicitudOrdenServicio;

            SolicitudService.registrarSolicitudRecomendacion(solicitudRecomendacion).then(response => {
                if(response.data.flagError){
                    swal("Mensaje", response.data.mensaje, "warning");
                    return;
                }

                SwalAlert.successAction(response.data.mensaje, self.cerrarPopup);
                self.inicializar();
                self.$emit('consultarSolicitudEvent');
            });
        },
        registrarAprobacionSolicitud(solicitudAutorizacion){
            var self = this
            solicitudAutorizacion.IdSolicitudOrdenServicio = this.solicitud.IdSolicitudOrdenServicio;

            SolicitudService.registrarSolicitudAutorizacion(solicitudAutorizacion).then(response => {
                if(response.data.flagError){
                    swal("Mensaje", response.data.mensaje, "warning");

                    return;
                }

                SwalAlert.successAction(response.data.mensaje, self.cerrarPopup);
                self.inicializar();
                self.$emit('consultarSolicitudEvent');
            });
        },
        cerrarPopup(){
            this.$emit('cerrarPopupEvent')
        }
    },
}
</script>