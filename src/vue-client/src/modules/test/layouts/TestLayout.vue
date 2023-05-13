<template>
  <div>
    <h2 class="block">Тестовый текст</h2>
  </div>
  <router-view/>
</template>

<script lang="ts">
// Test styles
import '@/modules/test/styles/test-global.scss'
</script>

<style>

#app {
  font-family: Avenir, Halvetica, Arial, sans-serif;
}

.div {
  background-color: red;
}

.block {
  background-color: red;
  padding: 10px;
  border: 10px;
  margin: 10px;
}

</style>