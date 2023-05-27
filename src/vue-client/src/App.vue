<template>
  <router-view />
</template>

<script lang="ts">
import { useAuthStore } from './modules/auth/authStore';

export default {
  async beforeMount() {
    const authStore = useAuthStore();
    if (authStore.isAuthenticated) {
      await authStore.checkAuth();
    }
  }
};
</script>
