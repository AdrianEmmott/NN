import { Component, OnInit} from '@angular/core';
import { ArticleService } from 'src/app/services/articles/article.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.scss']
})
export class MainComponent implements OnInit {

  constructor(private articleService: ArticleService, private router: Router) { }

  ngOnInit() {
  }

}
