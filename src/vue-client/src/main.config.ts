import type { App } from 'vue';

interface Config {
  appTitle: string;
  apiBaseUrl: string;
}

export const mainConfig: Config = {
  appTitle: import.meta.env.VITE_APP_TITLE as string,
  apiBaseUrl: import.meta.env.VITE_SERVER_URL as string
};

export default {
  install: (Vue: App) => {
    Vue.config.globalProperties.$mainConfig = mainConfig;
  }
};

// Declaration for typescript intellisense.
declare module '@vue/runtime-core' {
  interface ComponentCustomProperties {
    $mainConfig: Config;
  }
}
