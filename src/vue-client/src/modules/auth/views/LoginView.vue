<template>
  <q-page class="row auth-container">
    <q-form ref="loginForm" @submit="login">
      <span class="row justify-center auth-header">Авторизация</span>
      <div class="auth-form">
        <q-input
          v-model="username"
          label="Логин"
          lazy-rules
          :rules="[val => (val && val.length > 0) || 'Обязательное поле']"
        />

        <q-input
          :dense="true"
          :type="isPassword ? 'password' : 'text'"
          v-model="password"
          label="Пароль"
          lazy-rules
          :rules="[val => (val !== null && val !== '') || 'Обязательное поле']"
        >
          <q-icon
            :name="isPassword ? 'visibility_off' : 'visibility'"
            class="cursor-pointer"
            @click="isPassword = !isPassword"
          />
        </q-input>

        <q-checkbox v-model="rememberMe" label="Запомнить меня" />

        <div class="error-message-container">
          <transition name="fade">
            <span class="error-message" v-if="errorMessage.length > 0">{{ errorMessage }}</span>
          </transition>
        </div>

        <div class="action-buttons">
          <q-btn class="full-width" label="Войти" type="submit" color="primary" />
        </div>
      </div>
    </q-form>
  </q-page>
</template>

<script lang="ts">
import { useAuthStore } from '@/modules/auth/authStore';
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
      isPassword: true,

      username: '',
      password: '',
      rememberMe: false,

      errorMessage: ''
    };
  },
  methods: {
    async login() {
      this.errorMessage = '';
      const cachedUsername = this.username;
      const cachedPassword = this.password;
      const cachedRememberMe = this.rememberMe;
      this.username = '';
      this.password = '';
      this.rememberMe = false;
      this.loginForm?.resetValidation();

      try {
        await this.authStore.login(cachedUsername, cachedPassword, cachedRememberMe);
      } catch (error) {
        if (error instanceof Error) {
          let msg = '';
          switch (error.message) {
            case 'IncorrectUserAuth':
              msg = 'Не верный логин или пароль.';
          }
          this.errorMessage = msg;
        }
      }
    }
  }
};
</script>

<style lang="scss" scoped>
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

.error-message-container {
  padding-top: 20px;
}

.error-message {
  color: $negative;
}

.fade-enter-active,
.fade-leave-active {
  transition: opacity 0.5s ease;
}
.fade-enter-from,
.fade-leave-to {
  opacity: 0;
}
</style>
