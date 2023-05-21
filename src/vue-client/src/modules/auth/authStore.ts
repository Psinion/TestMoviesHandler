import { defineStore } from 'pinia';
import { computed, ref } from 'vue';
import type { IUserAuthResponseDto } from '@/modules/auth/dtos/IUserAuthResponseDto';
import type { UserPermissionDto } from './dtos/userPermissionDto';
import type { IUserAuthRequestDto } from '@/modules/auth/dtos/IUserAuthRequestDto';
import { mainRequestor } from '@/core/utils/requestor';
import router from '@/router';
import type { IUser } from '../../core/models/IUser';
import type { PermissionsEnum } from './permissionsEnum';

export const useAuthStore = defineStore('authStore', () => {
  const user = ref<IUser | null>(JSON.parse(localStorage.getItem('user') as string) as IUser);
  const token = ref<string | null>(localStorage.getItem('token'));
  const returnUrl = ref<string | null>(null);
  const userPermissions = ref<PermissionsEnum[] | null>(null);

  const isAuthenticated = computed(() => token.value != null);

  const login = async (username: string, password: string, rememberMe: boolean): Promise<void> => {
    const endpoint = 'users/authenticate';

    const requestData: IUserAuthRequestDto = {
      username: username,
      password: password,
      rememberMe: rememberMe
    };

    try {
      const response = await mainRequestor.post<IUserAuthResponseDto>(
        `${endpoint}`,
        'POST',
        requestData
      );
      user.value = {
        username: response.user.username
      };
      token.value = response.token;
      localStorage.setItem('user', JSON.stringify(user.value));
      localStorage.setItem('token', token.value);
      router.push(returnUrl.value ?? { name: 'Index' });
    } catch (error) {
      throw error;
    }
  };

  const logout = (): void => {
    user.value = null;
    token.value = null;
    localStorage.removeItem('user');
    localStorage.removeItem('token');
    router.push({ name: 'Login' });
  };

  const getUserPermissions = async (): Promise<void> => {
    if (userPermissions.value) {
      return;
    }

    if (isAuthenticated.value) {
      const endpoint = 'users/permissions';

      try {
        const response = await mainRequestor.post<UserPermissionDto>(`${endpoint}`, 'POST');

        // https://stackoverflow.com/questions/48483534/converting-string-array-to-enum-in-typescript
        const permissions = response.permissions.reduce((acc, current) => {
          acc[current] = current;
          return acc;
        }, Object.create(null));

        userPermissions.value = permissions;
      } catch (error) {
        console.log(error);
      }
    }
  };

  return {
    user,
    token,
    returnUrl,
    isAuthenticated,
    login,
    logout,
    getUserPermissions
  };
});
