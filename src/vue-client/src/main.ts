import { createApp } from 'vue'
import App from './App.vue'
import { Quasar } from 'quasar'
import router from './router/index'

import mainConfig from '../mainConfig'

import './assets/main.css'
import 'devextreme/dist/css/dx.light.css';
import { createPinia } from 'pinia';

import 'quasar/src/css/index.sass';

createApp(App)
  .use(mainConfig)
  .use(router)
  .use(createPinia())
  .use(Quasar, {
    plugins: {}
  })
  .mount('#app');
  
