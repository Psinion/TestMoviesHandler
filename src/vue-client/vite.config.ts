import { fileURLToPath, URL } from 'node:url';

import { defineConfig } from 'vite';
import vue from '@vitejs/plugin-vue';
import vueJsx from '@vitejs/plugin-vue-jsx';
import { quasar } from '@quasar/vite-plugin';

// https://vitejs.dev/config/
export default defineConfig({
  server: {
    https: {
      key: 'certs/localhost-key.pem',
      cert: 'certs/localhost.pem'
    }
  },
  plugins: [
    vue(),
    vueJsx(),
    quasar({
      sassVariables: 'src/core/styles/theme.scss'
    })
  ],
  build: {
    sourcemap: true
  },
  resolve: {
    alias: {
      '@': fileURLToPath(new URL('./src', import.meta.url))
    }
  }
});
