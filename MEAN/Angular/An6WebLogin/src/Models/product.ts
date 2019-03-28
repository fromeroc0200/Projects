import { Category } from './category';
import { Brand } from './brand';


export class Product {
  public constructor(init?: Partial<Product>) {
    Object.assign(this, init);
  }

  product_id: number;
  product_name: string;
  brand_id: number;
  category_id: number;
  list_price: number;
  model_year: number;
  categories: Category;
  brands: Brand;
}
