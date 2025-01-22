
import SoliciudService from '@/services/solicitud.service'
import * as types from './types'
import {ID_TOKEN_KEY} from '@/constants/api.contants';

const state = {
    usuario: "",
    rol: "",
    cargo: "",
    listaMenu: []
};

const actions = {
  async [types.OBTENER_SITEMAP](context){
      await  SoliciudService.obtenerSiteMap() 
      .then(response => {
        context.commit(types.ASIGNAR_SITEMAP,  response.data.listaMenu);
        
      }).finally(() =>  $('#side-menu').metisMenu()); 
  }
}

const mutations = {
  [types.DATOS_USUARIO]: (state) => {
        let data = JSON.parse(decodeURIComponent(escape(atob(window.localStorage.getItem(ID_TOKEN_KEY).split('.')[1]))));
        state.usuario = `${data.Usuario} - ${data.NombreApellido}` 
        state.rol = data.Rol;
        state.cargo = data.Cargo;
    },
    [types.ASIGNAR_SITEMAP]:(state, listaMenu) => {
        state.listaMenu = listaMenu;
   }  
};
  
  const getters = {
    messages: state => state.messages,
  };

export default {
    namespaced: true,
    state,
    actions,
    getters,
    mutations,
  };