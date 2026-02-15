import { Component, EventEmitter, inject, Input, Output } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { DonorService } from '../../../Services/donor-service';

@Component({
  selector: 'app-edit-donor',
  imports: [ReactiveFormsModule],
  templateUrl: './edit-donor.html',
  styleUrl: './edit-donor.scss',
})
export class EditDonor {
@Input() thisId:number=0;
@Input() thisDonor:any=null;
@Output() closeEdit = new EventEmitter<void>();
private DonorService = inject(DonorService);
Donorform = new FormGroup({
  name: new FormControl('', Validators.required),
  phoneNumber: new FormControl('', Validators.required),
  email: new FormControl('', Validators.required),
})
ngOnInit() {
    if (this.thisDonor) {
      this.Donorform.patchValue(this.thisDonor);
    }
  }
onSubmit() {
  if (this.Donorform.valid) {
    this.DonorService.editDonor(this.thisId, this.Donorform.value).subscribe(
      (response) => {
        alert('פרטי התורם עודכנו בהצלחה!');
        this.closeMe();
      },
      (error) => {
        console.error('שגיאה בעדכון פרטי התורם:', error);
        alert('אירעה שגיאה בעת עדכון פרטי התורם. אנא נסה שוב מאוחר יותר.');
      }
    );
}
  }
closeMe() {
  this.closeEdit.emit();
}
}