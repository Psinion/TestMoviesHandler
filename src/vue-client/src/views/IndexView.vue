<script lang="ts"></script>

<template>
  <q-page class="row justify-center">
    <div class="page-width">
      <div class="q-gutter-x-ls q-gutter-y-lg">
        <menu-button
          v-for="button in buttons"
          :key="button.id"
          :title="button.name"
          :image="button.image"
          :view-name="button.viewName"
        />
      </div>
    </div>
  </q-page>
</template>

<script setup lang="ts">
import { ref } from 'vue';
import MenuButton from '@/components/MenuButton.vue';
import { RoutesNames } from '@/router/routesNames';

const buttons = ref([
  {
    id: 1,
    name: 'Архив фильмов',
    viewName: RoutesNames.MoviesArchive,
    image: ''
  }
]);
</script>

<style lang="scss" scoped>
.page-width {
  margin-top: 2rem;
  max-width: 1096px;
}
</style>
