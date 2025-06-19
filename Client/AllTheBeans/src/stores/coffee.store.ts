import { defineStore } from 'pinia'
import type { CoffeeResponseDTO } from '@/../api-client/models/CoffeeResponseDTO'
import { apiClient } from '@/apiClient';
import { ref } from 'vue';

export const useCoffeeStore = defineStore('coffeeStore', () => {
  const beanOfTheDay = ref<CoffeeResponseDTO | null>(null);

  async function getAllCoffee (): Promise<CoffeeResponseDTO[]> {
    try {
      const response = await apiClient.apiCoffeeGetAllCoffeeGet();
      return response;
    } catch (error) {
      console.error('Error fetching beans:', error);
      return [];
    }
  }

  async function getBeanOfTheDay (): Promise<CoffeeResponseDTO | null> {
    try {
      const response = await apiClient.apiCoffeeBeanOfTheDayGet();
      return response;
    } catch (error) {
      console.error('Error fetching bean of the day:', error);
      return null;
    }
  }

  return { getAllCoffee, getBeanOfTheDay, beanOfTheDay }
})
