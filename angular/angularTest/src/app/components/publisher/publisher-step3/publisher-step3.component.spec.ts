import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PublisherStep3Component } from './publisher-step3.component';

describe('PublisherStep3Component', () => {
  let component: PublisherStep3Component;
  let fixture: ComponentFixture<PublisherStep3Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PublisherStep3Component ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PublisherStep3Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
