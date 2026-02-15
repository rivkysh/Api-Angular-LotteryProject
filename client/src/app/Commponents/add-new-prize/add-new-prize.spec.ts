import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddNewPrize } from './add-new-prize';

describe('AddNewPrize', () => {
  let component: AddNewPrize;
  let fixture: ComponentFixture<AddNewPrize>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AddNewPrize]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddNewPrize);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
