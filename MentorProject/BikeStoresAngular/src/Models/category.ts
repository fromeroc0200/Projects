export class Category {
  public constructor(init?: Partial<Category>) {
    Object.assign(this, init);
  }

  // tslint:disable-next-line:variable-name
  category_id: number;
  // tslint:disable-next-line:variable-name
  category_name: string;
}
