<template>
  <div class="spin">
    <div class="ring">
      <img id="pot" width="750" :src="hopper" />
    </div>
  </div>
</template>

<style lang="scss" scoped>
.spin {
  z-index: 1000;
  width: 100%;
  height: 100%;
  background-color: rgba(0, 0, 0, 0.2);
  position: fixed;
  display: flex;
  align-items: center;
  justify-content: center;
}

.ring {
  display: block;
  overflow: hidden;
  width: 300px;
  height: 150px;
  border: solid $secondary 2px;
  background-color: $primary;
  box-shadow: 0px 0px 44px 30px rgba(0, 0, 0, 0.6);
}

#pot {
  position: relative;
  bottom: 55px;
  animation: train-shift 3s linear infinite forwards;
}
@keyframes train-shift {
  0% {
    transform: translate(-251px);
  }
  100% {
    transform: translate(0px);
  }
}
</style>

<script setup lang="ts">
import hopper from '/assets/hopper.svg';
</script>
