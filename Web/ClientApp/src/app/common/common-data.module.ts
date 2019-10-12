/* общие данные для нескольких модулей и компонентов */

export interface Product {
  id: number;
  name: string
}

export interface OrderProduct {
  id: number;
  product: Product;
  quantity: number;
  price: number;
}

export interface Order {
  id: number;
  creationTime: Date;
  status: number;
  products: OrderProduct[];
  temperatureF: number;
  summary: string;
}
