<template>
  <div class="relative isolate px-6 pt-14 lg:px-8">
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
</script>