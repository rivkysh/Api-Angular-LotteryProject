import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GetPrizesByDonor } from './get-prizes-by-donor';

describe('GetPrizesByDonor', () => {
  let component: GetPrizesByDonor;
  let fixture: ComponentFixture<GetPrizesByDonor>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [GetPrizesByDonor]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GetPrizesByDonor);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
