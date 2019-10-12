import { Component } from '@angular/core';
import { Order } from '../common/common-data.module';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html'
})
export class HomeComponent {
  public selectedOrder: Order;

  constructor() {
  }

  onSelectedOrder(order: Order) {
    this.selectedOrder = order;
  }
}
