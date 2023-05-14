import { createWebHistory, createRouter, type RouteRecordNormalized } from 'vue-router';
import routes, { Rules } from './router';
import { useAuthStore } from '@/core/stores/AuthStore';

const router = createRouter({
  history: createWebHistory(),
  routes
});

router.beforeEach(async to => {
  const auth = useAuthStore();

  const matchedRoutes = to.matched; // Массив совпавших маршрутов по заданному URL адресу.
  console.log(to.fullPath);
  if (!auth.isAuthenticated) {
    if (isGuestRoutes(matchedRoutes)) {
      return true;
    } else {
      auth.returnUrl = to.fullPath;
      return { name: 'Login' };
    }
  } else {
    if (to.name == 'Login') {
      // Если авторизованы, то нет смысла показывать страницу авторизации.
      return { name: 'Index' };
    }
  }

  return true;
});

/**
 * Являются ли все совпавшие маршруты доступными для всех.
 * @param matchedRoutes
 * @returns
 */
function isGuestRoutes(matchedRoutes: RouteRecordNormalized[]) {
  return matchedRoutes.every(record => record.meta['Rule'] == Rules.Guest);
}

export default router;
