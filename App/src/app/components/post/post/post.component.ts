import { Component, OnInit } from '@angular/core';
import { Post } from '../../../models/post';
import * as moment from 'moment';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.css'],
})
export class PostComponent implements OnInit {
  post?: Post = {
    id: '1',
    title: 'Talking Ben on PC!',
    content:
      '**Talking Ben** just released on PC for *Windows* and *Linux* on *Steam*! Only for **399$**!\n ### LIST\n - one\n - two\n - **three**\n\r```css\n.projects-container {\n' +
      '    margin-top: 20px;\n' +
      '    margin-bottom: 20px;\n' +
      '    position: relative;\n' +
      '}\n```',
    tags: [{ text: 'News' }],
    hasUserAccess: true,
    date: moment().format('DD.MM.YYYY'),
  };
  loading: boolean = true;
  constructor() {}

  ngOnInit(): void {}

  onLoad() {
    this.loading = false;
  }
}
