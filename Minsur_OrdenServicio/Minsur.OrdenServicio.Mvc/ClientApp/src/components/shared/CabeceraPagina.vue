<template>
    <div class="row wrapper border-bottom white-bg page-heading">
    <div class="col-lg-10">
        <h2>{{titulo}}</h2>
        <ol class="breadcrumb">
            <li>
                <a href="/">Home</a>
            </li>
            <li>
                <a>{{grupo}}</a>
            </li>
            <li class="active">
                <strong>{{titulo}}</strong>
            </li>
        </ol>
    </div>
    <div class="col-lg-2">

    </div>
</div>
</template>
<script>
export default {
    name: 'cabecera-pagina',
    data(){
        return{
            title:''
        }
    },
    computed:{
        titulo: function(){ 
            return this.$route.meta.title;
        },
        grupo: function(){
            return this.$route.fullPath.split('/')[1];
        }
    }
}
</script>
