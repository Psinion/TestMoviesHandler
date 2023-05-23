import { defineStore } from 'pinia';
import { computed, ref } from 'vue';
import type { IUserAuthResponseDto } from '@/modules/auth/dtos/IUserAuthResponseDto';
import type { UserPermissionDto } from './dtos/userPermissionDto';
import type { IUserAuthRequestDto } from '@/modules/auth/dtos/IUserAuthRequestDto';
import { mainRequestor } from '@/core/utils/requestor';
import router from '@/router';
import type { IUser } from '../../core/models/IUser';
import { Permissions } from './permissions';

export const useAuthStore = defineStore('authStore', () => {
  const user = ref<IUser | null>(JSON.parse(localStorage.getItem('user') as string) as IUser);
  const token = ref<string | null>(localStorage.getItem('token'));
  const returnUrl = ref<string | null>(null);
  const userPermissions = ref<Record<string, boolean | undefined> | null>(null);

  const isAuthenticated = computed(() => token.value != null);

  const login = async (username: string, password: string, rememberMe: boolean): Promise<void> => {
    const endpoint = 'users/authenticate';

    const requestData: IUserAuthRequestDto = {
      username: username,
      password: password,
      rememberMe: rememberMe
    };

    try {
      const response = await mainRequestor.post<IUserAuthResponseDto>(`${endpoint}`, 'POST', {
        body: requestData,
        withCredentials: true
      });
      user.value = {
        username: response.user.username
      };
      token.value = response.accessToken;
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

  const fetchUserPermissions = async (): Promise<void> => {
    if (userPermissions.value) {
      return;
    }

    if (isAuthenticated.value) {
      const endpoint = 'users/permissions';

      try {
        const response = await mainRequestor.post<UserPermissionDto>(`${endpoint}`, 'POST');

        // TODO: Написать юнит тест для проверки правильности прав на клиенте и сервере.
        const permissions = response.permissions;

        userPermissions.value = {};

        for (const perm in Permissions) {
          userPermissions.value[perm] = false;
        }
        userPermissions.value[Permissions.LoggedIn] = true;

        for (const perm of permissions) {
          userPermissions.value[perm] = true;
        }

        console.log(userPermissions.value);
      } catch (error) {
        console.log(error);
      }
    }
  };

  const checkPermission = (permissions: Permissions[]) => {
    if (!userPermissions.value) {
      return false;
    }

    return permissions.every(permission =>
      userPermissions.value ? userPermissions.value[permission] : false
    );
  };

  return {
    user,
    token,
    returnUrl,
    isAuthenticated,
    login,
    logout,
    fetchUserPermissions,
    checkPermission
  };
});
