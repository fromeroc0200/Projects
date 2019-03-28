import { NgModule, Component } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

/*Import components*/
import { LoginComponent } from './modules/login/login.component';
import { ProductsListComponent } from './modules/products/products-list/products-list.component';
import { DashboardComponent } from './modules/dashboard/dashboard.component';
import { CategoriesComponent } from './modules/categories/categories.component';
import { ProductDetailComponent } from './modules/products/product-detail/product-detail.component';
import { AuthGuard } from './security/auth.guard';

const routes: Routes = [
  {
    path: 'dashboard',
    component: DashboardComponent
  },
  {
    path: 'login',
    component: LoginComponent
  },
  {
    path: 'products',
    component: ProductsListComponent
  },
  {
    path: 'productDetail/:id',
    component: ProductDetailComponent
  },
  {
    path: 'categories',
    component: CategoriesComponent
  },
  {
    path: '',
    redirectTo: 'dashboard',
    pathMatch: 'full'
  },
  {
    path: '**',
    component: DashboardComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
