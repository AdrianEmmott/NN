import { SafeHtml } from '@angular/platform-browser';

export class Article {
    id: number;
    title: string;
    subtitle: string;
    summary: string;
    viewCount: number;
    content: string;
    author: string;
    publishDate: Date;
    tagIds: Array<number>;
  }

export class ArticleSummary {
    id: number;
    title: string;
    summary: string;
    viewCount: number;
    author: string;
    publishDate: Date;
  }

export class TagModel {
    id: number;
    title: string;
    showInNav: boolean;
    sortOrder: number;
    path: string;
    tags?: Array<TagModel>;
    expandable: boolean;
    selected: boolean;
    level: number;
  }

export class ArticleTagModel {
  articleId: number;
  tagIds: Array<number>;
  tags: Array<TagModel>;
}
