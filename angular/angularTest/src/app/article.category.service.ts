import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse, HttpHeaders } from '@angular/common/http';
import { ArticleCategory } from './article.models';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ArticleCategoryService {

  constructor(private httpClient: HttpClient) { }

  public getArticleCategories(id: number): Observable<ArticleCategory[]> {
    const article = this.httpClient
      .get<ArticleCategory[]>('https://localhost:8080/api/articlecategories/categories');
    return article;
  }
}
