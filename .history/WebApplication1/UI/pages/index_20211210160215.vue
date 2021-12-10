<template>
  <div class="images">
    <figure
      v-for="(image, index) in images"
      :key="index"
      :class="[`figure-${index}`]"
    >
      <div class="top-pages" v-if="image.Category.length == 1">
        <section class="w-full h-screen">
          <img
            class="object-cover w-full h-full"
            :src="image.Link"
            :alt="image.Name"
            :id="[`image-${image.PhotoId}`]"
            :class="[`category-${image.Category}`]"
          />
        </section>
        <figCaption :id="[`image-title-${image.PhotoId}`]" class="caption">
          {{ index }}{{ image.PhotoId }}</figCaption
        >
        <div :id="[`description-${image.PhotoId}`]" class="description">
          {{ image.Description }}
        </div>
      </div>
        <nuxt-link v-if="image.Category.length == 1" to="`/${image.Category}`">
          <button class="button-to-subpage">transition</button>
        </nuxt-link>
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


<style scoped>
.category-1 {
  border: 10px solid red;
}

.category-2 {
  border: 10px solid blue;
}

.button-to-subpage {
  border: 10px solid green;
}
</style>