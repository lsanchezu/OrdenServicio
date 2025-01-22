<template>
    <div>
        <div class="row wrapper border-bottom white-bg page-heading">
            <div class="col-lg-10">
                <h2>Consultar Solicitud de Cambio</h2>
                <ol class="breadcrumb">
                    <li>
                        <a href="">Home</a>
                    </li>
                    <li>
                        <a>Reporte</a>
                    </li>
                    <li class="active">
                        <strong>Mis Pendientes</strong>
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
                            <h5>:: MIS PENDIENTES</h5>
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
                                                <th data-hide="phone" class="text-center">Ver</th>
                                                <!-- <th data-hide="phone" class="text-center">PDF</th> -->
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr v-for="(item, index) in listaSolicitudOrdenServicio" :key="index">
                                                <td  class="text-center"> {{ item.numeroSolicitud}}</td>
                                                <td>{{ item.fuenteContratoDto.descripcion }}</td>
                                                <td>{{ item.proyectoDto.descripcion }}</td>
                                                <td>{{ item.areaFuncionalDto.descripcion }}</td>
                                                <td class="text-center">{{ item.fechaSolicitud }}</td>
                                                <td class="text-center"> <label v-bind:class="['label', {'label-warning' : item.estadoDto.nombre == 'EN PROCESO'},  {'label-info' : item.estadoDto.nombre == 'APROBADO'},  {'label-danger' : item.estadoDto.nombre == 'RECHAZADO'}]">{{ item.estadoDto.nombre }}</label></td>
                                                <td>{{ item.usuarioSolicitudDto.nombreApellido }}</td>
                                                <td class="text-center">
                                                    <button class="btn btn-success" @click="mostrarDetalleSolicitud(item.idSolicitudOrdenServicio)"><i class="fa fa-arrow-circle-right"></i></button>
                                                </td>
                                                <!-- <td class="text-center">
                                                    <button class="btn btn-info"><i class="fa fa-file-pdf-o"></i></button>
                                                </td>  -->
                                            </tr>
                                        </tbody>
                                    </table>
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
            <h2 slot="title">:: Detalle Orden de Cambio</h2>
            <keep-alive :max="1">
                <component :is="currentView" v-if="dialogVisible" 
                            v-bind:idSolicitudOrdenServicio ="idSolicitudOrdenServicio" 
                            :key="keyDialogComponent" 
                            @consultarSolicitudEvent="consultarPendientes"
                            @cerrarPopupEvent="cerrarPopupEvent"></component>
            </keep-alive>
            <span slot="footer" class="dialog-footer">
                <el-button @click="dialogVisible = false"><i class="fa fa-reply"></i> &nbsp; Atrás</el-button>
            </span>
        </el-dialog>
    </div>
</template>
<script>

import DetalleSolicitudOrdenServicio from '@/components/solicitudOrdenServicio/DetalleSolicitudOrdenServicio'
import Loading from '@/components/shared/Loading'
import SolicitudService from '@/services/solicitud.service'

export default {
    components:{
        Loading,
        DetalleSolicitudOrdenServicio
    },
    data(){
        return {
            listaSolicitudOrdenServicio: [
            {
                numeroSolicitud: '12345',
                fuenteContratoDto: { descripcion: 'Fuente A' },
                proyectoDto: { descripcion: 'Proyecto A' },
                areaFuncionalDto: { descripcion: 'Área A' },
                fechaSolicitud: '2023-10-01',
                estadoDto: { nombre: 'EN PROCESO' },
                usuarioSolicitudDto: { nombreApellido: 'Juan Pérez' },
                idSolicitudOrdenServicio: 59,
            }
        ],
            dialogVisible: false,
            currentView: "DetalleSolicitudOrdenServicio",
        }
    },
    mounted() {
        this.consultarPendientes();
    },
    methods: {
        consultarPendientes() {
            var self = this;  
            this.$store.commit(`solicitudServicio/SET_LOADING`, true);
       
            SolicitudService.consultarPendientesPorUsuario()
                .then(response => {
                    // self.listaSolicitudOrdenServicio = response.data.listaSolicitudOrdenServicio
                })
                .finally(() => (self.$store.commit(`solicitudServicio/SET_LOADING`, false)));
        },
        mostrarDetalleSolicitud(item){
            console.log(item)
            this.keyDialogComponent = new Date().getTime();
            this.idSolicitudOrdenServicio = item;
            this.dialogVisible = true;
        },
        cerrarPopupEvent()
        {
            this.dialogVisible = false;
        }
    },
}
</script>
