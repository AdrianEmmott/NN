import { Component, OnInit, Input, Output, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { PublisherStep1Component } from 'src/app/publisher/publisher-step1/publisher-step1.component';
import { PublisherStep2Component } from 'src/app/publisher/publisher-step2/publisher-step2.component';
import { ArticlePublisherService } from 'src/app/article.publisher.service';
import { ArticleService } from 'src/app/article.service';
import { Article } from '../article.models';
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
              private articlePublisherService: ArticlePublisherService) { }

  public articleObservable$: Observable<Article>;

  private article: Article;

  ngOnInit() {
    this.getArticle();
  }

  getArticle() {
    this.articleObservable$ = this.route.paramMap.pipe(
      switchMap((params: ParamMap) =>
        this.articleService.getArticle(+params.get('id')))
    );

    this.articleObservable$.subscribe((article: Article) => {
      this.article = article;
    });
  }

  showStep2(step1Complete: boolean) {
    this.step2Visible = step1Complete;
    this.step1Visible = false;
  }

  getArticleData(event: any) {
    // console.log(event);
    this.getArticleDataFromStep1();
    this.getArticleDataFromStep2();
  }

  getArticleDataFromStep1() {
    this.article.title = this.step1Component.article.title;
    this.article.author = this.step1Component.article.author;
    this.article.publishDate = this.step1Component.article.publishDate;
  }

  getArticleDataFromStep2() {
    this.article.content = this.step2Component.article.content;
  }

  updateArticleClick() {
    this.articlePublisherService.updateArticle(this.article);
  }
}
