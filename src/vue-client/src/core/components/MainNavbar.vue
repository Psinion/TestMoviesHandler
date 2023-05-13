<template>
  <q-header elevated class="bg-secondary text-black text-white">
    <q-toolbar>
      <q-toolbar-title>
        <q-avatar color="black">
          <img src="https://cdn.quasar.dev/logo-v2/svg/logo-mono-white.svg" />
        </q-avatar>
        Title
      </q-toolbar-title>
      <q-space />
      <span>{{ user?.username }}</span>
      <q-btn v-if="user != null" dense flat no-wrap>
        <q-icon name="las la-user" />
        <q-menu auto-close>
          <q-list dense>
            <q-item clickable @click="logout">
              <q-item-section>Выйти</q-item-section>
            </q-item>
          </q-list>
        </q-menu>
      </q-btn>
    </q-toolbar>
  </q-header>
</template>

<script lang="ts">
import { useAuthStore } from '../stores/AuthStore';
import { storeToRefs } from 'pinia';

export default {
  setup() {
    const authStore = useAuthStore();
    const { user } = storeToRefs(authStore);

    return {
      authStore,
      user
    };
  },
  data() {
    return {};
  },
  methods: {
    logout() {
      this.authStore.logout();
    }
  }
};
</script>

<style scoped></style>
