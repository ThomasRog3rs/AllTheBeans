<template>
  <footer class="bg-gradient-to-r from-stone-900 to-amber-900 text-white py-16">
    <div class="container mx-auto px-6">
      <div class="grid md:grid-cols-4 gap-8">
        <div class="col-span-2">
          <div class="flex items-center space-x-3 mb-6">
            <CoffeeIcon class="h-8 w-8 text-amber-400" />
            <div>
              <h3 class="text-2xl font-bold">All The Beans</h3>
              <p class="text-amber-200 text-sm">BEAN THERE, DONE THAT</p>
            </div>
          </div>
          <p class="text-stone-300 leading-relaxed max-w-md">
            Crafting exceptional coffee experiences through carefully sourced beans, masterful
            roasting, and an unwavering commitment to quality.
          </p>
        </div>

        <div>
          <h4 class="font-semibold mb-4">Quick Links</h4>
          <div class="space-y-2">
            <a href="#" class="block text-stone-300 hover:text-amber-400 transition-colors"
              >Our Story</a
            >
            <a href="#" class="block text-stone-300 hover:text-amber-400 transition-colors"
              >Brewing Guide</a
            >
            <a href="#" class="block text-stone-300 hover:text-amber-400 transition-colors"
              >Wholesale</a
            >
            <a href="#" class="block text-stone-300 hover:text-amber-400 transition-colors"
              >Contact</a
            >
          </div>
        </div>

        <div>
          <h4 class="font-semibold mb-4">Follow Us</h4>
          <div class="space-y-2">
            <a href="#" class="block text-stone-300 hover:text-amber-400 transition-colors"
              >Instagram</a
            >
            <a href="#" class="block text-stone-300 hover:text-amber-400 transition-colors"
              >Twitter</a
            >
            <a href="#" class="block text-stone-300 hover:text-amber-400 transition-colors"
              >Facebook</a
            >
            <a href="#" class="block text-stone-300 hover:text-amber-400 transition-colors"
              >Newsletter</a
            >
          </div>
        </div>
      </div>

      <div class="border-t border-stone-700 mt-12 pt-8 text-center text-stone-400">
        <p>&copy; 2024 All The Beans.</p>
      </div>
    </div>
  </footer>
</template>

<script setup lang="ts">
import { Coffee as CoffeeIcon } from 'lucide-vue-next'
</script>
