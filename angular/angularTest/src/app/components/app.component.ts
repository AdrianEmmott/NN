import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
// import { Observable } from 'rxjs';
// import { TagModel } from '../models/articles/article.models';
// import { LanderComponent } from './lander/lander.component';
// import { ArticleComponent } from './article/article.component';

@Component({
  selector: 'app-root',
  templateUrl: 'app.component.html',
  styleUrls: ['app.component.scss']
})
export class AppComponent implements OnInit {
  constructor(private router: Router) { }

  title = 'Newsy Newsy';

  ngOnInit(): void {
  }
}
