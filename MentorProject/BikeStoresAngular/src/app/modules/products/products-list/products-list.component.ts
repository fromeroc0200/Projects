import { Component, OnInit, Input } from '@angular/core';
import { ProductsService } from 'src/app/services/products/products.service';
import { AppUserAuth } from 'src/Models/app-user-auth';
import { SecurityService } from 'src/app/services/security/security.service';
import { Product } from 'src/Models/product';
import { Router } from '@angular/router';

@Component({
  selector: 'app-products-list',
  templateUrl: './products-list.component.html',
  styleUrls: ['./products-list.component.css'],
  providers: [ProductsService, SecurityService]
})
export class ProductsListComponent implements OnInit {

  securityObject: AppUserAuth;
  products: Product[];

  constructor(private productsService: ProductsService, private securityService: SecurityService, private router: Router) {
    this.securityObject = securityService.securityObject;
   }

  ngOnInit() {
    console.log('addproducts: ' + this.securityObject.CanAddProduct);
    this.getProducts();
  }

  private getProducts() {
    this.productsService.getProducts().
      subscribe(resp => { this.products = resp; return resp; },
        (error) => { console.log(error); alert('An error occurred, validate the log.'); }
    );
  }

  private addProduct(): void {
    this.router.navigate(['/productDetail', -1]);
  }

  private deleteProduct(id: number): void {
      console.log('try delete ' + id);
      if (confirm('Do you want to delete this product?')) {
        this.productsService.deleteProduct(id).
          subscribe(() => this.products = this.products.filter(p => p.product_id !== id),
          (error) => { console.log(error); alert('An error occurred, validate the log.'); }
        );
      }

  }
}
