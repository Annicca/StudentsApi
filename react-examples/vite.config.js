import { defineConfig } from 'vite';
import react from '@vitejs/plugin-react';

// Учебный API работает и в dev, и в preview. Отдельный backend не нужен.
function productsApi() {
  const middleware = (req, res, next) => {
    if (req.url?.split('?')[0] !== '/api/products') return next();
    res.setHeader('Content-Type', 'application/json; charset=utf-8');
    res.end(JSON.stringify([{ id: 1, name: 'Тетрадь' }, { id: 2, name: 'Ручка' }]));
  };
  return {
    name: 'teaching-products-api',
    configureServer(server) { server.middlewares.use(middleware); },
    configurePreviewServer(server) { server.middlewares.use(middleware); }
  };
}
export default defineConfig({ plugins: [react(), productsApi()] });
