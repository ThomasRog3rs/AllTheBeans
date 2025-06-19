<template>
  <div class="min-h-screen bg-gradient-to-br from-stone-50 via-amber-50 to-orange-50">
    <!-- Navigation -->
    <NavBar />

    <!-- Hero Section -->
    <Hero />

    <!-- Bean of the Day -->
    <BeanOfTheDay :beanOfTheDay="beanOfTheDay" />

    <!-- Single Bean Card Example -->
    <section class="py-16">
      <SingleBean :bean="beanOfTheDay" />
    </section>

    <!-- Footer -->
    <Footer />
  </div>
</template>

<script setup lang="ts">
import NavBar from './components/NavBar.vue'
import Hero from './components/Hero.vue'
import BeanOfTheDay from './components/BeanOfTheDay.vue'
import Footer from './components/Footer.vue'
import SingleBean from './components/SingleBean.vue'
import type { CoffeeResponseDTO } from '@/../api-client/models/CoffeeResponseDTO'
import { apiClient } from '@/apiClient';
import { onMounted } from 'vue'


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

async function fetchAllBeans() : Promise<CoffeeResponseDTO[]> {
  try {
    const response = await apiClient.apiCoffeeGetAllCoffeeGet();
    return response;
  } catch (error) {
    console.error('Error fetching beans:', error);
    return [];
  }
}

onMounted(async () => {
  const beans : CoffeeResponseDTO[] = await fetchAllBeans();
  console.log('Fetched beans:', beans);
});
</script>
