/*Class with authentication  values*/
import { AppUserAuth } from './app-user-auth';

export const LOGIN_MOCKS: AppUserAuth[] = [
  {
    UserName: 'fer',
    BearerToken: 'admin',
    IsAuthenticated: true,
    CanAccessProducts: true,
    CanAddProduct: true,
    CanSaveProduct: true,
    CanAccessCategory: true,
    CanAddCategory: false
  },
  {
    UserName: 'BJones',
    BearerToken: 'sd9f923k3kdmcjkhd',
    IsAuthenticated: true,
    CanAccessProducts: false,
    CanAddProduct: false,
    CanSaveProduct: false,
    CanAccessCategory: true,
    CanAddCategory: true
  }
];
