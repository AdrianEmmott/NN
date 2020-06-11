import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PublisherStep5Component } from './publisher-step5.component';

describe('PublisherStep5Component', () => {
  let component: PublisherStep5Component;
  let fixture: ComponentFixture<PublisherStep5Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PublisherStep5Component ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PublisherStep5Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
