<template>
  <div class="images">
    <figure v-for="(image, index) in images" :key="index" :class="[`figure-${image.photoId}`]">
      <img :src="image.Link" :alt="image.Name" />
      <!-- <figCaption :class="`image-title + ${index}`"> {{ index }}{{ image.PhotoId }}</figCaption> -->
      <div :class="[`description-${image.PhotoId}`]">{{ image.Description }}</div>
    </figure>
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
    const response = await this.$axios.get(
      "http://bildarchivaarau.azurewebsites.net/api/photo",
      {}
    );
    this.images = response.data;
  },
};
</script>
