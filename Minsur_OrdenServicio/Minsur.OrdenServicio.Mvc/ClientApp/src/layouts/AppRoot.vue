<template>
    <div id="wrapper" v-bind:class="{'page-content':true, 'sk-loading' : loading}">
       <loading></loading>
       <navigation-report></navigation-report>
        <div id="page-wrapper" class="gray-bg">

            <top-navbar></top-navbar>

            <div class="main-report">
              <router-view></router-view>
            </div>

            <footer-report></footer-report>

        </div>

        <right-side-bar></right-side-bar>

    </div>
</template>
<script>
    import Vue from 'vue'
    import Navigation from './Navigation.vue'
    import Footer from './Footer.vue'
    import RightSidebar from './RightSidebar.vue'
    import TopNavbar from './TopNavbar.vue'
    import * as types from '@/store/auth/types'

    import CabeceraPagina from '@/components/shared/CabeceraPagina'
    import Loading from '@/components/shared/Loading'

    import { createNamespacedHelpers } from 'vuex'
    const { mapState, mapActions } = createNamespacedHelpers('solicitudServicio')

    Vue.component('navigation-report', Navigation);
    Vue.component('footer-report', Footer);
    Vue.component('right-side-bar', RightSidebar);
    Vue.component('top-navbar', TopNavbar);

    export default {
       components: {
            CabeceraPagina,
            Loading
        },
        data () {
        return {

        }
      },
      computed:{
            ...mapState({
              loading: state => state.loading
            })
      },
      created() {
        this.$store.dispatch(`auth/${types.OBTENER_SITEMAP}`); 
      },
      async mounted(){
        this.$store.commit(`auth/${types.DATOS_USUARIO}`);
        
      }
    }

</script>