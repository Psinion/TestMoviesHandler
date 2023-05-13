<template>
  <q-layout view="hHh lpR fFf">
    <main-navbar/>

    <q-page-container>
      <router-view />
    </q-page-container>
  </q-layout>
</template>

<script lang="ts">
import MainNavbar from '@/core/components/MainNavbar.vue';

export default {
  components: {
    MainNavbar
  }
}
</script>
