import {Component, Inject, Input} from '@angular/core';
import { HttpClient } from '@angular/common/http';
import * as common from '../common/common-data.module';

@Component({
  selector: 'app-order-details-data',
  templateUrl: './order-details-data.component.html'
})
export class OrderDetailsDataComponent {
  public order: common.Order;
  public summary: OrderSummary;

  _http: HttpClient;
  _baseUrl: string;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this._http = http;
    this._baseUrl = baseUrl;
  }

  @Input('orderId')
  set orderId(orderId: number) {
    this.order = null;
    this.summary = null;
    this._http.get<common.Order>(this._baseUrl + 'api/orders/' + orderId).subscribe( result => {
      this.summary = new OrderSummary();

      for (let product of result.products) {
        this.summary.quantity += product.quantity;
        this.summary.price += product.price;
        this.summary.totalPrice += (product.price * product.quantity);
      }

      this.order = result;
    }, error => console.error(error));
  }
}

/* Класс содержащий общую информацию по заказу */
export class OrderSummary {
  //Общее кол-во товара
  public quantity : number = 0;
  //Общая стоимость товара за единицу каждой(без учета кол-ва)
  public price: number = 0;
  //Общая стоимость товара с учетом кол-ва
  public totalPrice: number = 0;
}
