import { Component, OnInit } from '@angular/core';
import { ArticleService } from 'src/app/article.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  constructor(private articleService: ArticleService, private router: Router) { }

  title = 'Network News';

  ngOnInit(): void {

  }

  clickExample() {
    alert();
  }
}
