<template>
  <div class="images">
    <figure v-for="image, index in images" :key="index">
      <img :src="image.thumbnailUrl" :alt="image.title" />
      <figCaption> {{index}}{{image.title}}</figCaption>
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
      "https://jsonplaceholder.typicode.com/albums/1/photos", {
      params: {
          _limit: 100
      }
      })
    this.images = response.data;
  },
};
</script>

