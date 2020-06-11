import { Component, OnInit, Input, Output, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { PublisherStep1Component } from 'src/app/components/publisher/publisher-step1/publisher-step1.component';
import { PublisherStep2Component } from 'src/app/components/publisher/publisher-step2/publisher-step2.component';
import { ArticlePublisherService } from 'src/app/services/article.publisher.service';
import { ArticleService } from 'src/app/services/article.service';
import { TagService } from 'src/app/services/tag.service';
import { Article, ArticleTagModel } from '../../models/article.models';
import { Observable } from 'rxjs';
import { Router, ActivatedRoute, ParamMap, convertToParamMap } from '@angular/router';
import { switchMap } from 'rxjs/operators';


@Component({
  selector: 'app-publisher',
  templateUrl: './publisher.component.html',
  styleUrls: ['./publisher.component.scss']
})
export class PublisherComponent implements OnInit {
  @ViewChild(PublisherStep1Component, { static: false }) step1Component: PublisherStep1Component;
  @ViewChild(PublisherStep2Component, { static: false }) step2Component: PublisherStep2Component;

  step1Visible = true;
  step2Visible = false;

  constructor(private articleService: ArticleService,
    private route: ActivatedRoute,
    private articlePublisherService: ArticlePublisherService,
    private tagService: TagService) { }

  public articleObservable$: Observable<Article>;
  public articleTagsObservable$: Observable<ArticleTagModel>;

  private article: Article;
  private articleTags: ArticleTagModel;

  ngOnInit() {
    const idParam = this.route.snapshot.paramMap.get('id');
    // console.log(idParam);

    if (idParam != null) {
      this.getArticleTags();
      this.getArticle();

      this.articleTagsObservable$.subscribe((articleTags: ArticleTagModel) => {
        this.articleTags = articleTags;

        this.articleObservable$.subscribe((article: Article) => {
          this.article = article;
          // console.log(this.article);

          if (this.article != null) {
            // console.log(this.articleTags);
            this.article.tagIds = this.articleTags.tagIds;
          }
        });
      });
    } else {
      this.article = new Article();
      this.articleTags = new ArticleTagModel();
    }
  }

  getArticle() {
    this.articleObservable$ = this.route.paramMap.pipe(
      switchMap((params: ParamMap) =>
        this.articleService.getArticle(+params.get('id')))
    );
  }

  getArticleTags() {
    this.articleTagsObservable$ = this.route.paramMap.pipe(
      switchMap((params: ParamMap) =>
        this.tagService.getTagsByArticleId(+params.get('id')))
    );
  }

  showStep2(step1Complete: boolean) {
    this.step2Visible = step1Complete;
    this.step1Visible = false;
  }

  getArticleData(event: any) {
    this.getArticleDataFromStep1();
    this.getArticleDataFromStep2();
    this.getArticleDataFromStep5();
  }

  getArticleDataFromStep1() {
    this.article.title = this.step1Component.article.title;
    this.article.author = this.step1Component.article.author;
    this.article.publishDate = this.step1Component.article.publishDate;
  }

  getArticleDataFromStep2() {
    this.article.content = this.step2Component.article.content;
  }

  getArticleDataFromStep5() {
    this.article.tagIds = this.step2Component.article.tagIds;
  }

  upsertArticleClick() {
    const articleTags = new ArticleTagModel();

    if (this.article.id > 0) {
      this.articlePublisherService.updateArticle(this.article);
      articleTags.articleId = this.article.id;
      articleTags.tagIds = this.article.tagIds;
      this.tagService.updateArticleTags(articleTags);
    } else {
      // this.article.id = this.articlePublisherService.createArticle(this.article);
      this.articlePublisherService.createArticle(this.article).subscribe(response => {
        this.article.id = response.result;
        // console.log(this.article.id);
        articleTags.articleId = this.article.id;
        articleTags.tagIds = this.article.tagIds;
        this.tagService.createArticleTags(articleTags);
      });
    }
  }
}
