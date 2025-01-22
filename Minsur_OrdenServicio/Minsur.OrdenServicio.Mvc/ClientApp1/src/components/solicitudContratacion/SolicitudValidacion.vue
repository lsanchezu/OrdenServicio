<template>
    <div class="section-aprobacion">
        <div class="row">
            <div class="col-sm-12">
                            <div class="title-aprobacion">
                                <span>VALIDACIÓN</span>
                            </div>
                             <div class="content-aprobacion">
                                <div class="row">
                                    <div class="col-sm-12" v-if="!flagRegistrar">
                                        <div class="row-aprobacion bg-aprobacion">
                                            <div class="row">
                                                <div class="col-sm-3">
                                                    <label>Nombre: </label>
                                                    <span>{{solicitudValidacion.usuarioDto.nombreApellido}}</span>     
                                                </div>
                                                <div class="col-sm-3">
                                                    <label>PEP / Grafo: </label>
                                                    <span>{{solicitudValidacion.grafo}}</span>
                                                </div>
                                                <div class="col-sm-3">
                                                    <label>Presupuestado: </label>
                                                    <span>{{solicitudValidacion.flagExistePresupuesto ? "SI" : "NO"}}</span>
                                                </div>
                                                <div class="col-sm-3 text-right">
                                                    <label>{{solicitudValidacion.estado}} - {{solicitudValidacion.fechaRegistro}}</label>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-sm-12" v-else >
                                        <div class="row-aprobacion">
                                            <div class="row">
                                                <div class="col-sm-3">
                                                    <div class="form-group">
                                                        <label class="control-label" for="customer">Nombre</label>
                                                        <input type="text" id="txtoNombreApellidoValidacion" name="status" v-model="solicitudValidacion.usuarioDto.nombreApellido" class="form-control" readonly="readonly">
                                                    </div>
                                                </div>
                                                <div class="col-sm-4">
                                                    <div class="form-group">
                                                        <label class="control-label" for="customer">PEP / Grafo</label>
                                                        <input type="text" id="txtGrafoValidacion" 
                                                                name="txtGrafoValidacion" v-model="solicitudValidacion.grafo" 
                                                                class="form-control"  
                                                                :readonly="!flagRegistrar"
                                                                v-validate="flagRegistrar ? 'required' : '' " 
                                                                :class="{'form-control': true, 'error': errors.has('txtGrafoValidacion') }"
                                                                />
                                                        <label class="error" v-show="errors.has('txtGrafoValidacion')">{{ errors.first('txtGrafoValidacion') }}</label>        
                                                    </div>
                                                </div>
                                                <div class="col-sm-3">
                                                    <div class="form-group">
                                                        <label class="control-label">Fecha</label>
                                                        <input type="text" id="txtfechaTermino" name="status" v-model="solicitudValidacion.fechaRegistro" class="form-control" readonly="readonly">
                                                    </div>
                                                </div>
                                                <div class="col-sm-2">
                                                    <div class="form-group" >
                                                        <label class="control-label" style="display:block;">Presupuestado</label>
                                                        <el-radio-group v-if="flagRegistrar"
                                                                        v-model="solicitudValidacion.flagExistePresupuesto">
                                                            <el-radio-button :label="true">SI</el-radio-button>
                                                            <el-radio-button :label="false">NO</el-radio-button>
                                                        </el-radio-group>
                                                        <div v-else> 
                                                            <el-tag :type="solicitudValidacion.flagExistePresupuesto ? '' : 'danger'" 
                                                                    effect="dark">
                                                            {{ solicitudValidacion.flagExistePresupuesto ? "SI" : "NO" }}
                                                        </el-tag>
                                                        </div>
                                                    </div>
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
                                                    v-model="solicitudValidacion.comentario"
                                                    placeholder="Ingrese un comentario (cant. max. 1024)" 
                                                    :readonly="!flagRegistrar"
                                                    spellcheck="true" ></textarea>
                                            </div>
                                        </div>
                                               
                                    </div>

                                     <div class="col-sm-12" v-if="flagRegistrar">
                                         <div class="row-aprobacion">
                                             <div class="text-right">
                                                <button class="btn btn-sm btn-primary btn-buscar" @click="confirmacionValidarSolicitud()" :disabled="inactivarBotonValidar"><i class="fa fa-save"></i> <strong>Validar</strong></button>
                                                <button class="btn btn-sm btn-info btn-buscar" @click="confirmacionNoValidarSolicitud()"><i class="fa fa-save"></i> <strong>No Validar</strong></button>
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
    name: "solicitud-validacion",
    props: {
        solicitudValidacion: {type: Object,required: false},
        idSolicitud: {type: Number,required: false},
        flagRegistrar: {type: Boolean,required: false}
    },
    computed: {
        mostrarComentario(){
            if(!isBlank(this.solicitudValidacion.comentario)){
                return true;
            }

            return this.flagRegistrar;
        },
        inactivarBotonValidar(){
            return !this.solicitudValidacion.flagExistePresupuesto;
        }
    },
    methods: {
        confirmacionValidarSolicitud(){
            var self = this
            this.$validator.validateAll().then((result) => {
                if (!result) {
                    SwalAlert.warning("Debe ingresar los datos obligatorios.")
                    return;
                }

                self.solicitudValidacion.flagValidado = true;
                SwalAlert.confirmAjax("¿Está seguro(a) de validar la solicitud de contratación?", self.registrarValidacionSolicitud);
            });

            
        },
        confirmacionNoValidarSolicitud(){
            var self = this
            this.$validator.validateAll().then((result) => {
                if (!result) {
                    SwalAlert.warning("Debe ingresar los datos obligatorios.")
                    return;
                }

                self.solicitudValidacion.flagValidado = false;
                SwalAlert.confirmAjax("¿Está seguro(a) de no validar la solicitud de contratación?", self.registrarValidacionSolicitud);
            });
        },
        registrarValidacionSolicitud(){
            this.$emit('registrarValidacion', this.solicitudValidacion);
        }
    },
}
</script>