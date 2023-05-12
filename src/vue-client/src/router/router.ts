const routes = [
  {
    path: '/',
    name: 'MainLayout',
    component: () => import('@/layouts/MainLayout.vue'),
    children: [
      {
        path: '',
        name: 'Index',
        component: () => import('@/views/IndexView.vue')
      },
      {
        path: '/login',
        name: 'Login',
        component: () => import('@/views/LoginView.vue')
      }
    ]
  }
];

export default routes;
