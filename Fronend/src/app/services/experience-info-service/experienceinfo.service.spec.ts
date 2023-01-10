import { TestBed } from '@angular/core/testing';

import { ExperienceinfoService } from './experienceinfo.service';

describe('ExperienceinfoService', () => {
  let service: ExperienceinfoService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ExperienceinfoService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
