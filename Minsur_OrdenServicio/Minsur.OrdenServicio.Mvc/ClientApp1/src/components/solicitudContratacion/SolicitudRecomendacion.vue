<template>
        <div class="section-aprobacion">
            <div class="row">
                <div class="col-sm-12">
                            <div class="title-aprobacion">
                                <span>RECOMENDACIÓN ENCARGADO DE PROCURA Y CONTRATOS</span>
                            </div>
                            <div class="content-aprobacion">
                                <div class="row">
                                    <div class="col-sm-12">
                                        <div class="row-aprobacion bg-aprobacion">
                                                <div class="row">
                                                    <div class="col-sm-6">
                                                        <label>Nombre: </label>
                                                        <span>{{solicitudRecomendacion.usuarioDto.nombreApellido}}</span>     
                                                    </div>
                                                    <div class="col-sm-6 text-right">
                                                        <label v-if="!flagRegistrar">{{solicitudRecomendacion.estado}} - {{solicitudRecomendacion.fechaRegistro}}</label>
                                                        <label v-else>Fecha: {{solicitudRecomendacion.fechaRegistro}}</label>
                                                    </div>
                                                </div>
                                        </div>
                                                
                                    </div>
                                    <div class="col-sm-12" v-if="mostrarComentario">
                                        <div class="row-aprobacion">
                                            <div class="form-group">
                                                <label class="control-label">Comentario</label>
                                                <textarea class="form-control" 
                                                        onkeypress="return val_DescripcionQ(event)"
                                                        rows="4"
                                                        maxlength="1024" 
                                                        v-model="solicitudRecomendacion.comentario"
                                                        placeholder="Ingrese un comentario (cant. max. 1024)" 
                                                        :readonly="!flagRegistrar"
                                                        spellcheck="true" ></textarea>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-sm-12" v-if="flagRegistrar">
                                        <div class="row-aprobacion">
                                            <div class="text-right">
                                                <button class="btn btn-sm btn-primary btn-buscar" @click="confirmacionRecomendarSolicitud()"><i class="fa fa-save"></i> <strong>Recomienda</strong></button>
                                                <button class="btn btn-sm btn-info btn-buscar" @click="confirmacionNoRecomendarSolicitud()"><i class="fa fa-save"></i> <strong>No Recomienda</strong></button>
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
    name: "solicitud-recomendacion",
    props: {
        solicitudRecomendacion: {type: Object,required: false},
        flagRegistrar: {type: Boolean,required: false}
    },
    computed: {
        mostrarComentario(){
            if(!isBlank(this.solicitudRecomendacion.comentario)){
                return true;
            }

            return this.flagRegistrar
        }
    },
    methods: {
        confirmacionRecomendarSolicitud(){
            this.solicitudRecomendacion.flagRecomendado = true;

            SwalAlert.confirmAjax("¿Está seguro(a) de recomendar la solicitud de contratación?", this.registrarRecomendacionSolicitud);
        },
        confirmacionNoRecomendarSolicitud(){
            this.solicitudRecomendacion.flagRecomendado = false;

            SwalAlert.confirmAjax("¿Está seguro(a) de no recomendar la solicitud de contratación?", this.registrarRecomendacionSolicitud);
        },
        registrarRecomendacionSolicitud(){
            this.$emit('registrarRecomendacion', this.solicitudRecomendacion);
        }
    },
}
</script>
