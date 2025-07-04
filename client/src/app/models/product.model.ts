export interface Product {
  productID: number;
  name: string;
  productNumber?: string;
  color?: string;
  standardCost: number;
  listPrice: number;
  size?: string;
  weight?: number;
  sellStartDate: Date;
  sellEndDate?: Date;
  discontinuedDate?: Date;
}