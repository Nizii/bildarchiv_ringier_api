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
      <navigation></navigation>
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
              <h3 class="image-text">{{ image.Filetext }}</h3>
              <p class="image-caption">{{ image.Copyright }}</p>
            </div>
          </div>
          <!-- <span class="image-copy">Foto: blablabla</span> -->
                   <buttonToChild></buttonToChild>

        </section>

        <section
          v-if="image.Site === 'medium'"
          class="image text-right text-top"
        >
          <div class="image-container">
            <div class="image-section">
              <img :src="image.Link" :alt="image.Name" class="image-src" />
              <!-- <span class="image-copy">Foto: blablabla</span> -->
            </div>
          </div>
          <div class="image-aside">
            <h2 class="image-text">
              {{ image.Filetext }}
            </h2>
            <p class="image-caption">{{ image.Copyright }}</p>
          </div>
          <buttonToChild></buttonToChild>
        </section>

        <section class="image text-left text-top" v-if="image.Size === 'small'">
          <div class="image-aside">
            <h2 class="image-text">{{ image.Filetext }}</h2>
            <p class="image-caption">{{ image.Copyright }}</p>
          </div>
          <div class="flex image-container">
            <div class="image-section">
              <img :src="image.Link" :alt="image.Name" class="image-src" />
              <!-- <span class="image-copy">Foto blabla</span> -->
            </div>
          </div>
          <buttonToChild></buttonToChild>
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