import type { App, } from "vue";

interface Config {
  apiBaseUrl: string;
};

export const mainConfig : Config = {
  apiBaseUrl: import.meta.env.VITE_SERVER_URL as string
}

export default {
  install: (Vue: App) => {
    Vue.config.globalProperties.$mainConfig = mainConfig;
  }
}

// Declaration for typescript intellisense.
declare module '@vue/runtime-core' {
  interface ComponentCustomProperties {
    $mainConfig: Config;
  }
}
