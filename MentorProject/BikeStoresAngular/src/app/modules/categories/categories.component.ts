import { Component, OnInit } from '@angular/core';
import { SecurityService } from 'src/app/services/security/security.service';
import { Category } from 'src/Models/category';
import { AppUserAuth } from 'src/Models/app-user-auth';
import { CategoriesService } from 'src/app/services/categories/categories.service';

import { Location } from '@angular/common';
import { Router } from '@angular/router';

@Component({
  selector: 'app-categories',
  templateUrl: './categories.component.html',
  styleUrls: ['./categories.component.css'],
  providers: [SecurityService, CategoriesService],
})
export class CategoriesComponent implements OnInit {

  /*Setting properties */
  securityObject: AppUserAuth;
  categories: Category[];
  category: Category  = new Category();
  originalCategory: Category = new Category();


  constructor(private securityService: SecurityService,
              private categoriesService: CategoriesService,
              private router: Router,
              private location: Location) {
      this.securityObject = securityService.securityObject;
   }

  ngOnInit() {
    // --Getting all actegories
    this.getCategories();
  }

  // -------------- CRUD METHODS -------------------
  private getCategories() {
    this.categoriesService.getCategories()
      .subscribe(resp => {this.categories = resp; return resp; },
      (error) => {
                    console.log(error);
                    alert('An error occurred, validate the log.');
                 }
    );
  }

  // --Getting a especific category
  private getCategory(id: number) {
    this.categoriesService.getCategory(id)
    .subscribe(resp => { this.category = resp;
                         this.originalCategory = Object.assign({}, this.category);
                       },
               (error) => { console.log(error); alert('An error occurred, validate the log.'); }
    );
  }

  private addCategory() {
    this.categoriesService.addCategory(this.originalCategory).subscribe(resp => { this.category = resp; },
      (error) => { console.log(error); alert('An error occurred, validate the log.'); },
      () => { this.initCategory(); });
  }

  private updateCategory(): void {
    // Update product
    this.categoriesService.updateCategory(this.originalCategory)
      .subscribe(category => { this.originalCategory = category; },
        (error) => {
                      console.log(error);
                      alert('An error occurred, validate the log');
                   },
        () => this.initCategory());
  }

  private deleteCategory(id: number) {
    if (confirm('Do you want to delete this category?')) {
      this.categoriesService.deleteCategory(id)
        .subscribe(() => this.categories = this.categories.filter(p => p.category_id !== id ),
        (error) => { console.log(error); alert('An error occurred, validate the log.'); }
      );
    }
  }

// -------------- END CRUD METHODS -------------------


// -------------- ACTION METHODS -------------------

  private editCategory(id: number) {
    this.initializeOrLoadCategory(id);
  }

  // Method to validate if the category will be added
  private saveData() {
    /*Validation for undefine value, null */
    if (!this.originalCategory.category_id) {
      if (this.originalCategory.category_name === '') {
        alert('La categoria no puede estar vacia');
      } else {
        this.addCategory();
      }
    } else {
      this.updateCategory();
    }
  }

  private dataSaved(): void {
    // Redirect back to list
    this.goBack();
  }

  private goBack(): void {
    this.location.back();
  }

  private initCategory(): void {
    // Add a new product
    this.category = new Category({
      category_name: '',
      category_id: 0
    });
    this.originalCategory = Object.assign({}, this.category);
    this.getCategories();
  }

  // Method for initialize components
  private initializeOrLoadCategory(id: number) {
    if (id === -1) {
      // Create new product object
      this.initCategory();
    } else {
      // Get a product from product service
      this.getCategory(id);
    }
  }

  // -------------- END ACTION METHODS -------------------

}
