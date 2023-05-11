<template>
  <q-layout view="hHh lpR fFf">
    <MainNavbar/>

    <q-page-container>
      <router-view />
    </q-page-container>
  </q-layout>
</template>

<script lang="ts">
import MainNavbar from '@/components/MainNavbar.vue';

export default {
  components: {
    MainNavbar
  }
}
</script>