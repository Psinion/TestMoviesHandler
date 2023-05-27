<template>
  <loading-spinner />
  <router-view />
</template>

<script setup lang="ts">
import { useAuthStore } from './modules/auth/authStore';
import LoadingSpinner from './core/components/LoadingSpinner.vue';
import { onBeforeMount } from 'vue';

onBeforeMount(async () => {
  const authStore = useAuthStore();
  if (authStore.isAuthenticated) {
    await authStore.checkAuth();
  }
});
</script>
