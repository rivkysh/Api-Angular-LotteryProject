import { Component, EventEmitter, inject, Input, Output, output } from '@angular/core';
import { PrizeServise } from '../../../Services/prize-servise';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';

@Component({
  selector: 'app-update-prize',
  imports: [ReactiveFormsModule],
  templateUrl: './update-prize.html',
  styleUrl: './update-prize.scss',
})
export class UpdatePrize {
 @Input() prizeToEdit: any = null;
 @Input() id: number = 0;
@Output() closeMe = new EventEmitter<void>();
public PrizeService = inject(PrizeServise)
prizeform = new FormGroup({
  name: new FormControl('', Validators.required),
  description: new FormControl('', Validators.required),
  imgUrl: new FormControl('', Validators.required),
  price: new FormControl('', Validators.required),
  donorId: new FormControl('', Validators.required),
  categoryId: new FormControl('', Validators.required),
})
ngOnInit() {
    if (this.prizeToEdit) {
      this.prizeform.patchValue(this.prizeToEdit);
    }
  }
onSubmit(){
 
    if (this.prizeform.valid) {
      console.log(this.prizeform); 
      this.PrizeService.updatePrize(this.id, this.prizeform.value).subscribe(response => {
        alert('Prize updated successfully');
        this.closeMe.emit();
      }, error => {
        alert('Error updating prize');
      });
    }
}
close(){
  this.closeMe.emit();
}
}
