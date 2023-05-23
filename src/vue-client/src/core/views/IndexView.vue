<template>
  <div class="relative isolate px-6 pt-14 lg:px-8">
    <button @click="simpleFetch" class="bg-indigo-600 rounded-md">12312</button>
    <h1>{{ description }}</h1>
    <router-link to="/error">Go to Home</router-link>
  </div>
</template>

<script lang="ts">
import { mainRequestor } from '../utils/requestor';

export default {
  data() {
    return {
      description: this.$mainConfig.apiBaseUrl
    };
  },
  methods: {
    async simpleFetch() {
      const response = await mainRequestor.post<string>('api/movies/testmethod', 'POST', {
        withCredentials: true
      });
      console.log(response);
    }
  }
};
</script>
