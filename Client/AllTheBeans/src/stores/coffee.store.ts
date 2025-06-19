import { defineStore } from 'pinia'
import type { CoffeeResponseDTO } from '@/../api-client/models/CoffeeResponseDTO'
import { apiClient } from '@/apiClient';
import { computed, ref } from 'vue';

export const useCoffeeStore = defineStore('coffeeStore', () => {
  const beanOfTheDay = ref<CoffeeResponseDTO | null>(null);
  const allBeans = ref<CoffeeResponseDTO[]>([]);
  const filteredBeans = ref<CoffeeResponseDTO[]>([]);
  const activeFilters = ref<{ [key: string]: any }>({});

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

  async function fetchAllBeans() {
    const beans = await getAllCoffee();
    allBeans.value = beans;
    applyFilters();
  }

  function setFilters(filters: { [key: string]: any }) {
    activeFilters.value = filters;
    applyFilters();
  }

  function applyFilters() {
    const filters = activeFilters.value;

    if (!filters || Object.values(filters).every(v => !v || v.length === 0)) {
      filteredBeans.value = allBeans.value;
      return;
    }

    filteredBeans.value = allBeans.value.filter(bean => {
      let matches = true;

      if (filters.country && filters.country.length) {
        matches = matches && filters.country.includes(bean.country);
      }

      if (filters.colour && filters.colour.length) {
        matches = matches && filters.colour.includes(bean.colour);
      }
      return matches;
    });
  }

  const beansToDisplay = computed(() => {
    return filteredBeans.value;
  });

  const noBeansToDisplay = computed(() => beansToDisplay.value.length === 0);

  return {
    getAllCoffee,
    getBeanOfTheDay,
    beanOfTheDay,
    allBeans,
    filteredBeans,
    activeFilters,
    fetchAllBeans,
    setFilters,
    beansToDisplay,
    noBeansToDisplay,
  }
})
