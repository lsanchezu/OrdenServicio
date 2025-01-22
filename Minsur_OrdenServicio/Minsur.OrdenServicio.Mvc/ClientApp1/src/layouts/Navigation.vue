<template>
    <nav class="navbar-default navbar-static-side" role="navigation">
        <div class="sidebar-collapse">
            <ul class="nav" id="side-menu">
                <li class="nav-header">
                    <div class="dropdown profile-element">
                        <span>
                            <img alt="image" src="/img/logo-minsur.png" />
                        </span>
                    </div>
                    <a data-toggle="dropdown" class="dropdown-toggle" href="#">
                        <span class="clear">
                            <span class="text-muted text-xs block">{{rol}}</span>
                        </span>
                    </a>
                    <div class="logo-element">
                        IN+
                    </div>
                </li>
                <template v-for="(menu) in listaMenu">
                     <li v-for="(item, indexItem) in menu.listaMenuItem" 
                        :key="indexItem"
                        v-bind:class ="[menu.url === $route.fullPath ? 'active': '']"> 
                        <router-link :to="{path: item.url}" ><i :class="item.icono"></i> <span class="nav-label" data-i18n="nav.dashboard">{{item.nombre}}</span></router-link> 
                    </li>
                </template>
            </ul>
        </div>
    </nav>
</template>
<script>

import axios from 'axios'
import router from '../router/index'
import MetisMenu from 'metisMenu'
import { createNamespacedHelpers } from 'vuex'
const { mapState } = createNamespacedHelpers('auth')

export default {
    name: 'navigation-report',
    data(){
        return {
            router
        }
    },
    computed: {
        ...mapState({
            usuario: state => state.usuario,
            rol: state => state.rol,
            cargo: state => state.cargo,
            listaMenu: state => state.listaMenu
        })
    }
}
</script>
