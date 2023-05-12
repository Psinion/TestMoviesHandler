import { defineStore } from 'pinia';
import { computed, ref } from 'vue';
import type { IUserAuthResponseDto } from '@/modules/auth/dtos/IUserAuthResponseDto';
import { mainConfig } from '@/mainConfig';
import type { IUserDto } from '@/modules/auth/dtos/IUserDto';
import type { IUserAuthRequestDto } from '@/modules/auth/dtos/IUserAuthRequestDto';
import { mainRequestor } from '@/core/utils/requestor';

const apiUrl = mainConfig.apiBaseUrl;

export const useAuthStore = defineStore('authStore2', () => {
  const token = ref<string | null>(null);
  const user = ref<IUserDto | null>(null);
  const returnUrl = ref<string | null>(null);

  const isAuthenticated = computed(() => token.value != null);

  const login = async (username: string, password: string, rememberMe: boolean) => {
    const endpoint = 'authenticate';

    const requestData: IUserAuthRequestDto = {
      username: username,
      password: password,
      rememberMe: rememberMe
    };
    const response = await mainRequestor.post<IUserAuthRequestDto, IUserAuthResponseDto>(
      `${apiUrl}/${endpoint}`,
      'POST',
      requestData
    );

    user.value = response.user;
    token.value = response.token;
    if (rememberMe) {
      localStorage.setItem('user', JSON.stringify(user.value));
      localStorage.setItem('token', token.value);
    }
  };

  const logout = () => {
    user.value = null;
    token.value = null;
    localStorage.removeItem('user');
    localStorage.removeItem('token');
  };

  return {
    token,
    user,
    returnUrl,
    isAuthenticated,
    login,
    logout
  };
});
