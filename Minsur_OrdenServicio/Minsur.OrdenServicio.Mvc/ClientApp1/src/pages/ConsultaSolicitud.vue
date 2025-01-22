<template>
    <div>
        <div class="row wrapper border-bottom white-bg page-heading">
            <div class="col-lg-10">
                <h2>Consultar Solicitud de Contratación</h2>
                <ol class="breadcrumb">
                    <li>
                        <a href="">Home</a>
                    </li>
                    <li>
                        <a>Reporte</a>
                    </li>
                    <li class="active">
                        <strong>Consulta</strong>
                    </li>
                </ol>
            </div>
            <div class="col-lg-2">

            </div>
        </div>

        <div class="wrapper wrapper-content" id="reporte">
            <div class="report-content">
                <div class="row">
                    <div class="col-lg-12">
                        <div class="ibox-title">
                            <h5>:: CRITERIOS DE BÚSQUEDA</h5>
                        </div>
                        <div class="ibox-content m-b-sm border-bottom">
                            <div class="row">
                                <div class="col-sm-4">
                                    <div class="form-group">
                                        <label class="control-label" for="customer">Compañía</label>
                                        <select name="status"  class="form-control" v-model="idCompania" @change="listarProyecto">
                                            <option v-for="item in listaCompania" v-bind:value="item.idCompania" :key="item.idCompania">{{ item.descripcion }}</option>
                                        </select>
                                    </div>
                                </div>
                                <div class="col-sm-4">
                                    <div class="form-group">
                                        <label class="control-label" for="order_id">Fuente de Contratación</label>
                                        <select name="status"  class="form-control" v-model="idFuenteContrato">
                                            <option v-for="item in listaFuenteContrato" v-bind:value="item.idFuenteContrato" :key="item.idFuenteContrato">{{ item.descripcion }}</option>
                                        </select>
                                    </div>
                                </div>
                                <div class="col-sm-4">
                                    <div class="form-group">
                                        <label class="control-label" for="status">Proyecto</label>
                                        <select name="status"  class="form-control" v-model="idProyecto">
                                            <option value="0">:: TODOS ::</option>
                                            <option v-for="item in listaProyecto" v-bind:value="item.idProyecto" :key="item.idProyecto">{{ item.descripcion }}</option>
                                        </select>
                                    </div>
                                </div>
                               
                            </div>
                            <div class="row">
                                <div class="col-sm-4">
                                    <div class="form-group">
                                        <label class="control-label" for="customer">Fase del Proyecto</label>
                                        <select name="status"  class="form-control" v-model="idFaseProyecto">
                                            <option v-for="item in listaFaseProyecto" v-bind:value="item.idFaseProyecto" :key="item.idFaseProyecto">{{ item.descripcion }}</option>
                                        </select>
                                    </div>
                                </div>

                                
                                 <div class="col-sm-4">
                                    <div class="form-group">
                                        <label class="control-label" for="order_id">Área</label>
                                        <select name="status"  class="form-control" v-model="idAreaFuncional">
                                            <option v-for="item in listaAreaFuncional" v-bind:value="item.idAreaFuncional" :key="item.idAreaFuncional">{{ item.descripcion }}</option>
                                        </select>
                                    </div>
                                </div> 
                                <div class="col-sm-4">
                                    <div class="form-group">
                                        <label class="control-label" for="order_id">Estado</label>
                                        <select name="status"  class="form-control" v-model="idEstado">
                                            <option v-for="item in listaEstado" v-bind:value="item.idEstado" :key="item.idEstado">{{ item.nombre.toUpperCase() }}</option>
                                        </select>
                                    </div>
                                </div>
                               
                            </div>
                            <div class="row">
                                <div class="col-sm-4">
                                    <div class="form-group">
                                        <label class="control-label" for="customer" style="display:block">Fecha Inicio</label>
                                        <el-date-picker  v-model="fechaInicio"  type="date" format="dd/MM/yyyy" value-format="dd/MM/yyyy" placeholder="Seleccione fecha" @change="validarFechaInicio()">
                                        </el-date-picker>
                                    </div>
                                </div>
                                <div class="col-sm-4">
                                    <div class="form-group">
                                       <label class="control-label" for="customer" style="display:block">Fecha Fin</label>
                                        <el-date-picker v-model="fechaFin"  type="date" format="dd/MM/yyyy" value-format="dd/MM/yyyy" placeholder="Seleccione fecha" @change="validarFechaFin()">
                                        </el-date-picker>
                                    </div>
                                </div>
                                
                            </div>
                            <div class="row">
                                <div class="col-sm-12">
                                    <div class="text-right">
                                        <button class="btn btn-sm btn-primary btn-buscar" @click="consultarSolicitud()"><i class="fa fa-search"></i> <strong>Buscar</strong></button>
                                        <button class="btn btn-sm btn-info" @click="exportarConsulta()"><i class="fa fa-cloud-download" ></i> <strong>Exportar Por Solicitud</strong></button>
                                        <button class="btn btn-sm btn-info" @click="exportarConsultaPorProveedor()"><i class="fa fa-cloud-download" ></i> <strong>Exportar Por Proveedor</strong></button>
                                    </div>
                                </div>
                            </div>
                            
                        </div>
                    </div>

                </div>
                <div class="row">
                    <div class="col-lg-12">
                        <div class="ibox-title">
                            <h5>:: RESULTADOS DE LA BÚSQUEDA</h5>
                        </div>
                        <div class="ibox">
                            <div class="ibox-content">
                                <div class="table-responsive m-t">
                                    <table class="table table-striped custom-table" >
                                        <thead>
                                            <tr>
                                                <th data-toggle="true" class="text-center">Nro. Solicitud</th>
                                                <th data-hide="phone" class="text-center">Fuente</th>
                                                <th data-hide="phone" class="text-center">Proyecto</th>
                                                <th data-hide="phone" class="text-center">Área</th>
                                                <th data-hide="phone" class="text-center">Fecha Solicitud</th>
                                                <th data-hide="phone" class="text-center">Estado</th>
                                                <th data-hide="phone" class="text-center">Generador</th>
                                                <th data-hide="phone" class="text-center">Revisión / Aprobación</th>
                                                <th data-hide="phone" class="text-center">Ver</th>
                                                <th data-hide="phone" class="text-center">PDF</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr v-for="(item, index) in listaSolicitudOrdenServicio" :key="index">
                                                <td  class="text-center"> {{ item.numeroSolicitud}}</td>
                                                <td>{{ item.fuenteContratoDto.descripcion }}</td>
                                                <td>{{ item.proyectoDto.descripcion }}</td>
                                                <td>{{ item.areaFuncionalDto.descripcion }}</td>
                                                <td class="text-center">{{ item.fechaSolicitud }}</td>
                                                <td class="text-center"> <label v-bind:class="['label', {'label-warning' : item.estadoDto.nombre == 'EN PROCESO'},  {'label-info' : item.estadoDto.nombre == 'Aprobado'},  {'label-danger' : item.estadoDto.nombre == 'Rechazado'}]">{{ item.estadoDto.nombre.toUpperCase() }}</label></td>
                                                <td>{{ item.usuarioSolicitudDto.nombreApellido }}</td>
                                                <td>{{ item.usuarioRevision }}</td>
                                                <td class="text-center">
                                                    <button class="btn btn-success" @click="mostrarDetalleSolicitud(item.IdSolicitudOrdenServicio)"><i class="fa fa-arrow-circle-right"></i></button>
                                                </td> 
                                                <td class="text-center">
                                                    <button class="btn btn-info" v-if="item.estadoDto.nombre === 'Aprobado' || item.estadoDto.nombre === 'Rechazado' " @click="descargarPdf(item.IdSolicitudOrdenServicio, item.numeroSolicitud)" ><i class="fa fa-file-pdf-o"></i></button>
                                                </td> 
                                            </tr>
                                        </tbody>
                                    </table>
                                    <el-pagination @current-change="handleCurrentChange" :current-page.sync="paginaActual" :page-size="nroFilasPorPagina" layout="total, prev, pager, next" :total="total">
                                    </el-pagination>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
         <el-dialog
            :visible.sync="dialogVisible"
            width="80%"
            top="3vh"
            custom-class="custom-dialog">
            <h2 slot="title">:: Detalle Solicitud de Contratación</h2>
            <keep-alive :max="1">
                <component :is="currentView" v-if="dialogVisible" 
                            v-bind:idSolicitudOrdenServicio ="idSolicitudOrdenServicio" 
                            :key="keyDialogComponent" 
                            @consultarSolicitudEvent="consultarSolicitudEvent"
                            @cerrarPopupEvent="cerrarPopupEvent"></component>
            </keep-alive>
            <span slot="footer" class="dialog-footer">
                <el-button @click="dialogVisible = false"><i class="fa fa-reply"></i> &nbsp; Atrás</el-button>
            </span>
        </el-dialog>
    </div>
</template>
<script>
import DetalleSolicitudOrdenServicio from '@/components/SolicitudOrdenServicio/DetalleSolicitudOrdenServicio'
import Loading from '@/components/shared/Loading'

import MaestroService from '@/services/maestro.service'
import SolicitudService from '@/services/solicitud.service'
import JwtService from '@/services/jwt.service'
import axios from 'axios'

import SwalAlert from '@/common/swal.alert'
import { createNamespacedHelpers } from 'vuex'
 const { mapState } = createNamespacedHelpers('solicitudServicio')

export default {
    components: {
        DetalleSolicitudOrdenServicio,
        Loading
    },
    data(){
        return {
            selectRowIndex: null,
            dialogVisible: false,
            currentView: "DetalleSolicitudOrdenServicio",
            idSolicitudOrdenServicio: 0,
            listaCompania:[],
            listaFuenteContrato:[],
            listaProyecto:[],
            listaFaseProyecto:[],
            listaAreaFuncional:[],
            listaEstado: [],
            idCompania: 0,
            idProyecto: 0,
            idFaseProyecto: 0,
            idFuenteContrato: 0,
            idAreaFuncional: 0,
            idEstado: 0,
            fechaInicio: "",
            fechaFin: "",
            listaSolicitudOrdenServicio:[],
            total: 0,
            paginaActual:0,
            nroFilasPorPagina: 0
        }
    },
    computed:{
    },
    mounted(){
        this.inicializar();
    },
    methods: {
        inicializar(){
            var self = this
            this.$store.commit(`solicitudServicio/SET_LOADING`, true);
            this.listaDocumentoAdjunto = []
            MaestroService.obtenerMaestroConsulta().then(response => {
                self.inicializarMaestro(response.data);
                self.consultarSolicitud()
            });
        },
        inicializarMaestro(data){
            this.listaFuenteContrato = data.maestro.listaFuenteContratoDto
            this.listaCompania = data.maestro.listaCompaniaDto
            this.listaProyecto = data.maestro.listaProyectoDto
            this.listaFaseProyecto = data.maestro.listaFaseProyectoDto
            this.listaAreaFuncional = data.maestro.listaAreaFuncionalDto
            this.listaEstado = data.maestro.listaEstadoDto
            this.fechaInicio = data.fechaInicio
            this.fechaFin = data.fechaFin
        },
        listarProyecto()
        {
            var self = this

            self.$store.commit(`solicitudServicio/SET_LOADING`, true);
            self.idProyecto = 0;
            
            var filtroCompania = {
                idCompania: self.idCompania
            };

            MaestroService.listarProyectoPorUsuario(filtroCompania).then(response => {
                self.listaProyecto = response.data.listaProyecto
            }).finally(() => this.$store.commit(`solicitudServicio/SET_LOADING`, false));
        },
        consultarSolicitudEvent(){
            this.consultarSolicitud(this.paginaActual);
        },
        handleCurrentChange(nroPagina) {
            this.consultarSolicitud(nroPagina);
        },
        consultarSolicitud(nroPagina = 1) {
            if(!this.validarConsulta()) return;
            
            var self = this;  
            this.$store.commit(`solicitudServicio/SET_LOADING`, true);
            var filtroSolicitud = {
                idCompania: self.idCompania,
                idProyecto: self.idProyecto,
                idFaseProyecto: self.idFaseProyecto,
                idFuenteContrato: self.idFuenteContrato,
                idAreaFuncional: self.idAreaFuncional,
                idEstado: self.idEstado,
                fechaInicio: self.fechaInicio,
                fechaFin: self.fechaFin,
                nroPagina: nroPagina
            };

            SolicitudService.consultarSolicitud(filtroSolicitud)
                .then(response => {
                    self.listaSolicitudOrdenServicio = response.data.listaSolicitudOrdenServicio;
                    self.total = response.data.total;
                    self.nroFilasPorPagina = response.data.nroFilasPorPagina;
                    self.paginaActual = nroPagina;
                })
                .finally(() => (self.$store.commit(`solicitudServicio/SET_LOADING`, false)));
        },
        exportarConsulta(){
            if(!this.validarConsulta()) return;

            window.open(`/SolicitudOrdenServicio/ConsultarExportPorSolicitud?idCompania=${this.idCompania}&idProyecto=${this.idProyecto}&idFaseProyecto=${this.idFaseProyecto}
                                                                &idFuenteContrato=${this.idFuenteContrato}&idAreaFuncional=${this.idAreaFuncional}&idEstado=${this.idEstado}
                                                                &fechaInicio=${this.fechaInicio}&fechaFin=${this.fechaFin}&token=${JwtService.obtenerToken()}`);
        },
        exportarConsultaPorProveedor(){
            if(!this.validarConsulta()) return;

            window.open(`/SolicitudOrdenServicio/ConsultarExportPorProveedor?idCompania=${this.idCompania}&idProyecto=${this.idProyecto}&idFaseProyecto=${this.idFaseProyecto}
                                                                &idFuenteContrato=${this.idFuenteContrato}&idAreaFuncional=${this.idAreaFuncional}&idEstado=${this.idEstado}
                                                                &fechaInicio=${this.fechaInicio}&fechaFin=${this.fechaFin}&token=${JwtService.obtenerToken()}`);
        },
        validarConsulta(){
            if(isBlank(this.fechaInicio) && isBlank(this.fechaFin)){
                SwalAlert.warning("Debe ingresar la fecha de inicio y fin."); 
                return false;
            }

            if(isBlank(this.fechaInicio)){
                SwalAlert.warning("Debe ingresar la fecha de inicio."); 
                return false;
            }

            if(isBlank(this.fechaFin)){
                SwalAlert.warning("Debe ingresar la fecha fin."); 
                return false;
            }

            return true;
        },
        validarFechaInicio(){
            if(isBlank(this.fechaInicio)) return;

            if(CompararFechas(this.fechaFin, this.fechaInicio) < 0){
                this.fechaInicio = ""
                SwalAlert.warning("La fecha inicio no debe ser mayor a la fecha fin.");     
            }
        },
        validarFechaFin(){
            if(isBlank(this.fechaFin)) return;

            if(CompararFechas(this.fechaFin, this.fechaInicio) < 0){
                this.fechaFin = ""
                SwalAlert.warning("La fecha fin no debe ser menor a la fecha inicio.");
            }
        },
        mostrarDetalleSolicitud(item){
            this.keyDialogComponent = new Date().getTime();
            this.idSolicitudOrdenServicio = item;
            this.dialogVisible = true;
        },
        cerrarPopupEvent()
        {
            this.dialogVisible = false;
        },
        descargarPdf(IdSolicitudOrdenServicio, numeroSolicitud){
            axios({
                method: 'get',
                url: `/SolicitudOrdenServicio/DescargarPdf?idSolicitudOrdenServicio=${IdSolicitudOrdenServicio}`,
                responseType: 'blob'
            })
            .then(response => {
                
                if(response.data.size == 0)
                {
                    SwalAlert.error(" No se pudo generar el PDF."); 
                    return;
                }

                this.forceFileDownload(response, numeroSolicitud)
                
            })
            .catch((e) => console.log(e))
        },
        forceFileDownload(response, numeroSolicitud){
            const url = window.URL.createObjectURL(new Blob([response.data]))
            const link = document.createElement('a')
            link.href = url
            link.target="_blank"
            link.download = `${numeroSolicitud}.pdf`;
            link.click()
        }
    }
}
</script>
