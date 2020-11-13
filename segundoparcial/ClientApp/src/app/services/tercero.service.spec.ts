import { TestBed } from '@angular/core/testing';

import { TerceroService } from './tercero.service';

describe('TerceroService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: TerceroService = TestBed.get(TerceroService);
    expect(service).toBeTruthy();
  });
});
