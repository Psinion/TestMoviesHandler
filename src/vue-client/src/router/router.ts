const routes = [
  {
    path: '/',
    name: 'MainLayout',
    component: () => import('@/core/layouts/MainLayout.vue'),
    children: [
      {
        path: '',
        name: 'Index',
        component: () => import('@/core/views/IndexView.vue')
      },
      {
        path: '/login',
        name: 'Login',
        component: () => import('@/modules/auth/views/LoginView.vue')
      }
    ]
  }
];

export default routes;
