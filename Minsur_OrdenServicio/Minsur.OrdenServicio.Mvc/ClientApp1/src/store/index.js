import Vue from 'vue';
import Vuex from 'vuex';
import authModule from './auth';
import solicitudServicioModule from './solicitudServicio';

Vue.use(Vuex)

export default new Vuex.Store({
  modules: {
    solicitudServicio: solicitudServicioModule,
    auth: authModule
  },
});
