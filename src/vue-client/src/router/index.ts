import { fetchAuthDataMiddleware } from './middlewares/fetchAuthDataMiddleware';
import { createWebHistory, createRouter } from 'vue-router';
import routes from './router';
import { accessGuardMiddleware } from './middlewares/accessGuardMiddleware';

const router = createRouter({
  history: createWebHistory(),
  routes
});

router.beforeEach(fetchAuthDataMiddleware);
router.beforeEach(accessGuardMiddleware);

export default router;
