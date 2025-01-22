<template>
    <div>
        <div class="col-sm-12">
            <div class="form-group">
                <label class="control-label">{{documento.tipoDocumento.descripcion}}</label><label class="error" v-if="documento.tipoDocumento.idTipoDocumento == tipoDocumentoRequerido" >(*)</label>&nbsp; <label class="label label-info">Max {{pesoMaximo}}MB</label>
                <input type="file" id="file" ref="myFiles" style="display:block;" @change="agregarArchivo($event)">
            </div>
        </div>
        <div class="col-sm-12" v-if="documento.listaArchivo.length > 0">
            <div class="col-sm-6">
                <div class="table-responsive m-t">
                    <table class="table table-striped">
                        <thead>
                            <tr>
                                <th>ITEM</th>
                                <th>NOMBRE</th>
                                <th>TAMAÑO (MB)</th>
                                <th width="5%">Eliminar</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr v-for="(item, index) in documento.listaArchivo" :key="index">
                                <td>{{index + 1}}</td>
                                <td>{{item.nombre}}</td>
                                <td>{{ (item.data.size / convert_BYTE_MB).toFixed(2)}}</td>
                                <td>
                                    <button class="btn btn-danger" type="button" title="Eliminar Proveedor/Contratista" @click="eliminarArchivo(item.id)"> <i class="fa fa-window-close"></i>
                                   </button>
                                </td>
                            </tr>
                        </tbody>                                                
                    </table>
                </div>
            </div>
        </div>                        
    </div>
   
</template>
<script>
import SwalAlert from '@/common/swal.alert'
import  {PESO_MAXIMO_ARCHIVO, MB_TO_BYTES,TIPO_DOCUMENTO_ALCANCE_TRABAJO} from '@/constants/solicitud.constants'

export default {
    name: 'documento-adjunto',
    data(){
        return {
            pesoMaximo: PESO_MAXIMO_ARCHIVO,
            tipoDocumentoRequerido: TIPO_DOCUMENTO_ALCANCE_TRABAJO,
            convert_BYTE_MB: MB_TO_BYTES
        }
    },
    props: {
        documento: { type: Object, required: true }
    },
    methods: {
        agregarArchivo(event){
            if(this.$refs.myFiles.files.length === 0) return

            if((PESO_MAXIMO_ARCHIVO * MB_TO_BYTES) < this.$refs.myFiles.files[0].size){
                SwalAlert.warning(`El tamaño máximo del archivo debe ser ${PESO_MAXIMO_ARCHIVO}MB.`)
                return;
            }

            let id = this.documento.listaArchivo.length + 1;
            let archivo  = {
                            id:id,
                            nombre: this.$refs.myFiles.files[0].name,
                            data: this.$refs.myFiles.files[0]
                        }
            this.$refs.myFiles.value = null;            
            this.$emit('agregarArchivo', this.documento.tipoDocumento.idTipoDocumento, archivo)
        },
        eliminarArchivo(id){
            this.$emit('eliminarArchivo', this.documento.tipoDocumento.idTipoDocumento, id)
        }
    }
}
</script>
