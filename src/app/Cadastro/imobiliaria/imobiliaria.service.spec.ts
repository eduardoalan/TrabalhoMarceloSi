/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { ImobiliariaService } from './imobiliaria.service';

describe('Service: Imobiliaria', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ImobiliariaService]
    });
  });

  it('should ...', inject([ImobiliariaService], (service: ImobiliariaService) => {
    expect(service).toBeTruthy();
  }));
});
