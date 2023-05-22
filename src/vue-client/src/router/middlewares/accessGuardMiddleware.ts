import { useAuthStore } from '@/modules/auth/authStore';
import type { Permissions } from '@/modules/auth/permissions';
import type { RouteLocationNormalized } from 'vue-router';
import { RoutesNames } from '../routesNames';

// Проверка прав доступа к маршруту
export function accessGuardMiddleware(to: RouteLocationNormalized) {
  const { permissions } = to.meta;
  if (!permissions) {
    return;
  }

  const permissionsEnum = permissions as Permissions[];

  const authStore = useAuthStore();
  if (authStore.checkPermission(permissionsEnum)) {
    return;
  }

  if (!authStore.isAuthenticated) {
    authStore.returnUrl = to.fullPath;
    return { name: RoutesNames.Login };
  }

  return { name: RoutesNames.Error };
}
