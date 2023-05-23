import { createApp } from 'vue';
import App from './App.vue';
import { Notify, Quasar } from 'quasar';
import router from './router/index';

import mainConfig from './main.config';
import { createPinia } from 'pinia';

import '@/core/styles/main.scss';

// Devextreme themes
import 'devextreme/dist/css/dx.light.css';

// Quasar themes
import 'quasar/src/css/index.sass';

import '@quasar/extras/roboto-font-latin-ext/roboto-font-latin-ext.css';

// Quasar iconspacks
import '@quasar/extras/material-icons/material-icons.css';
import '@quasar/extras/line-awesome/line-awesome.css';

createApp(App)
  .use(mainConfig)
  .use(router)
  .use(createPinia())
  .use(Quasar, {
    plugins: {
      Notify
    },
    config: {
      notify: {}
    }
  })
  .mount('#app');
