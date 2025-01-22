import { compile } from 'vue-template-compiler';

export const routes = [
    {
        path: '/',
        component:  () => import('../layouts/AppRoot.vue'),
        children: [
            {
                name: 'home-dashboard',
                path: '/SolicitudOrdenServicio/Index',
                component:  () => import('../pages/Dashboard.vue'),
                meta: {
                    title: 'Dashboard'
                }
            },
            {
                name: 'registro-orden',
                path: '/SolicitudOrdenServicio/Registrar',
                component: () => import('../pages/RegistroOrden.vue'),
                meta: {
                    title: 'Registrar Orden de Servicio'
                }
            },
            {
                name: 'consulta-orden',
                path: '/SolicitudOrdenServicio/Consultar',
                component: () => import('../pages/ConsultaOrden.vue'),
                meta: {
                    title: 'Consultar Orden de Servicio'
                }
            },
            {
                name: 'orden-dashboard',
                path: '/SolicitudOrdenServicio/Dashboard',
                component: () => import('../pages/Dashboard.vue'),
                meta: {
                    title: 'Dashboard Orden de Servicio'
                }
            },
            // {
            //     name: 'orden-pendientes',
            //     path: '/SolicitudOrdenServicio/MisPendientes',
            //     component: () => import('../pages/ConsultaPendientes.vue'),
            //     meta: {
            //         title: 'Mis Pendientes'
            //     }
            // },
            {
                name: 'orden-pendientes',
                path: '/SolicitudOrdenServicio/MisPendientes',
                component: () => import('../pages/SolicitudPendienteCho.vue'),
                meta: {
                    title: 'Mis Pendientes'
                }
            },
            {
                name: 'gestion-companias-proyectos',
                path: '/SolicitudOrdenServicio/GestionCompaniasPoyectos',
                component: () => import('../pages/GestionCompaniasPoyectos.vue'),
                meta:{
                    title: 'Gestión de Compañías y Proyectos'
                }
            },
            {
                name: 'gestion-gobernanza',
                path: '/SolicitudOrdenServicio/GestionGobernanza',
                component: () => import('../pages/GestionGobernanza.vue'),
                meta:{
                    title: 'Gestión de Gobernanza'
                }
            },
            {
                name: 'gestion-usuarios',
                path: '/SolicitudOrdenServicio/GestionUsuarios',
                component: () => import('../pages/GestionUsuarios.vue'),
                meta:{
                    title: 'Gestión de Usuarios'
                }
            },
            {
                name: 'gestion-roles',
                path: '/SolicitudOrdenServicio/GestionRoles',
                component: () => import('../pages/GestionRoles.vue'),
                meta:{
                    title: 'Gestión de Roles'
                }
            },
            {
                name: 'solicitud-orden',
                path: '/SolicitudOrdenServicio/RegistrarSolicitud',
                component: () => import('../pages/RegistroSolicitud.vue'),
                meta:{
                    title: 'Gestion de Solicitudes'
                }
            },
            {
                name: 'contratistas',
                path: '/SolicitudOrdenServicio/Contratistas',
                component: () => import('../pages/Contratistas.vue'),
                meta:{
                    title: 'Proveedores'
                }
            },
            {
                name: 'contratos',
                path: '/SolicitudOrdenServicio/Contratos',
                component: () => import('../pages/RegistroContratos.vue'),
                meta:{
                    title: 'Contratos'
                }
            },
            {
                name: 'solicitudes',
                path: '/SolicitudOrdenServicio/Solicitudes',
                component: () => import('../pages/ConsultaSolicitudes.vue'),
                meta:{
                    title: 'Solicitudes'
                }
            },
            {
                name: 'pendientes',
                path: '/SolicitudOrdenServicio/Pendientes',
                component: () => import('../pages/SolicitudPendiente.vue'),
                meta:{
                    title: 'Contratos'
                }
            }
            // {
            //     name: '404',
            //     path: '*',
            //     redirect: '/home'
            // }
        ]
    }
]



