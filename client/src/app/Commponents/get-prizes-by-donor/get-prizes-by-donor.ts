import { Component, EventEmitter, inject, Input, Output, SimpleChanges } from '@angular/core';
import { DonorService } from '../../../Services/donor-service';

@Component({
  selector: 'app-get-prizes-by-donor',
  imports: [],
  templateUrl: './get-prizes-by-donor.html',
  styleUrl: './get-prizes-by-donor.scss',
})
export class GetPrizesByDonor {
@Input() donorName:string="";
@Input() donorId:number=0;
@Output() closePrizes = new EventEmitter<void>();
 donorPrizes:any[]=[];
 private donorService = inject(DonorService);
  ngOnInit() {
    this.donorService.getPrizesByDonor(this.donorId).subscribe(data => {
      this.donorPrizes = data;
      console.log(this.donorPrizes);
      console.log(this.donorName);
    });
  }
  ngOnChanges(changes: SimpleChanges) {
    // בדיקה האם השם השתנה
    if (changes['donorName']) {
      this.donorName = changes['donorName'].currentValue;}
  }
  close(){
    this.closePrizes.emit();
  }
}
