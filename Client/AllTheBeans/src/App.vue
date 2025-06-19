<template>
  <div class="min-h-screen bg-gradient-to-br from-stone-50 via-amber-50 to-orange-50">
    <!-- Navigation -->
    <NavBar />

    <!-- Hero Section -->
    <Hero />

    <!-- Bean of the Day -->
    <BeanOfTheDay :beanOfTheDay="beanOfTheDay" />
  </div>
</template>

<script setup lang="ts">
import NavBar from './components/NavBar.vue'
import Hero from './components/Hero.vue'
import BeanOfTheDay from './components/BeanOfTheDay.vue'
import type { CoffeeResponseDTO } from '@/../api-client/models/CoffeeResponseDTO'

const beanOfTheDay: CoffeeResponseDTO = {
  id: 1,
  isBeanOfTheDay: false,
  cost: 39.26,
  image: 'https://images.unsplash.com/photo-1672306319681-7b6d7ef349cf',
  colour: 'dark roast',
  name: 'TURNABOUT',
  description:
    'Ipsum cupidatat nisi do elit veniam Lorem magna. Ullamco qui exercitation fugiat pariatur sunt dolore Lorem magna magna pariatur minim. Officia amet incididunt ad proident. Dolore est irure ex fugiat. Voluptate sunt qui ut irure commodo excepteur enim labore incididunt quis duis. Velit anim amet tempor ut labore sint deserunt.\r\n',
  country: 'Peru',
}
</script>
