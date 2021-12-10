<template>
  <div class="page-wrapper">
    <h2>Index</h2>
    <div class="grid-list">
      <figure v-for="(image, index) in images" :key="index" :class="image.size">
        <img :src="`/img/${image.path}`" alt="" />
      </figure>
    </div>
  </div>
</template>

<script>
const images = require("~/assets/data/images.json");
export default {
  data() {
    return {
      images: images,
    };
  },
};
</script>

<style >
figure.small {
  border: 10px solid red;
  width: 100%;
  max-width: 400px;
}

figure.medium {
  border: 10px solid blue;
  width: 100%;
  max-width: 600px;
}

figure.large {
  border: 10px solid lime;
  width: 100%;
  max-width: 800px;
}
</style>