<template>
  <div class="images">
    <figure
      v-for="(image, index) in images"
      :key="index"
      :class="[`figure-${index}`]"
    >
      <img
        :src="image.Link"
        :alt="image.Name"
        :id="[`image-${image.PhotoId}`]"
        :class="image.Category"
      />
      <figCaption :id="[`image-title-${image.PhotoId}`]" class="caption">
        {{ index }}{{ image.PhotoId }}</figCaption
      >
      <div :id="[`description-${image.PhotoId}`]" class="description">
        {{ image.Description }}
      </div>
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
