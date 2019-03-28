import { Component, OnInit } from '@angular/core';
import { ProductsService } from 'src/app/services/products/products.service';
import { AppUserAuth } from 'src/Models/app-user-auth';
import { SecurityService } from 'src/app/services/security/security.service';
import { Product } from 'src/Models/product';

@Component({
  selector: 'app-products-list',
  templateUrl: './products-list.component.html',
  styleUrls: ['./products-list.component.css'],
  providers: [ProductsService, SecurityService]
})
export class ProductsListComponent implements OnInit {

  securityObject: AppUserAuth;
  products: Product[];

  constructor(private productsService: ProductsService, private securityService: SecurityService) {
    this.securityObject = securityService.securityObject;
   }

  ngOnInit() {
    this.getProducts();
  }

  private getProducts() {
    this.productsService.getProducts().subscribe(resp => { this.products = resp; return resp; });
  }

  private addProduct(id: number) {

  }

  private deleteProduct(id: number): void {
      console.log('try delete ' + id);
      if (confirm('Delete this product?')) {
        this.productsService.deleteProduct(id).subscribe(() => this.products = this.products.filter(p => p.product_id !== id));
      }

  }
}
