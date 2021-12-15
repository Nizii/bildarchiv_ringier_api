<template>
     <nuxt-link
            v-if="image.Haschild"
            :to="`/${image.Category}`"
          >
            <button class="btn">More</button>
          </nuxt-link>
</template>