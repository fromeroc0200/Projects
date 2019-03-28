import { Component, OnInit } from '@angular/core';
import { Product } from 'src/Models/product';
import { SecurityService } from 'src/app/services/security/security.service';
import { AppUserAuth } from 'src/Models/app-user-auth';
import { Location } from '@angular/common';
import { ProductsService } from 'src/app/services/products/products.service';
import { Category } from 'src/Models/category';
import { ActivatedRoute } from '@angular/router';
import { CategoriesService } from 'src/app/services/categories/categories.service';
import { Brand } from 'src/Models/brand';
import { BrandsService } from 'src/app/services/brands/brands.service';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.css'],
  providers: [ProductsService, CategoriesService, SecurityService],
})
export class ProductDetailComponent implements OnInit {

  securityObject: AppUserAuth;
  product: Product;
  brands: Brand[];
  categories: Category[];

  /*Set original product property*/
  originalProduct: Product;

  // tslint:disable-next-line:max-line-length
  constructor(private securityService: SecurityService,
              private productsService: ProductsService,
              private categoriesService: CategoriesService,
              private brandsService: BrandsService,
              private route: ActivatedRoute,
              private location: Location) {

    this.securityObject = securityService.securityObject;
  }

  ngOnInit() {
    // Get the passed in product id
    const id = +this.route.snapshot.paramMap.get('id');

    // Create or load a product
    this.createOrLoadProduct(id);
    this.getBrands();
    this.getCategories();
  }

  createOrLoadProduct(id: number) {
    if (id === -1) {
      // Create new product object
      this.initProduct();
    } else {
      // Get a product from product service
      this.productsService.getProduct(id)
        .subscribe(product => { this.product = product; this.originalProduct = Object.assign({}, this.product); },
        (error) => { console.log(error); alert('An error occurred, validate the log.'); }
      );
    }
  }

  private initProduct(): void {
    // Add a new product
    this.product = new Product({
        product_name: '',
        list_price: 0,
        model_year: 0
    });
    this.originalProduct = Object.assign({}, this.product);
  }

  saveData(): void {
    if (this.product.product_id) {
      // Update product
      this.productsService.updateProduct(this.product)
        .subscribe(product => { this.product = product; },
          (error) => { console.log(error); alert('An error occurred, validate the log.'); },
          () => this.dataSaved());
    } else {
      this.productsService.addProduct(this.product).subscribe(product => { this.product = product; },
          (error) => { console.log(error); alert('An error occurred, validate the log.'); },
          () => this.dataSaved()
      );
    }
  }

  getCategories() {
    this.categoriesService.getCategories().subscribe(
      resp => { this.categories = resp; return resp; },
      (error) => { console.log(error); alert('An error occurred, validate the log.'); }
    );
  }

  getBrands() {
    this.brandsService.getBrands().subscribe(
      resp => { this.brands = resp; return resp; },
      (error) => { console.log(error); alert('An error occurred, validate the log.'); }
    );
  }

  private dataSaved(): void {
    // Redirect back to list
    this.goBack();
  }

  goBack(): void {
    this.location.back();
  }

  cancel(): void {
    this.goBack();
  }
}
