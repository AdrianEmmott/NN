import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { TagService } from 'src/app/services/tag.service';
import { Article, TagModel } from '../../../models/article.models';
import { Observable } from 'rxjs';
import { Router, ActivatedRoute, ParamMap, convertToParamMap } from '@angular/router';
import { switchMap } from 'rxjs/operators';
import { FlatTreeControl } from '@angular/cdk/tree';
import { MatTreeFlatDataSource, MatTreeFlattener } from '@angular/material/tree';
import { SelectionModel } from '@angular/cdk/collections';
import { BehaviorSubject } from 'rxjs';

interface INode {
  id: number;
  title: string;
  tags?: INode[];
  selected: boolean;
}

/** Flat node with expandable and level information */
interface ExampleFlatNode {
  id: number;
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
              private tagService: TagService) {
  }
  public tagObservable$: Observable<Array<TagModel>>;
  public allTags: Array<TagModel>;
  @Input() article: Article;

  transformer = (node: INode, level: number) => {
    return {
      expandable: !!node.tags && node.tags.length > 0,
      title: node.title,
      id: node.id,
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
    node => node.expandable, node => node.tags);

  // tslint:disable-next-line: member-ordering
  dataSource = new MatTreeFlatDataSource(this.treeControl,
    this.treeFlattener);

  // tslint:disable-next-line: member-ordering
  dataChange = new BehaviorSubject<ExampleFlatNode[]>([]);

  getLevel = (node: ExampleFlatNode) => node.level;

  hasChild = (_: number, node: ExampleFlatNode) => node.expandable;

  // tslint:disable-next-line: member-ordering
  checklistSelection = new SelectionModel<INode>(true /* multiple */);

  /* Checks all the parents when a leaf node is selected/unselected */
  checkAllParentsSelection(node: ExampleFlatNode): void {
    this.setArticleTags(node);
    let parent: ExampleFlatNode | null = this.getParentNode(node);
    while (parent) {
      this.checkRootNodeSelection(parent);
      this.setArticleTags(parent);
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

    // this.setArticleTags(node);

    // Force update for the parent
    // descendants.every(child => {
    //   this.checklistSelection.isSelected(child);
    //   console.log(child.id);
    //   this.setArticleTags(child);
    // });

    descendants.forEach(child => {
      this.checklistSelection.isSelected(child);
      this.setArticleTags(child);
    });

    this.checkAllParentsSelection(node);
  }

  /** Toggle a leaf to-do item selection. Check all the parents to see if they changed */
  todoLeafItemSelectionToggle(node: ExampleFlatNode): void {
    this.checklistSelection.toggle(node);
    this.checkAllParentsSelection(node);
  }

  ngOnInit() {
    // console.log(this.article);
    this.getArticleTags();
  }


  setArticleTags(node: ExampleFlatNode): void {
    if (this.checklistSelection.isSelected(node)) {
      if (this.article.tagIds != null) {
        if (!this.article.tagIds.includes(node.id)) {
          this.article.tagIds.push(node.id);
        }
      } else {
        // console.log('in there');
        this.article.tagIds = new Array<number>();
        this.article.tagIds.push(node.id);
      }
    } else {
      if (this.article.tagIds != null) {
        if (this.article.tagIds.includes(node.id)) {
          this.article.tagIds.splice(this.article.tagIds.indexOf(node.id), 1);
        }
      }
    }

    if (this.article.tagIds != null) {
      this.article.tagIds.sort();
    }
    // console.log(this.article.tags);
  }

  getArticleTags() {
    this.tagObservable$ = this.route.paramMap.pipe(
      switchMap((params: ParamMap) =>
        this.tagService.getTags())
    );

    this.tagObservable$.subscribe((allTags: TagModel[]) => {
      this.allTags = allTags;

      // set tags selected in tags data source based on tag ids in article
      this.allTagsSetSelected();

      // set treeview dataSource
      this.dataSource.data = this.allTags;

      // Set the tree node data source checked state
      const descendants = this.treeControl.dataNodes;
      descendants.forEach(child => {
        if (child.selected) {
          this.checklistSelection.select(child);
        }
        this.checkAllParentsSelection(child);
        this.setArticleTags(child);
      });

      // debug alley
      // console.log(descendants);
      // console.log(this.dataSource);
      // console.log(this.article);
      // console.log(this.checklistSelection);
    });
  }

  allTagsSetSelected(): void {
    this.allTags.forEach(tag => {
      if (this.article.tagIds != null) {
        tag.selected = this.article.tagIds.includes(tag.id);

        // RECURSIVE
        this.allTagsSetSelectedInner(tag.tags);
      }
    });
  }

  allTagsSetSelectedInner(tags: Array<TagModel>): void {
    if (tags != null) {
      tags.forEach(tag => {
        tag.selected = this.article.tagIds.includes(tag.id);

        this.allTagsSetSelectedInner(tag.tags);
      });
    }
  }
}
