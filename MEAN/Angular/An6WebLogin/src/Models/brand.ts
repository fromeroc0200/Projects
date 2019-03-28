export class Brand {
  public constructor(init?: Partial<Brand>) {
    Object.assign(this, init);
  }

  // tslint:disable-next-line:variable-name
  brand_id: number;
  // tslint:disable-next-line:variable-name
  brand_name: string;
}
