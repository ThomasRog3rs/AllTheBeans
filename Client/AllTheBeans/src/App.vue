<template>
  <div class="min-h-screen bg-gradient-to-br from-stone-50 via-amber-50 to-orange-50">
    <NavBar />
    <Hero />
    <BeanOfTheDay />

    <div class="container mx-auto px-6 py-12">
      <Filters />
      <section v-if="beansToDisplay.length > 0">
        <div class="grid sm:grid-cols-2 lg:grid-cols-3 xl:grid-cols-4 gap-8">
          <div
            v-for="(bean, index) in beansToDisplay"
            :key="bean.id"
            class="group bg-white/60 backdrop-blur-sm border-0 shadow-lg hover:shadow-2xl transition-all duration-500 overflow-hidden hover:-translate-y-2 rounded-lg"
          >
            <SingleBean :bean="bean" />
          </div>
        </div>
      </section>
      <div v-else class="mt-10 flex flex-col items-center justify-center">
        <div class="bg-gradient-to-r from-red-100 to-amber-100 border-2 border-red-300 shadow-2xl rounded-xl px-8 py-8 flex flex-col items-center">
          <svg class="w-14 h-14 text-red-400 mb-3" fill="none" stroke="currentColor" stroke-width="1.5" viewBox="0 0 24 24"><path stroke-linecap="round" stroke-linejoin="round" d="M12 8v4l3 3m6-3a9 9 0 11-18 0 9 9 0 0118 0z" /></svg>
          <h2 class="text-xl font-bold text-red-600 mb-1">No beans match your filters</h2>
          <p class="text-base text-red-700">Try broadening your selection to discover more delicious beans!</p>
        </div>
      </div>
    </div>
    <Footer />
  </div>
</template>

<script setup lang="ts">
import NavBar from './components/NavBar.vue'
import Hero from './components/Hero.vue'
import BeanOfTheDay from './components/BeanOfTheDay.vue'
import Footer from './components/Footer.vue'
import SingleBean from './components/SingleBean.vue'
import Filters from './components/Filters.vue'
import { useCoffeeStore } from '@/stores/coffee.store'
import { storeToRefs } from 'pinia'
import { onMounted } from 'vue'

const coffeeStore = useCoffeeStore();
const { beansToDisplay } = storeToRefs(coffeeStore);

onMounted(async () => {
  coffeeStore.beanOfTheDay = await coffeeStore.getBeanOfTheDay();
  if (coffeeStore.allBeans.length === 0) {
    await coffeeStore.fetchAllBeans();
  }
});
</script>
