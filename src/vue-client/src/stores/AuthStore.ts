import { defineStore } from "pinia";


export const useAuthStore = defineStore('authStore', {
  state: () => ({
    token: null as string | null
  })
}
)