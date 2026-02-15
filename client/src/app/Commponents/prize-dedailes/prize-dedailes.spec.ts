import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PrizeDedailes } from './prize-dedailes';

describe('PrizeDedailes', () => {
  let component: PrizeDedailes;
  let fixture: ComponentFixture<PrizeDedailes>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PrizeDedailes]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PrizeDedailes);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
