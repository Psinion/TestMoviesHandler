import { fetchAuthDataMiddleware } from './middlewares/fetchAuthDataMiddleware';
import { createWebHistory, createRouter } from 'vue-router';
import routes from './router';
import { accessGuardMiddleware } from './middlewares/accessGuardMiddleware';
import { mainConfig } from '@/main.config';

const router = createRouter({
  history: createWebHistory(),
  routes
});

router.beforeEach(fetchAuthDataMiddleware);
router.beforeEach(accessGuardMiddleware);
router.beforeEach(to => {
  const title = `${to.meta['title']} | ${mainConfig.appTitle}`;
  document.title = title as string;
});

export default router;
