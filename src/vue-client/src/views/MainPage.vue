<template>
  <div class="relative isolate px-6 pt-14 lg:px-8">
    <button @click="simpleFetch" class="bg-indigo-600 rounded-md">12312</button>
    <h1>{{ description }}</h1>
  </div>
</template>

<script lang="ts">
export default {
  data() {
    return {
      description: import.meta.env.VITE_SERVER_URL,
    }
  },
  methods: {
    async simpleFetch() {
      const response = await fetch(`${import.meta.env.VITE_SERVER_URL}/api/movies/testmethod`);
      const data = response.json();
      //const movies = <Movie[]>data;
      console.log(data);
    }
  }
}

interface Movie {
  id: Number,
  description: String,
  genre: Number,
  title: String
}
</script>