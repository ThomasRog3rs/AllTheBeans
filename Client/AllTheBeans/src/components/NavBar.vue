<template>
  <nav
    class="`fixed top-0 w-full z-50 transition-all duration-500 bg-white/80 backdrop-blur-xl border-b border-stone-200/50 shadow-lg"
  >
    <div class="container mx-auto px-6 py-4">
      <div class="flex items-center justify-between">
        <div class="flex items-center space-x-3">
          <div class="relative">
            <CoffeeIcon class="h-8 w-8 text-amber-700" />
            <div
              class="absolute -top-1 -right-1 w-3 h-3 bg-gradient-to-r from-amber-400 to-orange-500 rounded-full animate-pulse"
            />
          </div>
          <div>
            <h1
              class="text-2xl font-bold bg-gradient-to-r from-amber-800 to-orange-700 bg-clip-text text-transparent"
            >
              All The Beans
            </h1>
            <p class="text-xs text-stone-600 font-medium tracking-wide">BEAN THERE, DONE THAT</p>
          </div>
        </div>

        <div class="hidden md:flex items-center space-x-8">
          <a href="#" class="text-stone-700 hover:text-amber-700 font-medium transition-colors">
            Collection
          </a>
          <a href="#" class="text-stone-700 hover:text-amber-700 font-medium transition-colors">
            Origins
          </a>
          <a href="#" class="text-stone-700 hover:text-amber-700 font-medium transition-colors">
            About
          </a>
          <button class="relative p-2 text-stone-700 hover:text-amber-700 transition-colors">
            <ShoppingBagIcon class="h-5 w-5" />
            <span
              class="absolute -top-2 -right-2 bg-amber-500 text-white text-xs rounded-full h-5 w-5 flex items-center justify-center"
            >
              0
            </span>
          </button>
        </div>

        <button class="md:hidden p-2 text-stone-700 hover:text-amber-700 transition-colors">
          <MenuIcon class="h-6 w-6" />
        </button>
      </div>
    </div>
  </nav>
</template>

<script setup>
import {
  Coffee as CoffeeIcon,
  ShoppingBag as ShoppingBagIcon,
  Menu as MenuIcon,
} from 'lucide-vue-next'
</script>
