<template>
    <div class="row border-bottom">
        <nav class="navbar navbar-static-top" role="navigation" style="margin-bottom: 0">
            <div class="navbar-header">
                <a class="navbar-minimalize minimalize-styl-2 btn btn-primary " ><i class="fa fa-bars"></i> </a>
            
            </div>
            <ul class="nav navbar-top-links navbar-right">
                <li>
                    <span class="m-r-sm text-muted welcome-message" data-i18n="topnav.welcometext">Bienvenido: {{usuario}} </span>
                </li>
                <li class="dropdown" >
                    <a class="dropdown-toggle count-info" data-toggle="dropdown" href="#">
                      <i class="fa fa-envelope"></i>  <span class="label label-warning">0</span>
                    </a>
                </li>
                <li>
                    <a href="" v-on:click.prevent="cerrarSesion">
                        <i class="fa fa-sign-out"></i> Cerrar Sesión
                    </a>
                </li>
                <li>
                    <a class="right-sidebar-toggle" title="Comentarios">
                        <i class="fa fa-tasks"></i>
                    </a>
                 </li>
            </ul>
        </nav>
</div>
</template>
<script>
    import JwtService from '@/services/jwt.service'
    import { createNamespacedHelpers } from 'vuex'
    const { mapState } = createNamespacedHelpers('auth')

    export default {
        name:'top-navbar',
         computed: {
        ...mapState({
            usuario: state => state.usuario,
            rol: state => state.rol,
            listaComentario: state => state.listaComentario
        })
    },
        methods: {
            cerrarSesion(){
                JwtService.eliminarToken();
                this.$router.push({name: 'login'});
            }

        }
    }
</script>

