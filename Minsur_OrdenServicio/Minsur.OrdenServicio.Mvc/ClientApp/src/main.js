import Vue from 'vue'
import App from './App'
import router from './router/index'
import ApiService from './services/api.service'
import store from './store'
import { sync } from 'vuex-router-sync'
import VeeValidate from "vee-validate";

import es from 'vee-validate/dist/locale/es'

import AppConfig from './config/app.config'
import { URL_SOLICITUD } from './constants/api.contants'
import Element from 'element-ui'
import locale from 'element-ui/lib/locale/lang/es'
import './static/element-ui/theme/index.css'
import './static/customStyle.css'

import VueI18n from 'vue-i18n'

import JwtService from './services/jwt.service'


const token = JwtService.obtenerToken();
if(token === undefined || token === null){
  window.location.href = URL_SOLICITUD.Login
}    
else{
  Vue.use(VueI18n);
  const i18n = new VueI18n({
    locale: 'es'
  });
  
  Vue.use(VeeValidate, {
    i18n,
    dictionary: {
      es
    }
  });
  
  Vue.use(Element, {
    locale
  })
  
  AppConfig.init();
  ApiService.init();
  
  sync(store, router)
  Vue.config.productionTip = false
  
  new Vue({
      router,
      store,
      render: h => h(App)
   }).$mount('#app');

}      




