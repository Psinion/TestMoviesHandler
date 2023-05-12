<template>
  <q-page class="row auth-container">
    <q-form
      class="q-gutter-md auth-form"
      @submit="login"
    >
      <h5 class="row justify-center">Авторизация</h5>
      <q-input
        :dense="true"
        v-model="username"
        label="Логин"
        lazy-rules
        :rules="[ val => val && val.length > 0 || 'Обязательное поле']"
      />

      <q-input
        :dense="true"
        type="password"
        v-model="password"
        label="Пароль"
        lazy-rules
        :rules="[
          val => val !== null && val !== '' || 'Обязательное поле'
        ]"
      />

      <q-toggle v-model="rememberMe" label="Запомнить меня" />

      <div>
        <q-btn class="full-width" label="Войти" type="submit" color="primary"/>
      </div>
    </q-form>
  </q-page>
</template>

<script lang="ts">
import { useAuthStore } from '@/stores/AuthStore';

export default {
  setup() {
    const authStore = useAuthStore();

    return {
      authStore
    }
  },
  data() {
    return {
      username: '',
      password: '',
      rememberMe: false
    }
  },
  methods: {
    async login() {
      console.log('keke');
      await this.authStore.login(this.username, this.password, this.rememberMe);
    }
  }
}
</script>

<style scoped>
.auth-container {
  align-items: center;
  justify-content: center;
}

.auth-form {
  max-width: 600px;
  min-width: 300px;
}

</style>