import { defineStore } from 'pinia';
import { computed, ref } from 'vue';
import type { AuthResponse } from '@/modules/auth/models/responses/authResponse';
import type { UserPermissionDto } from './models/userPermissionDto';
import type { IUserAuthRequestDto } from '@/modules/auth/models/IUserAuthRequestDto';
import { mainRequestor } from '@/core/utils/requestor';
import router from '@/router';
import type { IUser } from '../../core/models/IUser';
import { Permissions } from './permissions';
import { mainConfig } from '@/main.config';
import { RoutesNames } from '@/router/routesNames';

export const useAuthStore = defineStore('authStore', () => {
  const user = ref<IUser | null>(JSON.parse(localStorage.getItem('user') as string) as IUser);
  const accessToken = ref<string | null>(localStorage.getItem('token'));
  const returnUrl = ref<string | null>(null);
  const userPermissions = ref<Record<string, boolean | undefined> | null>(null);

  const isAuthenticated = computed(() => accessToken.value != null);

  const login = async (username: string, password: string, rememberMe: boolean): Promise<void> => {
    const endpoint = 'users/authenticate';

    const requestData: IUserAuthRequestDto = {
      username: username,
      password: password,
      rememberMe: rememberMe
    };

    try {
      const response = await mainRequestor.post<AuthResponse>(`${endpoint}`, 'POST', {
        body: requestData,
        withCredentials: true
      });
      user.value = {
        username: response.user.username
      };
      localStorage.setItem('user', JSON.stringify(user.value));
      saveAccessToken(response.token);
      router.push(returnUrl.value ?? { name: 'Index' });
    } catch (error) {
      throw error;
    }
  };

  const logout = (): void => {
    user.value = null;
    accessToken.value = null;
    localStorage.removeItem('user');
    localStorage.removeItem('token');
    router.push(RoutesNames.Login);
  };

  const checkAuth = async (): Promise<void> => {
    const endpoint = 'users/refresh';
    const refreshingTokenPromise = fetch(`${mainConfig.apiBaseUrl}/${endpoint}`, {
      method: 'GET',
      headers: {
        'Content-type': 'application/json'
      },
      credentials: 'include'
    })
      .then(response => {
        if (response.status == 401) {
          throw new Error();
        }
        return response.json();
      })
      .then((data: AuthResponse) => {
        saveAccessToken(data.token);
      })
      .catch(error => {
        logout();
        throw error;
      });
    return refreshingTokenPromise;
  };

  const saveAccessToken = (token: string): void => {
    accessToken.value = token;
    localStorage.setItem('token', token);
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
    if (!isAuthenticated) {
      return;
    }

    if (!userPermissions.value) {
      return false;
    }

    return permissions.every(permission =>
      userPermissions.value ? userPermissions.value[permission] : false
    );
  };

  return {
    user,
    accessToken,
    returnUrl,
    isAuthenticated,
    login,
    logout,
    checkAuth,
    fetchUserPermissions,
    checkPermission
  };
});
