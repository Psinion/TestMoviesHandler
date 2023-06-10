import { Permissions } from '@/modules/auth/permissions';
import { RoutesNames } from './routesNames';

const routes = [
  {
    path: '/',
    name: RoutesNames.MainLayout,
    component: () => import('@/layouts/MainLayout.vue'),
    children: [
      {
        path: '',
        name: RoutesNames.Index,
        component: () => import('@/views/IndexView.vue'),
        meta: {
          title: 'Основная страница',
          permissions: [Permissions.LoggedIn]
        }
      },
      {
        path: '/error',
        name: RoutesNames.Error,
        component: () => import('@/views/ErrorView.vue'),
        meta: {
          title: 'Ошибка',
          permissions: [Permissions.LoggedIn]
        }
      },
      {
        path: '/login',
        name: RoutesNames.Login,
        component: () => import('@/modules/auth/views/LoginView.vue'),
        meta: {
          title: 'Авторизация'
        }
      }
    ]
  },
  {
    path: '/',
    name: 'BlankLayout',
    component: () => import('@/layouts/BlankLayout.vue'),
    children: []
  },
  {
    path: '/test',
    name: 'TestLayout',
    component: () => import('@/modules/test/layouts/TestLayout.vue')
  }
];

export default routes;
