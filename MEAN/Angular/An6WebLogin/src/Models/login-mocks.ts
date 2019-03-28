/*Class with authentication  values*/
import { AppUserAuth } from './app-user-auth';

export const LOGIN_MOCKS: AppUserAuth[] = [
  {
    userName: 'fer',
    bearerToken: 'admin',
    isAuthenticated: true,
    canAccessProducts: true,
    canAddProduct: true,
    canSaveProduct: true,
    canAccessCategories: true,
    canAddCategory: false
  },
  {
    userName: 'BJones',
    bearerToken: 'sd9f923k3kdmcjkhd',
    isAuthenticated: true,
    canAccessProducts: false,
    canAddProduct: false,
    canSaveProduct: false,
    canAccessCategories: true,
    canAddCategory: true
  }
];
