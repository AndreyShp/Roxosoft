import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-order-status',
  templateUrl: './order-status.component.html',
  styleUrls: ['./order-status.component.css']
})
export class OrderStatusComponent {
  @Input()
  public status: number;
  @Input()
  public needTitle: boolean;
}
