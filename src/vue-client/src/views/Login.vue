<template>
  <q-page class="row auth-container">
    <q-form
      class="q-gutter-md auth-form"
      @submit="login"
    >
      <h5 class="row justify-center">Авторизация</h5>
      <q-input
        filled
        v-model="username"
        label="Логин"
        hint="Без указания электронной почты"
        lazy-rules
        :rules="[ val => val && val.length > 0 || 'Обязательное поле']"
      />

      <q-input
        filled
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
export default {
  data() {
    return {
      username: "",
      password: "",
      rememberMe: false
    }
  },
  methods: {
    async login() {
      console.log('try log');
      return;

      const response = await fetch(`${import.meta.env.VITE_SERVER_URL}/api/movies/testmethod`);
      const data = response.json();
      //const movies = <Movie[]>data;
      console.log(data);
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