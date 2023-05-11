import { createApp } from 'vue'
import App from './App.vue'
import { Quasar } from 'quasar'
import router from './router/index'

import mainConfig from '../mainConfig'
import { createPinia } from 'pinia';

// Main styles
import './assets/main.css'

// Devextreme themes
import 'devextreme/dist/css/dx.light.css';

// Quasar themes
import 'quasar/src/css/index.sass';

// Quasar iconspacks
import '@quasar/extras/material-icons/material-icons.css'

createApp(App)
  .use(mainConfig)
  .use(router)
  .use(createPinia())
  .use(Quasar, {
    plugins: {}
  })
  .mount('#app');
  
