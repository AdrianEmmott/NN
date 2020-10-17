import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PublisherStep6Component } from './publisher-step6.component';

describe('PublisherStep6Component', () => {
  let component: PublisherStep6Component;
  let fixture: ComponentFixture<PublisherStep6Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PublisherStep6Component ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PublisherStep6Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
