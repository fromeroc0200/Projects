import { Category } from './category';
import { Brand } from './brand';
import { Strock } from './stocks';


export class Product {
  public constructor(init?: Partial<Product>) {
    Object.assign(this, init);
  }


  product_id: number;

  product_name: string;

  brand_id: number;
  // tslint:disable-next-line:variable-name
  category_id: number;
  // tslint:disable-next-line:variable-name
  list_price: number;
  // tslint:disable-next-line:variable-name
  model_year: number;

  categories: Category;
  brands: Brand;
  stocks: Strock[];
}
