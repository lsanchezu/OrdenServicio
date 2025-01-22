<template>
        <div class="section-aprobacion">
               <div class="row">
                    <div class="col-sm-12 m-b-xs" v-for="(item, index) in listaSolicitudAutorizacion" :key="index">
                            <div class="title-aprobacion">
                                <span>AUTORIZACIÓN</span>
                            </div>
                            <div class="content-aprobacion">
                                <div class="row">
                                    <div class="col-sm-12">
                                        <div class="row-aprobacion bg-aprobacion">
                                             <label>{{item.gobernanzaDto.descripcion}}:</label>
                                             <span>{{item.usuarioDto.nombreApellido}}</span>
                                            <label class="right">{{item.estado}} - {{item.fechaRegistro}}</label>
                                        </div>
                                               
                                    </div>
                                    <div class="col-sm-12" v-if="mostrarComentario(item.comentario)">
                                        <div class="row-aprobacion">
                                             <div class="form-group">
                                                <label class="control-label">Comentario</label>
                                                 <textarea class="form-control" 
                                                    onkeypress="return val_DescripcionQ(event)"
                                                    rows="4"
                                                    maxlength="1024" 
                                                    v-model="item.comentario"
                                                    spellcheck="true" :readonly="true"></textarea>
                                            </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-12" v-if="flagRegistrar">
                        <div class="title-aprobacion">
                            <span>AUTORIZACIÓN</span>
                        </div>
                        <div class="content-aprobacion">
                            <div class="row">
                                <div class="col-sm-12">
                                    <div class="row-aprobacion bg-aprobacion">
                                        <div class="row">
                                            <div class="col-sm-6">
                                                <label>{{solicitudAutorizacion.gobernanzaDto.descripcion}}:</label>
                                                <span>{{solicitudAutorizacion.usuarioDto.nombreApellido}}</span>
                                            </div>
                                            <div class="col-sm-6 text-right">
                                                <label>Fecha - {{solicitudAutorizacion.fechaRegistro}}</label>
                                            </div>
                                        </div>  
                                    </div>
                                </div>
                                <div class="col-sm-12">
                                    <div class="row-aprobacion">
                                        <div class="form-group">
                                                <label class="control-label">Comentario</label>
                                                <textarea class="form-control" 
                                                            onkeypress="return val_DescripcionQ(event)"
                                                            rows="4"
                                                            maxlength="1204" 
                                                            v-model="comentario"
                                                            placeholder="Ingrese un comentario (cant. max. 1024)" 
                                                            spellcheck="true"></textarea>
                                        </div>
                                    </div>
                                           
                                </div>
                                <div class="col-sm-12">
                                            <div class="row-aprobacion">
                                                    <div class="text-right">
                                                        <button class="btn btn-sm btn-primary btn-buscar" @click="confirmacionApruebaSolicitud()"><i class="fa fa-save"></i> <strong>Aprobar</strong></button>
                                                        <button class="btn btn-sm btn-danger btn-buscar" @click="confirmacionNoApruebaSolicitud()"><i class="fa fa-save"></i> <strong>Rechazar</strong></button>
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
import SwalAlert from '@/common/swal.alert'
import SolicitudService from '@/services/solicitud.service'
import "toastr"

export default {
    name: "solicitud-autorizacion",
    props: {
        solicitudAutorizacion: {type: Object,required: false},
        listaSolicitudAutorizacion: {type: Array,required: false},
        idSolicitud: {type: Number,required: false},
        flagRegistrar: {type: Boolean,required: false}
    },
    computed: {
        
    },
    data(){
        return {
            comentario: ""
        }
    },
    methods: {
        mostrarComentario(comentario){
            return !isBlank(comentario)
        },
        confirmacionApruebaSolicitud(){
            this.solicitudAutorizacion.flagAprobado = true
            SwalAlert.confirmAjax("¿Está seguro(a) de APROBAR la solicitud de contratación?", this.registrarAprobacionSolicitud);
        },
        confirmacionNoApruebaSolicitud(){
            this.solicitudAutorizacion.flagAprobado = false
            SwalAlert.confirmAjax("¿Está seguro(a) de RECHAZAR la solicitud de contratación?", this.registrarAprobacionSolicitud);
        },
        registrarAprobacionSolicitud(){
            this.solicitudAutorizacion.comentario = this.comentario;
            this.$emit('registrarAprobacionSolicitud', this.solicitudAutorizacion);
        }
    },
}
</script>
<style>
  
    
</style>
