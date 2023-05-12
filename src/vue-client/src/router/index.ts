import { createWebHistory, createRouter } from 'vue-router';
import routes from './router';
import { useAuthStore } from '@/stores/AuthStore';

const router = createRouter({
  history: createWebHistory(),
  routes
});

router.beforeEach(async to => {
  const auth = useAuthStore();

  if (!auth.isAuthenticated && to.name !== 'Login') {
    auth.returnUrl = to.fullPath;
    return { name: 'Login' };
  }

  return true;
});

export default router;
