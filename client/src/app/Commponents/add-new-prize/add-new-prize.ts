import { Component, EventEmitter, inject, Output } from '@angular/core';
import { FormBuilder, FormGroup, FormControl, Validators, ReactiveFormsModule } from '@angular/forms';
import { PrizeServise } from '../../../Services/prize-servise';

@Component({
  selector: 'app-add-new-prize',
  imports: [ReactiveFormsModule],
  templateUrl: './add-new-prize.html',
  styleUrl: './add-new-prize.scss',
})
export class AddNewPrize {
@Output() closeMe = new EventEmitter<void>();
public PrizeService = inject(PrizeServise)
prizeform = new FormGroup({
  name: new FormControl('', Validators.required),
  description: new FormControl(''),
  imgUrl: new FormControl('', Validators.required),
  price: new FormControl('', Validators.required),
  donorId: new FormControl('', Validators.required),
  categoryId: new FormControl(''),
})
onSubmit(){
 
    if (this.prizeform.valid) {
      this.PrizeService.addPrize(this.prizeform.value).subscribe(response => {
        alert('Prize added successfully');
        this.closeMe.emit();
      }, error => {
        alert('Error adding prize');
      });
    }
}
close(){
 
  this.closeMe.emit();
}
}