import { createApp } from 'vue'
import App from './App.vue'

import mainConfig from '../mainConfig'

import './assets/main.css'
import 'devextreme/dist/css/dx.light.css';
import { createPinia } from 'pinia';

createApp(App)
  .use(mainConfig)
  .use(createPinia())
  .mount('#app');
  
