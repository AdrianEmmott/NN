import { OnInit, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { TagModel } from './article.models';
import { TagService } from './tag.service';
import { LanderComponent } from './lander/lander.component';
import { ArticleComponent } from './article/article.component';
@Injectable()
export class DynamicRoutes {
    constructor(private tagService: TagService, ) {
        // alert(1);
        // this.getTags();
    }

    public tagObservable$: Observable<Array<TagModel>>;
    public tags: Array<TagModel>;
    public DYNAMIC_ROUTES = [];


    getTags() {
        // alert();
        this.tagObservable$ = this.tagService.getTagsFlattened();

        this.tagObservable$.subscribe((tags: Array<TagModel>) => {
            this.tags = tags;
            const dynamicRoutes = [];
            this.tags.forEach(tag => {
                dynamicRoutes.push(
                    { path: tag.path.substring(1), component: LanderComponent, data: { tagId: tag.id } }
                    , { path: tag.path.substring(1) + '/articles/:id', component: ArticleComponent, pathMatch: 'full' }
                );
            });

            this.DYNAMIC_ROUTES = dynamicRoutes;
            console.log(this.DYNAMIC_ROUTES);
        });
    }
}
