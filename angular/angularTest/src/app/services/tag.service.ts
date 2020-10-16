import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse, HttpHeaders } from '@angular/common/http';
import { TagModel, ArticleTagModel } from '../models/article.models';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class TagService {

  constructor(private httpClient: HttpClient) { }

  public getTags(): Observable<TagModel[]> {
    const article = this.httpClient
      .get<TagModel[]>('https://localhost:8080/api/tags/all/tree');
    return article;
  }

  public getTagsFlattened(): Observable<TagModel[]> {
    const article = this.httpClient
      .get<TagModel[]>('https://localhost:8080/api/tags/all/flattened');
    return article;
  }

  public getTagsByArticleId(id: number): Observable<ArticleTagModel> {
    const articleTags = this.httpClient
      .get<ArticleTagModel>('https://localhost:8080/api/tags/article/' + id);
    return articleTags;
  }

  public createArticleTags(articleTags: ArticleTagModel) {
    const myHeaders = new HttpHeaders();
    myHeaders.set('Content-Type', 'application/json');

    console.log(articleTags);

    this.httpClient.post('https://localhost:8080/api/tags/create-article-tags'
      , articleTags
      , { headers: myHeaders })
      .subscribe();
  }

  public updateArticleTags(articleTags: ArticleTagModel) {
    const myHeaders = new HttpHeaders();
    myHeaders.set('Content-Type', 'application/json');
    ///myHeaders.set('Content-Type', 'text/plain');

console.log(articleTags) ;

    this.httpClient.post('https://localhost:8080/api/tags/update-article-tags'
      , articleTags
      //, JSON.stringify('Test')
      , { headers: myHeaders }
      )
      .subscribe();
  }
}
