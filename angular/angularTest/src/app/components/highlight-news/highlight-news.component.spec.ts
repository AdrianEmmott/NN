import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HighlightNewsComponent } from './highlight-news.component';

describe('HighlightNewsComponent', () => {
  let component: HighlightNewsComponent;
  let fixture: ComponentFixture<HighlightNewsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HighlightNewsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HighlightNewsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
