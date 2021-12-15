<template>
  <main
    ref="scroll_container"
    @mousewheel="scrollX"
    class="flex flex-row scroll-container"
  >
    <div
      v-for="(image, index) in images"
      :key="index"
      :class="[`figure-${index}`]"
    >
      <nav>
        <img
          class="fixed top-0 left-0 right-0"
          src="UI/assets/img/logo.svg"
          alt="Abstraktes Logo"
        />
        <a href="/">Menü</a>
  <div>
    <button type="button" class="inline-flex justify-center w-full rounded-md border border-gray-300 shadow-sm px-4 py-2 bg-white text-sm font-medium text-gray-700 hover:bg-gray-50 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-offset-gray-100 focus:ring-indigo-500" id="menu-button" aria-expanded="true" aria-haspopup="true">
      Options
      <!-- Heroicon name: solid/chevron-down -->
      <svg class="-mr-1 ml-2 h-5 w-5" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 20 20" fill="currentColor" aria-hidden="true">
        <path fill-rule="evenodd" d="M5.293 7.293a1 1 0 011.414 0L10 10.586l3.293-3.293a1 1 0 111.414 1.414l-4 4a1 1 0 01-1.414 0l-4-4a1 1 0 010-1.414z" clip-rule="evenodd" />
      </svg>
    </button>
  </div>
          <div class="origin-top-right absolute right-0 mt-2 w-56 rounded-md shadow-lg bg-white ring-1 ring-black ring-opacity-5 focus:outline-none" role="menu" aria-orientation="vertical" aria-labelledby="menu-button" tabindex="-1">
    <div class="py-1" role="none">
      <!-- Active: "bg-gray-100 text-gray-900", Not Active: "text-gray-700" -->
      <a href="#" class="text-gray-700 block px-4 py-2 text-sm" role="menuitem" tabindex="-1" id="menu-item-0">Impressum</a>
      <a href="#" class="text-gray-700 block px-4 py-2 text-sm" role="menuitem" tabindex="-1" id="menu-item-1">Home</a>
    </div>
      </nav>

      <div class="top-pages" v-if="image.Category.length == 1">
        <section
          v-if="image.Size === 'large'"
          class="image text-center text-bottom"
        >
          <div
            class="image-bg"
            :style="{ backgroundImage: `url(${image.Link})` }"
          >
            <div class="image-aside">
              <h3 class="image-text">{{ image.Description }}</h3>
              <p class="image-caption">{{ image.Filename }}</p>
            </div>
          </div>
          <span class="image-copy">Foto: blablabla</span>
          <nuxt-link v-if="image.Category === 'b'" :to="`/${image.Category}`">
            <button class="btn">More</button>
          </nuxt-link>
        </section>

        <section
          v-if="image.Site === 'medium'"
          class="image text-right text-top"
        >
          <div class="image-container">
            <div class="image-section">
              <img :src="image.Link" :alt="image.Name" class="image-src" />
              <span class="image-copy">Foto: blablabla</span>
            </div>
          </div>
          <div class="image-aside">
            <h2 class="image-text">
              {{ image.Description }}
            </h2>
            <p class="image-caption">{{ image.Filename }}</p>
          </div>
          <nuxt-link
            v-if="image.Category === 'h' || image.Category === 'n'"
            :to="`/${image.Category}`"
          >
            <button class="btn">More</button>
          </nuxt-link>
        </section>

        <section class="image text-left text-top" v-if="image.Size === 'small'">
          <div class="image-aside">
            <h2 class="image-text">{{ image.Description }}</h2>
            <p class="image-caption">{{ image.Filename }}</p>
          </div>
          <div class="flex image-container">
            <div class="image-section">
              <img :src="image.Link" :alt="image.Name" class="image-src" />
              <span class="image-copy">Foto blabla</span>
            </div>
          </div>
        </section>
      </div>
    </div>
  </main>
</template>

<script>
export default {
  data() {
    return {
      images: [],
    };
  },

  async created() {
    this.images = await this.$axios
      .get("http://bildarchivaarau.azurewebsites.net/api/photo")
      .then((res) => res.data.filter((e) => e.Category.length === 1));
  },

  methods: {
    scrollX(e) {
      this.$refs["scroll_container"].scrollLeft += e.deltaY;
    },
  },

  beforeMount() {
    window.addEventListener("wheel", this.handleScroll);
  },

  beforeDestroy() {
    window.removeEventListener("wheel", this.handleScroll);
  },
};
</script>

<style>
.btn {
  @apply bg-transparent border border-black text-black hover:bg-black hover:text-white text-center py-2 px-4 rounded;
}
</style>