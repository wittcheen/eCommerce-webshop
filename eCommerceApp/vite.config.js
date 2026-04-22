import { defineConfig } from 'vite';
import { fileURLToPath, URL } from 'node:url';

import vue from '@vitejs/plugin-vue';
import vueDevTools from 'vite-plugin-vue-devtools';
import svgLoader from 'vite-svg-loader';
import viteCompression from 'vite-plugin-compression';
import tailwindcss from '@tailwindcss/vite';

// https://vite.dev/config/
export default defineConfig({
  plugins: [
    vue(), vueDevTools(),
    svgLoader(), tailwindcss(),
    viteCompression({filter: (file) => {
        return /\.(js|css|html|svg)$/i.test(file);
    }})
  ],
  resolve: {
    alias: {
      "@": fileURLToPath(new URL("./src", import.meta.url))
    },
  },
  build: {
    minify: "terser",
    terserOptions: {
      format: { comments: false }
    },
    rollupOptions: {
      output: {
        entryFileNames: "assets/[hash].js",
        chunkFileNames: "assets/[hash].js",
        assetFileNames: (assetInfo) => {
            const name = assetInfo.names?.[0] || "";
            if (/\.(woff2?|ttf|eot|svg)$/i.test(name)) {
                return "assets/fonts/[hash].[ext]";
            }
            return "assets/[hash].[ext]";
        }
      }
    }
  }
});
