import {Component, Inject, Input} from '@angular/core';
import { HttpClient } from '@angular/common/http';
import * as common from '../common/common-data.module';

@Component({
  selector: 'app-order-details-data',
  templateUrl: './order-details-data.component.html'
})
export class OrderDetailsDataComponent {
  public order: common.Order;

  _http: HttpClient;
  _baseUrl: string;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this._http = http;
    this._baseUrl = baseUrl;
  }

  @Input('orderId')
  set orderId(orderId: number) {
    this.order = null;
    this._http.get<common.Order>(this._baseUrl + 'api/orders/' + orderId).subscribe(result => {
      this.order = result;
    }, error => console.error(error));

  }
}
