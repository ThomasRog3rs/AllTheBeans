<template>
  <div class="min-h-screen bg-gradient-to-br from-stone-50 via-amber-50 to-orange-50">
    <!-- Navigation -->
    <NavBar />

    <!-- Hero Section -->
    <Hero />

    <!-- Bean of the Day -->
    <BeanOfTheDay />

    <!-- Single Bean Card Example -->
    <section class="mx-auto px-12 py-12" v-if="beans.length > 0">
      <div class="grid sm:grid-cols-2 lg:grid-cols-3 xl:grid-cols-4 gap-8 p-12">
        <div
          v-for="(bean, index) in beans"
          :key="bean.id"
          class="group bg-white/60 backdrop-blur-sm border-0 shadow-lg hover:shadow-2xl transition-all duration-500 overflow-hidden hover:-translate-y-2 rounded-lg"
        >
          <SingleBean :bean="bean" />
        </div>
      </div>
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
import { onMounted, ref } from 'vue'
import { useCoffeeStore } from '@/stores/coffee.store'

const coffeeStore = useCoffeeStore();
const beans = ref<CoffeeResponseDTO[]>([]);
onMounted(async () => {
  coffeeStore.beanOfTheDay = await coffeeStore.getBeanOfTheDay();

  beans.value = await coffeeStore.getAllCoffee();
  console.log('Fetched beans:', beans.value);
});
</script>
