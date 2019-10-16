import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MessagePageArticleComponent } from './message-page-article.component';

describe('MessagePageArticleComponent', () => {
  let component: MessagePageArticleComponent;
  let fixture: ComponentFixture<MessagePageArticleComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MessagePageArticleComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MessagePageArticleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
