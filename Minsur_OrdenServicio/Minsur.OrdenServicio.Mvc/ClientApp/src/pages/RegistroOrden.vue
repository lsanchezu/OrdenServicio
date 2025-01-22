<template>
    <div>
        <div class="row wrapper border-bottom white-bg page-heading">
            <div class="col-lg-10">
                <h2>Registrar Orden de Cambio</h2>
                <ol class="breadcrumb">
                    <li>
                        <a href="">Home</a>
                    </li>
                    <li>
                        <a>Orden de Servicio</a>
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
            <orden-servicio />
        </div>
 
    </div>
</template>
<script>
import OrdenServicio from '@/components/solicitudOrdenServicio/SolicitudOrdenServicio'

export default {
    components:{
        OrdenServicio
    },
    data(){
        return {
            
        }
    
    }
}
</script>
