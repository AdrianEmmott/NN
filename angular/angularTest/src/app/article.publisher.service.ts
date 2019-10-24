import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse, HttpHeaders } from '@angular/common/http';
import { Article, ArticleSummary } from './article.models';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ArticlePublisherService {

  constructor(private httpClient: HttpClient) { }

  public updateArticle(article: Article) {
    // public updateArticle(article: Array<number>) {
    const myHeaders = new HttpHeaders();
    myHeaders.set('Content-Type', 'application/json');

    this.httpClient.post('https://localhost:8080/api/articlepublisher/'
      , article
      , { headers: myHeaders })
      .subscribe();
  }
}
