<template>
  <body>
    <q-page class="row auth-container">
      <q-form ref="loginForm" @submit="login">
        <span class="row justify-center auth-header">Авторизация</span>
        <div class="auth-form">
          <q-input
            :dense="true"
            v-model="username"
            label="Логин"
            lazy-rules
            :rules="[val => (val && val.length > 0) || 'Обязательное поле']"
          />

          <q-input
            :dense="true"
            type="password"
            v-model="password"
            label="Пароль"
            lazy-rules
            :rules="[val => (val !== null && val !== '') || 'Обязательное поле']"
          />

          <q-toggle v-model="rememberMe" label="Запомнить меня" />

          <div class="action-buttons">
            <q-btn class="full-width" label="Войти" type="submit" color="primary" />
          </div>
        </div>
      </q-form>
    </q-page>
  </body>
</template>

<script lang="ts">
import { useAuthStore } from '@/core/stores/AuthStore';
import type { QForm } from 'quasar';
import { ref } from 'vue';

export default {
  setup() {
    const loginForm = ref<QForm>();
    const authStore = useAuthStore();

    return {
      loginForm,
      authStore
    };
  },
  data() {
    return {
      username: '',
      password: '',
      rememberMe: false
    };
  },
  methods: {
    async login() {
      const cachedUsername = this.username;
      const cachedPassword = this.password;
      const cachedRememberMe = this.rememberMe;
      this.username = '';
      this.password = '';
      this.rememberMe = false;
      this.loginForm?.resetValidation();
      await this.authStore.login(cachedUsername, cachedPassword, cachedRememberMe);
    }
  }
};
</script>

<style lang="scss" scoped>
* {
  font-family: 'Roboto';
}

.auth-container {
  align-items: center;
  justify-content: center;
}

.auth-form {
  max-width: 600px;
  min-width: 350px;
  padding: 20px 20px 20px 20px;
  border: 2px solid $secondary;
}

.auth-header {
  color: $accent;
  font-size: 2.5em;
  padding: 20px;
  font-weight: bold;
  background-color: $secondary;
}

.action-buttons {
  padding-top: 20px;
}
</style>
