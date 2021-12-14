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
          src="assets/img/logo.svg"
          alt="Abstraktes Logo"
        />

        <a href="/">Menü</a>
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
            </div>

            <p class="image-caption">{{ image.Filename }}</p>
          </div>
          <span class="image-copy">Foto: blablabla</span>
          <div class="button inline-block align-bottom">
            <nuxt-link
              v-if="image.Category.length == 1"
              :to="`/${image.Category}`"
            >
              <button class="btn">More</button>
            </nuxt-link>
          </div>
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
    const response = await this.$axios.get(
      "http://bildarchivaarau.azurewebsites.net/api/photo",
      {}
    );

    this.images = response.data;
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
  z-index: 10;
  width: max-content;
  font-size: 0.875rem;
  font-family: "IBM Plex Mono";
  font-weight: 300;
  bottom: 1rem;
  display: block;
  position: absolute;
  right: 20rem; /* to center ? */
  opacity: 1;
  @apply content-center bg-transparent border border-black text-black hover:bg-black hover:text-white text-center py-2 px-4 rounded;
}

.btn:hover {
}

.image-text {
}
</style>