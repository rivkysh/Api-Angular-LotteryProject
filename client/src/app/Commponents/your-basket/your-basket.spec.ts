import { ComponentFixture, TestBed } from '@angular/core/testing';

import { YourBasket } from './your-basket';

describe('YourBasket', () => {
  let component: YourBasket;
  let fixture: ComponentFixture<YourBasket>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [YourBasket]
    })
    .compileComponents();

    fixture = TestBed.createComponent(YourBasket);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
