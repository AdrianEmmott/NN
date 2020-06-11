import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PublisherStep2Component } from './publisher-step2.component';

describe('PublisherStep2Component', () => {
  let component: PublisherStep2Component;
  let fixture: ComponentFixture<PublisherStep2Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PublisherStep2Component ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PublisherStep2Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
