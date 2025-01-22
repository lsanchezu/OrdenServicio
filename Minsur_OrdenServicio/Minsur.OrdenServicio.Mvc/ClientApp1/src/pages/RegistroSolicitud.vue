<template>
    <div>
        <div class="row wrapper border-bottom white-bg page-heading">
            <div class="col-lg-10">
                <h2>Registrar Solicitud de Contratación de Servicio</h2>
                <ol class="breadcrumb">
                    <li>
                        <a href="">Home</a>
                    </li>
                    <li>
                        <a>Solicitud Contratación</a>
                    </li>
                    <li class="active">
                        <strong>Registro</strong>
                    </li>
                </ol>
            </div>
            <div class="col-lg-2">

            </div>
        </div>
        <div class="wrapper wrapper-content animated"> 
            <solicitud-ordenservicio-servicio />
        </div>
 
    </div>
</template>
<script>
import SolicitudOrdenServicio from '@/components/SolicitudOrdenServicio/SolicitudOrdenServicio'

export default {
    components:{
        SolicitudOrdenServicio
    },
    data(){
        return {
            
        }
    
    }
}
</script>
