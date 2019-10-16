import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MessagePageArticleLeftComponent } from './message-page-article-left.component';

describe('MessagePageArticleLeftComponent', () => {
  let component: MessagePageArticleLeftComponent;
  let fixture: ComponentFixture<MessagePageArticleLeftComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MessagePageArticleLeftComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MessagePageArticleLeftComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
