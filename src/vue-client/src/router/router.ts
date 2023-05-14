export enum Rules {
  Guest, // Маршрут доступен без аутентификации.
  NeedAuth // Маршрут доступен только будучи аутентифицированным.
}

const routes = [
  {
    path: '/',
    name: 'MainLayout',
    component: () => import('@/core/layouts/MainLayout.vue'),
    meta: {
      Rule: Rules.Guest
    },
    children: [
      {
        path: '',
        name: 'Index',
        component: () => import('@/core/views/IndexView.vue'),
        meta: {
          Rule: Rules.NeedAuth
        }
      },
      {
        path: '/error',
        name: 'Error',
        component: () => import('@/core/views/ErrorView.vue'),
        meta: {
          Rule: Rules.Guest
        }
      },
      {
        path: '/login',
        name: 'Login',
        component: () => import('@/modules/auth/views/LoginView.vue'),
        meta: {
          Rule: Rules.Guest
        }
      },
      {
        path: '/login',
        name: 'Login',
        component: () => import('@/modules/auth/views/LoginView.vue'),
        meta: {
          Rule: Rules.Guest
        }
      }
    ]
  },
  {
    path: '/test',
    name: 'TestLayout',
    component: () => import('@/modules/test/layouts/TestLayout.vue')
  }
];

export default routes;
