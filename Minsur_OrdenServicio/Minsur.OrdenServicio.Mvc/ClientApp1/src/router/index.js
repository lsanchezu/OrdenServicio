import Vue from 'vue'
import VueRouter from 'vue-router'
import JwtService from '../services/jwt.service'
import { routes } from './routes'
import { URL_SOLICITUD } from '../constants/api.contants'

Vue.use(VueRouter)

let router = new VueRouter({
    mode: 'history',
    routes
})


router.beforeEach((to, from, next) => {
    const nearestWithTitle = to.matched.slice().reverse().find(r => r.meta && r.meta.title);
    const nearestWithMeta = to.matched.slice().reverse().find(r => r.meta && r.meta.metaTags);
    const previousNearestWithMeta = from.matched.slice().reverse().find(r => r.meta && r.meta.metaTags);

   if (nearestWithTitle) document.title = nearestWithTitle.meta.title;

    Array.from(document.querySelectorAll('[data-vue-router-controlled]')).map(el => el.parentNode.removeChild(el));

    let token = JwtService.obtenerToken();

    // if(to.name === 'login' && token !== undefined && token !== null){
    //     return next({name: 'home'});
    // }
    if(token === undefined || token === null){
        window.location.href = URL_SOLICITUD.Login
        next();
        return;
    }    
    
    if (!nearestWithMeta) return next();

    nearestWithMeta.meta.metaTags.map(tagDef => {
        const tag = document.createElement('meta');

        Object.keys(tagDef).forEach(key => {
            tag.setAttribute(key, tagDef[key]);
        });

        tag.setAttribute('data-vue-router-controlled', '');

        return tag;
    })
     .forEach(tag => document.head.appendChild(tag));


       
    next();
});



export default router