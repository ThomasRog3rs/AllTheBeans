<template>
  <section v-if="beanOfTheDay" class="py-16 bg-gradient-to-r from-amber-100 to-orange-100">
    <div class="container mx-auto px-6">
      <div class="text-center mb-12">
        <div
          class="inline-block bg-gradient-to-r from-amber-500 to-orange-500 text-white px-4 py-2 text-sm font-medium mb-4 rounded-full"
        >
          TODAY'S SELECTION
        </div>
        <h2 class="text-4xl font-bold text-stone-900 mb-4">Bean of the Day</h2>
        <p class="text-stone-600 max-w-2xl mx-auto">
          Handpicked by our master roasters for its exceptional character and unparalleled quality.
        </p>
      </div>

      <div
        class="max-w-5xl mx-auto bg-white/60 backdrop-blur-sm border-0 shadow-2xl overflow-hidden rounded-lg"
      >
        <div class="grid md:grid-cols-2">
          <div class="relative h-96 md:h-full">
            <img
              :src="beanOfTheDay.image || '/placeholder.svg'"
              :alt="beanOfTheDay.name || 'Bean of the Day'"
              class="w-full h-full object-cover"
            />
            <div class="absolute inset-0 bg-gradient-to-t from-black/50 to-transparent" />
            <div
              class="absolute top-6 left-6 bg-amber-500 text-white px-3 py-1 rounded-full text-sm font-medium"
            >
              Featured Today
            </div>
          </div>

          <div class="p-12 flex flex-col justify-center">
            <h3 class="text-3xl font-bold text-stone-900 mb-4">{{ beanOfTheDay.name }}</h3>

            <div class="flex items-center space-x-6 mb-6">
              <div class="flex items-center space-x-2">
                <MapPinIcon class="h-5 w-5 text-amber-600" />
                <span class="text-stone-700 font-medium">{{ beanOfTheDay.country }}</span>
              </div>
              <div class="flex items-center space-x-2">
                <FlameIcon class="h-5 w-5 text-orange-600" />
                <span class="text-stone-700 font-medium capitalize">{{ beanOfTheDay.colour }}</span>
              </div>
            </div>

            <p class="text-stone-600 mb-8 leading-relaxed">{{ beanOfTheDay.description }}</p>

            <div class="flex items-center justify-between">
              <span
                class="text-4xl font-bold bg-gradient-to-r from-amber-600 to-orange-600 bg-clip-text text-transparent"
              >
                {{
                  beanOfTheDay.cost?.toLocaleString('en-GB', {
                    style: 'currency',
                    currency: 'GBP',
                  })
                }}
              </span>
            </div>
          </div>
        </div>
      </div>
    </div>
  </section>
</template>

<script setup lang="ts">
import type { CoffeeResponseDTO } from '@/../api-client/models/CoffeeResponseDTO'
import { MapPin as MapPinIcon, Flame as FlameIcon } from 'lucide-vue-next'

defineProps<{
  beanOfTheDay: CoffeeResponseDTO | null
}>()
</script>
