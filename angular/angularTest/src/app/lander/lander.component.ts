import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, ParamMap, convertToParamMap } from '@angular/router';
import { TagService } from '../tag.service';
import { TagModel } from '../article.models';
import { Observable } from 'rxjs';
import { switchMap } from 'rxjs/operators';


@Component({
  selector: 'app-lander',
  templateUrl: './lander.component.html',
  styleUrls: ['./lander.component.scss']
})
export class LanderComponent implements OnInit {

  constructor(private router: Router,
              private route: ActivatedRoute,
              private tagService: TagService) { }

  public tagObservable$: Observable<Array<TagModel>>;
  public tags: Array<TagModel>;

  ngOnInit() {
    const url = this.router.url;
    console.log(url.replace('/', ''));
  }
}
