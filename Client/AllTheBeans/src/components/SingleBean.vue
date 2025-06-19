<template>
  <div
    class="group bg-white/60 backdrop-blur-sm border-0 shadow-lg hover:shadow-2xl transition-all duration-500 overflow-hidden hover:-translate-y-2 rounded-lg"
  >
    <div class="relative h-64 overflow-hidden">
      <img
        :src="bean.image || '/placeholder.svg'"
        :alt="bean.name || 'Coffee Bean'"
        class="w-full h-full object-cover group-hover:scale-110 transition-transform duration-700"
      />
      <div
        class="absolute inset-0 bg-gradient-to-t from-black/60 via-transparent to-transparent opacity-0 group-hover:opacity-100 transition-opacity duration-300"
      />
      <div
        v-if="bean.isBeanOfTheDay"
        class="absolute top-4 left-4 bg-gradient-to-r from-amber-500 to-orange-500 text-white px-3 py-1 rounded-full text-sm font-medium"
      >
        Featured
      </div>
    </div>
    <div class="p-6">
      <h3 class="text-xl font-bold text-stone-900 mb-2">{{ bean.name }}</h3>
      <div class="flex items-center space-x-4 mb-3 text-sm">
        <div class="flex items-center space-x-1 text-stone-600">
          <MapPinIcon class="h-3 w-3" />
          <span>{{ bean.country }}</span>
        </div>
        <div class="flex items-center space-x-1 text-stone-600">
          <FlameIcon class="h-3 w-3" />
          <span class="capitalize">{{ bean.colour }}</span>
        </div>
      </div>
      <p class="text-stone-600 text-sm mb-4 line-clamp-2 leading-relaxed">{{ bean.description }}</p>
      <div class="flex items-center justify-between">
        <span
          class="text-2xl font-bold bg-gradient-to-r from-amber-600 to-orange-600 bg-clip-text text-transparent"
        >
          {{ bean.cost?.toLocaleString('en-GB', { style: 'currency', currency: 'GBP' }) }}
        </span>
        <button
          class="bg-gradient-to-r from-amber-600 to-orange-600 hover:from-amber-700 hover:to-orange-700 text-white rounded-full px-6 py-2 text-sm font-medium transition-all"
        >
          Add to Cart
        </button>
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import { MapPin as MapPinIcon, Flame as FlameIcon } from 'lucide-vue-next'
import type { CoffeeResponseDTO } from '@/../api-client/models/CoffeeResponseDTO'

defineProps<{
  bean: CoffeeResponseDTO
}>()
</script>
