<template>
  <div class="category">
    <figure
      v-for="(image, index) in images"
      :key="index"
      :class="[`figure-${index}`]"
    >
      <div
        class="top-pages"
        v-if="image.Category.endsWith($route.params.Category)"
      >
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

        <h3 class="image-text">{{ image.Description }}</h3>
        <p class="image-caption">{{ image.Filename }}</p>
        <span class="image-copy">Foto: blablabla</span>
      </div>
    </figure>
    <button class="border" @click="handleBack">Go back</button>
  </div>
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
      .then((res) => res.data.filter((e) => e.Category.length === 2));
  },
  methods: {
    handleBack() {
      this.$router.go(-1);
    },
  },
};
</script>