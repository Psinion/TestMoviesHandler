import { createApp } from 'vue'
import App from './App.vue'

import mainConfig from '../mainConfig'

import './assets/main.css'
import 'devextreme/dist/css/dx.light.css';

createApp(App)
  .use(mainConfig)
  .mount('#app');
  
