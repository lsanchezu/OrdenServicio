
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
                name: 'registro-solicitud',
                path: '/SolicitudOrdenServicio/Registrar',
                component: () => import('../pages/RegistroSolicitud.vue'),
                meta: {
                    title: 'Registrar Solicitud Contratación'
                }
            },
            {
                name: 'consulta-solicitud',
                path: '/SolicitudOrdenServicio/Consultar',
                component: () => import('../pages/ConsultaSolicitud.vue'),
                meta: {
                    title: 'Consultar Solicitud Contratación'
                }
            },
            {
                name: 'solicitud-dashboard',
                path: '/SolicitudOrdenServicio/Dashboard',
                component: () => import('../pages/Dashboard.vue'),
                meta: {
                    title: 'Dashboard Solicitud Contratación'
                }
            },
            {
                name: 'consulta-pendientes',
                path: '/SolicitudOrdenServicio/MisPendientes',
                component: () => import('../pages/ConsultaPendientes.vue'),
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
            }

            // {
            //     name: '404',
            //     path: '*',
            //     redirect: '/home'
            // }
        ]
    }
]



