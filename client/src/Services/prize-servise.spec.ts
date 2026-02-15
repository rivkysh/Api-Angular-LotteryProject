import { TestBed } from '@angular/core/testing';

import { PrizeServise } from './prize-servise';

describe('PrizeServise', () => {
  let service: PrizeServise;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PrizeServise);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
