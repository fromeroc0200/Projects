import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
/*Import providers */
import { AuthGuard } from './security/auth.guard';
import { SecurityService } from './services/security/security.service';
import { MenuComponent } from './modules/menu/menu.component';
import { LoginComponent } from './modules/login/login.component';
import { DashboardComponent } from './modules/dashboard/dashboard.component';
import { ProductsListComponent } from './modules/products/products-list/products-list.component';
import { CategoriesComponent } from './modules/categories/categories.component';
import { ProductDetailComponent } from './modules/products/product-detail/product-detail.component';


@NgModule({
  declarations: [
    AppComponent,
    ProductsListComponent,
    MenuComponent,
    LoginComponent,
    DashboardComponent,
    CategoriesComponent,
    ProductDetailComponent,
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    AppRoutingModule,
  ],
  providers: [SecurityService, AuthGuard],
  bootstrap: [AppComponent]
})
export class AppModule { }
