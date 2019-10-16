import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { ArticleCategoryService } from 'src/app/article.category.service';
import { Article, ArticleCategory } from '../../article.models';
import { Observable } from 'rxjs';
import { Router, ActivatedRoute, ParamMap, convertToParamMap } from '@angular/router';
import { switchMap } from 'rxjs/operators';
import { FlatTreeControl } from '@angular/cdk/tree';
import { MatTreeFlatDataSource, MatTreeFlattener } from '@angular/material/tree';
import { SelectionModel } from '@angular/cdk/collections';
import {BehaviorSubject} from 'rxjs';

interface INode {
  title: string;
  categories?: INode[];
  selected: boolean;
}

/** Flat node with expandable and level information */
interface ExampleFlatNode {
  expandable: boolean;
  selected: boolean;
  title: string;
  level: number;
}

@Component({
  selector: 'app-publisher-step5',
  templateUrl: './publisher-step5.component.html',
  styleUrls: ['./publisher-step5.component.scss']
})
export class PublisherStep5Component implements OnInit {

  constructor(private route: ActivatedRoute,
              private articleCategoryService: ArticleCategoryService) {

              }
  public articleCategoryObservable$: Observable<ArticleCategory[]>;
  public articleCategories: ArticleCategory[];
  @Input() article: Article;

  transformer = (node: INode, level: number) => {
    return {
      expandable: !!node.categories && node.categories.length > 0,
      title: node.title,
      selected: node.selected,
      level
    };
  }

  // tslint:disable-next-line: member-ordering
  treeControl = new FlatTreeControl<ExampleFlatNode>(
    node => node.level, node => node.expandable);

  // tslint:disable-next-line: member-ordering
  treeFlattener = new MatTreeFlattener(
    this.transformer, node => node.level,
    node => node.expandable, node => node.categories);

  // tslint:disable-next-line: member-ordering
  dataSource = new MatTreeFlatDataSource( this.treeControl,
                                          this.treeFlattener);

  // tslint:disable-next-line: member-ordering
  dataChange = new BehaviorSubject<ExampleFlatNode[]>([]);

  getLevel = (node: ExampleFlatNode) => node.level;


  hasChild = (_: number, node: ExampleFlatNode) => node.expandable;

  // tslint:disable-next-line: member-ordering
  checklistSelection = new SelectionModel<INode>(true /* multiple */);

  /* Checks all the parents when a leaf node is selected/unselected */
  checkAllParentsSelection(node: ExampleFlatNode): void {
    console.log(node.selected);
    let parent: ExampleFlatNode | null = this.getParentNode(node);
    while (parent) {
      this.checkRootNodeSelection(parent);
      parent = this.getParentNode(parent);
    }
  }

  /** Check root node checked state and change it accordingly */
  checkRootNodeSelection(node: ExampleFlatNode): void {
    const nodeSelected = this.checklistSelection.isSelected(node);
    const descendants = this.treeControl.getDescendants(node);
    const descAllSelected = descendants.every(child =>
      this.checklistSelection.isSelected(child)
    );
    if (nodeSelected && !descAllSelected) {
      this.checklistSelection.deselect(node);
    } else if (!nodeSelected && descAllSelected) {
      this.checklistSelection.select(node);
    }
  }

  /* Get the parent node of a node */
  getParentNode(node: ExampleFlatNode): ExampleFlatNode | null {
    const currentLevel = this.getLevel(node);

    if (currentLevel < 1) {
      return null;
    }

    const startIndex = this.treeControl.dataNodes.indexOf(node) - 1;

    for (let i = startIndex; i >= 0; i--) {
      const currentNode = this.treeControl.dataNodes[i];

      if (this.getLevel(currentNode) < currentLevel) {
        return currentNode;
      }
    }
    return null;
  }

  /** Whether all the descendants of the node are selected. */
  descendantsAllSelected(node: ExampleFlatNode): boolean {
    const descendants = this.treeControl.getDescendants(node);
    const descAllSelected = descendants.every(child =>
      this.checklistSelection.isSelected(child)
    );
    return descAllSelected;
  }

  /** Whether part of the descendants are selected */
  descendantsPartiallySelected(node: ExampleFlatNode): boolean {
    const descendants = this.treeControl.getDescendants(node);
    const result = descendants.some(child => this.checklistSelection.isSelected(child));
    return result && !this.descendantsAllSelected(node);
  }

  /** Toggle the to-do item selection. Select/deselect all the descendants node */
  todoItemSelectionToggle(node: ExampleFlatNode): void {
    this.checklistSelection.toggle(node);
    const descendants = this.treeControl.getDescendants(node);

    this.checklistSelection.isSelected(node)
      ? this.checklistSelection.select(...descendants)
      : this.checklistSelection.deselect(...descendants);

    // Force update for the parent
    descendants.every(child =>
      this.checklistSelection.isSelected(child)
    );
    this.checkAllParentsSelection(node);
  }

  /** Toggle a leaf to-do item selection. Check all the parents to see if they changed */
  todoLeafItemSelectionToggle(node: ExampleFlatNode): void {
    this.checklistSelection.toggle(node);
    console.log(this.checklistSelection);
    this.checkAllParentsSelection(node);
  }

  ngOnInit() {
    this.getArticleCategories();
  }

  getArticleCategories() {
      this.articleCategoryObservable$ = this.route.paramMap.pipe(
        switchMap((params: ParamMap) =>
          this.articleCategoryService.getArticleCategories(+params.get('id')))
      );

      this.articleCategoryObservable$.subscribe((articleCategories: ArticleCategory[]) => {
        this.articleCategories = articleCategories;

        // debug
        this.articleCategories.forEach(element => {
          element.selected = this.article.tags.includes(element.id);
        });

        this.dataSource.data = this.articleCategories;
        console.log(this.dataSource);
        console.log(this.article);
      });
  }
}
