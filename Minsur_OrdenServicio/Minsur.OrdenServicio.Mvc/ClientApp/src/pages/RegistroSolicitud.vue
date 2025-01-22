<template>
    <div>
        <div class="row wrapper border-bottom white-bg page-heading">
            <div class="col-lg-10">
                <h2>Registrar Solicitud de cambio</h2>
                <ol class="breadcrumb">
                    <li>
                        <a href="">Home</a>
                    </li>
                    <li>
                        <a>Solicitud de solcitud</a>
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
            <solicitud-orden-servicio-registro />
        </div>
 
    </div>
</template>
<script>
import SolicitudOrdenServicioRegistro from '@/components/solicitudOrdenServicio/SolicitudOrdenServicioRegistro';
export default {
    components:{
        SolicitudOrdenServicioRegistro
    },
    data(){
        return {
            
        }
    
    }
}
</script>
