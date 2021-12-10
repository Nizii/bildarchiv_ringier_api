<template>
  <div class="hello">
    <h1>peace</h1>
    <h1>{{ filteredImages }}</h1>
  </div>
  <!-- <div class="category">
    <button class="border" @click="handleBack">Go back in history</button>
    <figure
      v-for="(image, index) in images"
      :key="index"
      :class="[`figure-${index}`]"
    >
      <div class="top-pages" v-if="image.Category == 2">
        <section>
          <img
            :src="image.Link"
            :alt="image.Name"
            :id="[`image-${image.PhotoId}`]"
            :class="[`category--${image.Category}`]"
          />
        </section>
        <figCaption :id="[`image-title-${image.PhotoId}`]" class="caption">
          {{ index }}{{ image.PhotoId }}</figCaption
        >
        <div :id="[`description-${image.PhotoId}`]" class="description">
          {{ image.Description }}
        </div>
      </div>
    </figure>
  </div> -->
</template>

<script>
export default {
  async asyncData({ params, $axios }) {
    const images = await $axios.$get(
      `http://bildarchivaarau.azurewebsites.net/api/photo`
    );
    const filteredImages = images.filter((e) => {
      e.Category === params.Category;
    });
    return filteredImages;
  },
  methods: {
    handleBack() {
      this.$router.go(-1);
    },
  },
};
</script>