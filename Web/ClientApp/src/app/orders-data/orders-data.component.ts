import { Component, Inject, Output, EventEmitter } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Order } from '../common/common-data.module';

@Component({
  selector: 'app-orders-data',
  templateUrl: './orders-data.component.html',
  styleUrls: ['./orders-data.component.css']
})
export class OrdersDataComponent {
  public orders: Order[];
  public selectedOrder: Order = null;
  @Output() onSelectOrder: EventEmitter<Order> = new EventEmitter();

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Order[]>(baseUrl + 'api/orders').subscribe(result => {
      this.orders = result;
    }, error => console.error(error));
  }

  selectOrder(order: Order) : void {
    this.selectedOrder = order;
    this.onSelectOrder.emit(order);
  }
}
