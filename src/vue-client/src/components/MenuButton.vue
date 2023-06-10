<template>
  <a class="menu-item" @click="$router.push({ name: viewName })">
    <div class="menu-item-image-holder">
      <img class="menu-item-image" :src="image" />
    </div>
    <span class="menu-item-text">{{ title.toString() }}</span>
  </a>
</template>

<script setup lang="ts">
import type { RoutesNames } from '@/router/routesNames';
import type { PropType } from 'vue';

defineProps({
  title: {
    type: String,
    required: true
  },
  image: {
    type: String,
    required: true
  },
  viewName: {
    type: String as PropType<RoutesNames>,
    required: true
  }
});
</script>

<style lang="scss">
.menu-item {
  text-decoration: none;
  margin: 10px;
  padding: 20px;
  vertical-align: top;
  display: inline-block;
  text-align: center;
  height: 190px;
  width: 190px;
  cursor: pointer;
}

@media screen and (max-width: 480px) {
  .menu-item {
    width: 100px;
  }
}

@media screen and (min-width: 481) and (max-width: 900px) {
  .menu-item {
    width: 150px;
  }
}

.menu-item:hover {
  //background-color: $accent;
  //color: white;
}

.menu-item-image {
  width: 80px;
}

.menu-item-image-holder {
  height: 80px;
  transition: 0.3s;
}

.menu-item-image-holder:hover {
  height: 80px;
  transform: scale(1.35);
}

.menu-item-text {
  width: 220px;
}
</style>
