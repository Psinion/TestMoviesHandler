import { defineStore } from "pinia";


export const useAuthStore = defineStore('authStore', {
  state: () => ({
    token: null as string | null,
    returnUrl: null as string | null,
  }),
  getters: {
    isAuthenticated: (state) => state.token != null,
  },
}
)