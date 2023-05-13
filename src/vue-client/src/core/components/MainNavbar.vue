<template>
  <q-header elevated class="bg-secondary text-white">
    <q-toolbar>
      <q-toolbar-title>
        <q-avatar>
          <img src="https://cdn.quasar.dev/logo-v2/svg/logo-mono-white.svg" />
        </q-avatar>
        Title
      </q-toolbar-title>
      <q-space />
      <q-btn dense flat no-wrap>
        <q-avatar rounded size="40px">
          <img src="" />
        </q-avatar>
        <q-menu auto-close>
          <q-list dense>
            <q-item clickable class="GL__menu-link">
              <q-item-section>Выйти</q-item-section>
            </q-item>
          </q-list>
        </q-menu>
      </q-btn>
    </q-toolbar>
  </q-header>
</template>
