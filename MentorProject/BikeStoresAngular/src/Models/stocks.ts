export class Strock {
  public constructor(init?: Partial<Strock>) {
    Object.assign(this, init);
  }

  // tslint:disable-next-line:variable-name
  store_id: number;
  // tslint:disable-next-line:variable-name
  quantity: any;
}
