import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ArticleAttachmentsComponent } from './article-attachments.component';

describe('ArticleAttachmentsComponent', () => {
  let component: ArticleAttachmentsComponent;
  let fixture: ComponentFixture<ArticleAttachmentsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ArticleAttachmentsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ArticleAttachmentsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
