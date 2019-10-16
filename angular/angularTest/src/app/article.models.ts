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
    tags: number[];
  }

export class ArticleSummary {
    id: number;
    title: string;
    summary: string;
    viewCount: number;
    author: string;
    publishDate: Date;
  }

export class ArticleCategory {
    id: number;
    title: string;
    categories?: ArticleCategory[];
    expandable: boolean;
    selected: boolean;
    level: number;
  }
