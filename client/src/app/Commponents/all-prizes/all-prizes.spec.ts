import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AllPrizes } from './all-prizes';

describe('AllPrizes', () => {
  let component: AllPrizes;
  let fixture: ComponentFixture<AllPrizes>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AllPrizes]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AllPrizes);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
