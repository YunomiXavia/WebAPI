/** @type {import('tailwindcss').Config} */
export default {
  content: ["./index.html", "./src/**/*.{js,ts,jsx,tsx}"],
  theme: {
    extend: {
      backgroundImage: {
        "image-background":
          "url('https://www.wallpaperflare.com/static/291/501/254/fantasy-art-field-clouds-grass-wallpaper.jpg')",
      },
    },
  },
  plugins: [],
};
