import { Configuration, BaseAPI } from '@/../api-client/runtime';
import {CoffeeApi} from '@/../api-client/apis/CoffeeApi';

const basePath =
  import.meta.env.VITE_API_BASE_PATH || 'http://localhost';

const config = new Configuration({ basePath });

export const apiClient = new CoffeeApi(config);