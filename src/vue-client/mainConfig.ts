import type { App, } from "vue";

interface Config {
  apiBaseUrl: string;
};

const config : Config = {
  apiBaseUrl: import.meta.env.VITE_SERVER_URL as string
}

export default {
  install: (Vue: App) => {
    Vue.config.globalProperties.$mainConfig = config;
  }
}

// Declaration for typescript intellisense.
declare module '@vue/runtime-core' {
  interface ComponentCustomProperties {
    $mainConfig: Config;
  }
}
