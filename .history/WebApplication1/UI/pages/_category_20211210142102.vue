<template>
  <div class="hello">
    <h1>peace</h1>
    <h1>{{ images }}</h1>
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
  data() {
    return {
      images: [],
    };
  },
  async created() {
    const response = await this.$axios.get(
      "http://bildarchivaarau.azurewebsites.net/api/photo"
    );
    console.log(response.data.data)
    this.image = response.data.data.filter(e => {
      e.Category === this.$route.params.Category
      
    })
  },
  methods: {
    handleBack() {
      this.$router.go(-1);
    },
  },
};
</script>