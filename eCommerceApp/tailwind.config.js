/** @type {import('tailwindcss').Config} */
import PrimeUI from 'tailwindcss-primeui';

export default {
  experimental: {
    optimizeUniversalDefaults: true
  },
  content: ["./index.html", "./src/**/*.{vue,js,ts}"],
  plugins: [PrimeUI]
};
