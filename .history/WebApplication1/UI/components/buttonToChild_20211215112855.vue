<template>
     <nuxt-link
            v-if="image.HasChild"
            :to="`/${image.Category}`"
          >
            <button class="btn">More</button>
          </nuxt-link>
</template>