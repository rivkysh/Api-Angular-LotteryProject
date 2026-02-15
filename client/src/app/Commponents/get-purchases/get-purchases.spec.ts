import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GetPurchases } from './get-purchases';

describe('GetPurchases', () => {
  let component: GetPurchases;
  let fixture: ComponentFixture<GetPurchases>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [GetPurchases]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GetPurchases);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
