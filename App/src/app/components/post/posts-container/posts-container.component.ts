import { Component, Input, OnInit } from '@angular/core';
import { Post } from '../../../models/post';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-posts-container',
  templateUrl: './posts-container.component.html',
  styleUrls: ['./posts-container.component.css'],
})
export class PostsContainerComponent implements OnInit {
  @Input() getRequest?: (
    take: number,
    skip: number,
    search?: string,
  ) => Observable<Post[]>;
  @Input() totalCount?: number;
  posts?: Post[];
  search?: string;
  @Input() take: number = 3;

  constructor() {}

  ngOnInit(): void {
    if (this.getRequest)
      this.getRequest(this.take, 0, this.search).subscribe((value) =>
        this.appendPosts(value),
      );
  }

  appendPosts(newPosts: Post[]) {
    this.posts = [...(this.posts ?? []), ...newPosts];
  }

  onScrollDown() {
    console.log('234');
    if (this.getRequest)
      this.getRequest(
        this.take,
        this.posts?.length ?? 0,
        this.search,
      ).subscribe((value) => this.appendPosts(value));
  }

  onSearchChange() {
    this.posts = [];
    if (this.getRequest)
      this.getRequest(this.take, 0, this.search).subscribe((value) =>
        this.appendPosts(value),
      );
  }
}
