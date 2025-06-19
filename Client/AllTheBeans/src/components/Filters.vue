<template>
  <!-- Filters Panel -->
  <div class="mb-8 bg-white/80 shadow-xl border border-stone-200 rounded-2xl p-8">
    <div class="grid md:grid-cols-2 gap-8">
      <div>
        <h3 class="font-semibold text-stone-900 mb-4 text-lg flex items-center gap-2">
          <svg class="w-5 h-5 text-amber-600" fill="currentColor" viewBox="0 0 20 20"><path d="M10 2a8 8 0 100 16 8 8 0 000-16zm1 12.93V15a1 1 0 11-2 0v-.07A6.002 6.002 0 014 10a6 6 0 1112 0 6.002 6.002 0 01-5 5.93z"/></svg>
          Origin
        </h3>
        <div class="flex flex-wrap gap-3">
          <label v-for="origin in origins" :key="origin" class="flex items-center gap-2 bg-amber-50 border border-amber-200 rounded-lg px-3 py-1 cursor-pointer hover:bg-amber-100 transition">
            <input
              type="checkbox"
              :id="`origin-${origin}`"
              :checked="selectedOrigins.includes(origin)"
              @change="event => handleOriginChange(origin, event)"
              class="accent-amber-600 focus:ring-amber-500"
            />
            <span class="text-sm font-medium text-stone-700">{{ origin }}</span>
          </label>
        </div>
      </div>

      <div>
        <h3 class="font-semibold text-stone-900 mb-4 text-lg flex items-center gap-2">
          <svg class="w-5 h-5 text-amber-600" fill="currentColor" viewBox="0 0 20 20"><circle cx="10" cy="10" r="8"/><circle cx="10" cy="10" r="4" fill="white"/></svg>
          Colour
        </h3>
        <div class="flex flex-wrap gap-3">
          <label v-for="colour in colours" :key="colour" class="flex items-center gap-2 bg-orange-50 border border-orange-200 rounded-lg px-3 py-1 cursor-pointer hover:bg-orange-100 transition">
            <input
              type="checkbox"
              :id="`colour-${colour}`"
              :checked="selectedColours.includes(colour)"
              @change="event => handleColourChange(colour, event)"
              class="accent-orange-500 focus:ring-orange-500"
            />
            <span class="text-sm font-medium text-stone-700 capitalize">{{ colour }}</span>
          </label>
        </div>
      </div>
    </div>

    <div class="flex justify-end mt-8">
      <button
        @click="clearAllFilters"
        class="bg-gradient-to-r from-amber-400 to-orange-400 text-white font-semibold px-6 py-2 rounded-lg shadow hover:from-amber-500 hover:to-orange-500 transition"
      >
        Clear All Filters
      </button>
    </div>
  </div>
</template>

<script setup lang="ts">
import { computed, ref, watch, onMounted } from 'vue';
import { useCoffeeStore } from '@/stores/coffee.store';

const coffeeStore = useCoffeeStore();

onMounted(() => {
  if (coffeeStore.allBeans.length === 0) {
    coffeeStore.fetchAllBeans();
  }
});

const origins = computed(() => {
  const set = new Set<string>();
  coffeeStore.allBeans.forEach(bean => {
    if (bean.country) set.add(bean.country);
  });
  return Array.from(set);
});

const colours = computed(() => {
  const set = new Set<string>();
  coffeeStore.allBeans.forEach(bean => {
    if (bean.colour) set.add(bean.colour);
  });
  return Array.from(set);
});

const selectedOrigins = computed({
  get: () => coffeeStore.activeFilters.country || [],
  set: val => coffeeStore.setFilters({ ...coffeeStore.activeFilters, country: val })
});
const selectedColours = computed({
  get: () => coffeeStore.activeFilters.colour || [],
  set: val => coffeeStore.setFilters({ ...coffeeStore.activeFilters, colour: val })
});

function handleOriginChange(origin: string, event: Event) {
  const checked = (event.target as HTMLInputElement)?.checked;
  const next = checked
    ? [...selectedOrigins.value, origin]
    : selectedOrigins.value.filter((o: string) => o !== origin);
  selectedOrigins.value = next;
}

function handleColourChange(colour: string, event: Event) {
  const checked = (event.target as HTMLInputElement)?.checked;
  const next = checked
    ? [...selectedColours.value, colour]
    : selectedColours.value.filter((c: string) => c !== colour);
  selectedColours.value = next;
}

function clearAllFilters() {
  coffeeStore.setFilters({});
}
</script>