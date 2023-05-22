import { useAuthStore } from '@/modules/auth/authStore';

// Получение данных о пользователе.
export function fetchAuthDataMiddleware(): Promise<void> {
  const authStore = useAuthStore();
  return authStore.fetchUserPermissions();
}
