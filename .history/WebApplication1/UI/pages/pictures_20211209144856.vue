<template>
  <div class="images">
    <figure v-for="image, index in images" :key="index">
      <img :src="image.Link" :alt="image.Name" />
      <figCaption> {{index}}{{image.Name}}</figCaption>
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
      "http://bildarchivaarau.azurewebsites.net/api/photos", {
      params: {
          _limit: 100
      }
      })
    this.images = response.data;
  },
};
</script>
