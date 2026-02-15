import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-get-purchases',
  imports: [CommonModule],
  templateUrl: './get-purchases.html',
  styleUrl: './get-purchases.scss',
})
export class GetPurchases {
  @Input() purchasers: any[] = [];
  @Output() closeMe = new EventEmitter<void>();
  closeDialog() {
    this.closeMe.emit();
  }
  ngOnInit() {

  }
}
