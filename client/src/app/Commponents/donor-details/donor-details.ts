import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-donor-details',
  imports: [],
  templateUrl: './donor-details.html',
  styleUrl: './donor-details.scss',
})
export class DonorDetails {
@Input() donorDetails: any = null;
@Output() closeMe = new EventEmitter<void>();
onClose(){
  this.closeMe.emit();
}
}