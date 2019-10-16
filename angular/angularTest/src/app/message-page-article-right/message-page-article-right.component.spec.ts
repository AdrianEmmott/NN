import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MessagePageArticleRightComponent } from './message-page-article-right.component';

describe('MessagePageArticleRightComponent', () => {
  let component: MessagePageArticleRightComponent;
  let fixture: ComponentFixture<MessagePageArticleRightComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MessagePageArticleRightComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MessagePageArticleRightComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
