<template>
  <router-view />
</template>

<script setup lang="ts">
import { useAuthStore } from './modules/auth/authStore';
import { onBeforeMount, computed, ref } from 'vue';

onBeforeMount(async () => {
  const authStore = useAuthStore();
  if (authStore.isAuthenticated) {
    await authStore.checkAuth();
  }
});
</script>
