import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PublisherStep1Component } from './publisher-step1.component';

describe('PublisherStep1Component', () => {
  let component: PublisherStep1Component;
  let fixture: ComponentFixture<PublisherStep1Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PublisherStep1Component ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PublisherStep1Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
