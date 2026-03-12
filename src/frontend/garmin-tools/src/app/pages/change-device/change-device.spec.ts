import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ChangeDevice } from './change-device';

describe('ChangeDevice', () => {
  let component: ChangeDevice;
  let fixture: ComponentFixture<ChangeDevice>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ChangeDevice]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ChangeDevice);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
