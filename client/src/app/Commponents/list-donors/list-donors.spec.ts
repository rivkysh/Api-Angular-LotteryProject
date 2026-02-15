import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListDonors } from './list-donors';

describe('ListDonors', () => {
  let component: ListDonors;
  let fixture: ComponentFixture<ListDonors>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ListDonors]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ListDonors);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
