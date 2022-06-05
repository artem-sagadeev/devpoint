import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { Post } from 'src/app/models/post';

@Component({
  selector: 'app-post-preview',
  templateUrl: './post-preview.component.html',
  styleUrls: ['./post-preview.component.css'],
})
export class PostPreviewComponent implements OnInit {
  @Input() post: Post = new Post();
  loading: boolean = false;

  @ViewChild('image') image?: HTMLImageElement;

  constructor() {}

  ngOnInit(): void {
    //this.loading = !this.image?.complete ?? false;
  }

  onLoad() {
    this.loading = false;
  }
}
