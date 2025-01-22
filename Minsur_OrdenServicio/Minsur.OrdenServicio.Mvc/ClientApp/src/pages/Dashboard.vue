<template>
    <div>
        <div class="row wrapper border-bottom white-bg page-heading">
            <div class="col-lg-10">
                <h2>Dashboard</h2>
                <ol class="breadcrumb">
                    <li>
                        <a href="">Home</a>
                    </li>
                    <li>
                        <a>Orden de Cambio</a>
                    </li>
                    <li class="active">
                        <strong>Dashboard</strong>
                    </li>
                </ol>
            </div>
            <div class="col-lg-2">
                
            </div>
        </div>
        <div class="wrapper wrapper-content animated"> 
           
            <div class="ibox-content m-b-sm border-bottom">
                <div class="row">
                        <div class="col-sm-4">
                            <div class="form-group">
                                <label class="control-label" for="status">Proyecto</label>
                                <select name="status"  class="form-control" v-model="idProyecto">
                                    <option value="0">:: TODOS ::</option>
                                    <option v-for="item in listaProyecto" v-bind:value="item.idProyecto" :key="item.idProyecto">{{ item.descripcion }}</option>
                                </select>
                            </div>
                        </div>
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
                                <label class="control-label" style="display:block;" for="status">&nbsp;</label>
                                 <button class="btn btn-sm btn-primary btn-buscar" @click="consultar()"><i class="fa fa-search"></i> <strong>Consultar</strong></button>
                            </div>
                        </div>
                    </div>
            </div>
            <div class="ibox">
                <div class="ibox-content m-b-sm border-bottom">
                    <div class="row">
                        <div class="col-lg-3">
                            <div class="ibox m-b-none">
                                <div class="ibox-title card-title card-title-green">
                                    <h5>Pendientes de aprobación</h5>
                                </div>
                                <div class="ibox-content card-content card-content-green">
                                    <h1 class="no-margins font-bold">{{totalPendientes}}</h1>
                                    <div class="stat-percent font-bold text-success"> </div>
                                    <small>Cantidad de Ordenes de Cambio</small>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-3">
                            <div class="ibox m-b-none">
                                <div class="ibox-title card-title card-title-red">
                                    <h5>Regularizaciones</h5>
                                </div>
                                <div class="ibox-content card-content card-content-red">
                                    <h1 class="no-margins font-bold">{{totalRegularizacion}}</h1>
                                    <div class="stat-percent font-bold text-info"></div>
                                    <small>Cantidad de regularizaciones</small>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-6">
                            <div class="text-center">
                                <label>Normales vs. Regularizaciones</label>
                            </div>
                             
                            <div class="flot-chart">
                                <div ref="flotSolicitud" class="flot-chart-content" id="flot-dashboard-chart"></div>
                            </div>
                            <div class="text-center">
                                <div id="legendContainer"></div>
                            </div>
                        </div>
                        
                    </div>
                </div>
            </div>
            <div class="ibox float-e-margins">
                <div class="ibox-title ibox-title-white">
                    Fuente de Contratación
                </div>
                <div class="ibox-content m-b-sm border-bottom">
                    <div class="row">
                        <div class="col-lg-3">
                        <div class="ibox m-b-none">
                            <div class="ibox-title card-title car-title-licitacion">
                                <h5>Concurso/Licitación</h5>
                            </div>
                            <div class="ibox-content card-content card-content-licitacion">
                                <h1 class="no-margins">{{totalFuenteLicitacion}}</h1>
                                <div class="stat-percent font-bold text-navy"></div>
                                <small>Cantidad de solicitudes</small>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-3">
                        <div class="ibox m-b-none">
                            <div class="ibox-title card-title car-title-preferente">
                                <h5>Proveedor/Contratista Preferente</h5>
                            </div>
                            <div class="ibox-content card-content card-content-preferente">
                                <h1 class="no-margins">{{totalFuentePreferente}}</h1>
                                <div class="stat-percent font-bold text-danger"></div>
                                <small>Cantidad de solicitudes</small>
                            </div>
                        </div>
                        
                    </div>
                     <div class="col-lg-3">
                        <div class="ibox m-b-none">
                            <div class="ibox-title card-title car-title-sole-source">
                                <h5>Sole Source</h5>
                            </div>
                            <div class="ibox-content card-content card-content-sole-source">
                                <h1 class="no-margins">{{totalFuenteSoleSource}}</h1>
                                <div class="stat-percent font-bold text-danger"></div>
                                <small>Cantidad de solicitudes</small>
                            </div>
                        </div>
                        
                    </div>
                    </div>
                </div>
            </div>
        </div>
 
    </div>
</template>
<script>
import Loading from '@/components/shared/Loading'
import MaestroService from '@/services/maestro.service'
import SolicitudService from '@/services/solicitud.service'
import SwalAlert from '@/common/swal.alert'

export default {
    components:{
        Loading
    },
    data(){
        return {
            idProyecto: 0,
            idFaseProyecto: 0,
            listaProyecto: [],
            listaFaseProyecto: [],
            totalPendientes: 0,
            totalRegularizacion: 0,
            totalFuenteLicitacion:0,
            totalFuentePreferente:0,
            totalFuenteSoleSource:0
        }
    },
    mounted(){
        this.inicializar();
    },
    methods:{
        inicializar(){
            var self = this
            this.$store.commit(`solicitudServicio/SET_LOADING`, true);
            this.listaDocumentoAdjunto = []
            MaestroService.obtenerMaestroConsulta().then(response => {
                self.inicializarMaestro(response.data);
                self.consultar();
            });
        },
        inicializarMaestro(data){
            this.listaProyecto = data.maestro.listaProyectoDto,
            this.listaFaseProyecto = data.maestro.listaFaseProyectoDto
        },
        consultar() {
            var self = this;  
            this.$store.commit(`solicitudServicio/SET_LOADING`, true);
            var filtroSolicitud = {
                idProyecto: self.idProyecto,
                idFaseProyecto: self.idFaseProyecto
            };

            SolicitudService.obtenerDashboard(filtroSolicitud)
                .then(response => {
                    self.totalPendientes = response.data.dashboard.totalPedienteAprobacion
                    self.totalRegularizacion = response.data.dashboard.totalRegularizacion
                    self.totalFuenteLicitacion = response.data.dashboard.totalFuenteLicitacionConcurso
                    self.totalFuentePreferente = response.data.dashboard.totalFuentePreferente
                    self.totalFuenteSoleSource = response.data.dashboard.totalFuenteSoleSource

                    self.mostrarGrafico(response.data.listaRegularizacion)
                    
                })
                .finally(() => (self.$store.commit(`solicitudServicio/SET_LOADING`, false)));
        },
        mostrarGrafico(listaRegularizacion){
            var dataSolicitudCategoriaRegularizacion = []
            var dataSolicitudCategoriaNormal = []

            listaRegularizacion.forEach(item => {
                dataSolicitudCategoriaRegularizacion.push([gd(item.anio, item.mes, 1), item.valorRegularizacion]);
            });

            listaRegularizacion.forEach(item => {
                dataSolicitudCategoriaNormal.push([gd(item.anio, item.mes, 1), item.valorNormal]);
            });


            var dataset = [
                {
                    label: "Normal",
                    data: dataSolicitudCategoriaNormal,
                    color: "#337ab7",
                    lines: {
                        lineWidth: 1,
                        show: true,
                        fill: true,
                        fillColor: {
                            colors: [{
                                opacity: 0.2
                            }, {
                                opacity: 0.2
                            }]
                        }
                    },
                    splines: {
                        show: false,
                        tension: 0.6,
                        lineWidth: 1,
                        fill: 0.1
                    },
                },
                {
                    label: "Regularización",
                    data: dataSolicitudCategoriaRegularizacion,
                    color: "#d84352",
                    lines: {
                        lineWidth: 1,
                        show: true,
                        fill: true,
                        fillColor: {
                            colors: [{
                                opacity: 0.2
                            }, {
                                opacity: 0.2
                            }]
                        }
                    },
                    splines: {
                        show: false,
                        tension: 0.6,
                        lineWidth: 1,
                        fill: 0.1
                    },
                }
                 
            ];
            
            var options = {
                xaxis: {
                    mode: "time",
                    tickSize: [1, "month"],
                    tickLength: 0,
                    axisLabel: "Date",
                    axisLabelUseCanvas: true,
                    axisLabelFontSizePixels: 12,
                    axisLabelFontFamily: 'Arial',
                    axisLabelPadding: 10,
                    color: "#d5d5d5",
                    monthNames:  ["Ene", "Feb", "Mar", "Abr", "May", "Jun", "Jul", "Ago", "Sep", "Oct", "Nov", "Dic"]
                },
                yaxes: [{
                    position: "left",
                    max: 1,
                    min:0,
                    tickFormatter: function (val, axis) {   
                        return `${(val * 100).toFixed(0)} %`         
                    },
                    color: "#d5d5d5",
                    axisLabelUseCanvas: true,
                    axisLabelFontSizePixels: 12,
                    axisLabelFontFamily: 'Arial',
                    axisLabelPadding: 3
                }
                ],
                legend: {
                    // noColumns: 0,
                    // labelBoxBorderColor: "#000000",
                    // position: "nw",
                    container:$("#legendContainer"),            
                    noColumns: 0
                },
                grid: {
                    hoverable: true,
                    borderWidth: 0,
                    mouseActiveRadius: 5,
                },
                tooltip: true,
                tooltipOpts: {
                    content: "%y"
                }
            };

            splot(this.$refs.flotSolicitud, dataset, options);
        },
        gd(year, month, day) {
            return new Date(year, month - 1, day).getTime();
        }
        
    }
}
</script>
