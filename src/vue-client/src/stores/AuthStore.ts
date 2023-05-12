import { defineStore } from "pinia";
import { computed, ref } from 'vue';
import * as fetch from '@/utils/fetchWrapper'
import type { IUserAuthResponseDto } from "@/models/dtos/IUserAuthResponseDto";
import { mainConfig } from "@/mainConfig";
import type { IUserDto } from "@/models/dtos/IUserDto";
import type { IUserAuthRequestDto } from "@/models/dtos/IUserAuthRequestDto";

const apiUrl = mainConfig.apiBaseUrl;

export const useAuthStore = defineStore('authStore2', () => {
  const token = ref<string | null>(null);
  const user  = ref<IUserDto | null>(null);
  const returnUrl = ref<string | null>(null);

  const isAuthenticated = computed(() => token.value != null)

  const login = async(username: string, password: string, rememberMe: boolean) => {
    const endpoint = "authenticate";

    const requestData : IUserAuthRequestDto = {
      username: username,
      password: password,
      rememberMe: rememberMe
    };
    const response = await fetch.post<IUserAuthRequestDto, IUserAuthResponseDto>(`${apiUrl}/${endpoint}`, requestData);
    
    user.value = response.user;
    token.value = response.token;
    if(rememberMe) {
      localStorage.setItem('user', JSON.stringify(user.value));
      localStorage.setItem('token', token.value);
    }
  }

  const logout = () => {
    user.value = null;
    token.value = null;
    localStorage.removeItem('user');
    localStorage.removeItem('token');
  }

  return {
    token, user, returnUrl,
    isAuthenticated,
    login, logout
  }
});