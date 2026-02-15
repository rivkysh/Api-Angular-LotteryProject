import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddNewDonor } from './add-new-donor';

describe('AddNewDonor', () => {
  let component: AddNewDonor;
  let fixture: ComponentFixture<AddNewDonor>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AddNewDonor]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddNewDonor);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
