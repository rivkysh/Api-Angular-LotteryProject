import { Component, EventEmitter, inject, Output } from '@angular/core';
import { DonorService } from '../../../Services/donor-service';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';

@Component({
  selector: 'app-add-new-donor',
  imports: [ReactiveFormsModule],
  templateUrl: './add-new-donor.html',
  styleUrl: './add-new-donor.scss',
})
export class AddNewDonor {
private DonorService = inject(DonorService);
@Output() closeInsert = new EventEmitter<void>();
Donorform = new FormGroup({
  name: new FormControl('', Validators.required),
  phoneNumber: new FormControl('', Validators.required),
  email: new FormControl('', Validators.required),
})
onSubmit() {
  if (this.Donorform.valid) {
    this.DonorService.addDonor(this.Donorform.value).subscribe(
      (response) => {
        alert('התורם נוסף בהצלחה!');
        this.Donorform.reset();
        this.closMe();
      },
      (error) => {
        console.error('שגיאה בהוספת התורם:', error);
        alert('אירעה שגיאה בעת הוספת התורם. אנא נסה שוב מאוחר יותר.');
      }
    );
}
}
closMe() {
  this.closeInsert.emit();
}
}