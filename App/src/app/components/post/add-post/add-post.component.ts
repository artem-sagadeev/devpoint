import { Component, OnInit, ViewChild } from '@angular/core';
import * as moment from 'moment';
import { Moment } from 'moment';
import { MarkdownService } from 'ngx-markdown';
import { LocalStorageService } from '../../../services/local-storage.service';

@Component({
  selector: 'app-add-post',
  templateUrl: './add-post.component.html',
  styleUrls: ['./add-post.component.css'],
})
export class AddPostComponent implements OnInit {
  date?: Moment;
  title?: string;
  content?: string;
  options?: any;
  saved?: Moment;
  page?: string = 'editor';
  subType?: string;
  cover?: File;

  @ViewChild('input') input?: any;

  constructor(
    private markdownService: MarkdownService,
    private localStorageService: LocalStorageService,
  ) {}

  ngOnInit(): void {
    this.date = moment();
    this.title = this.localStorageService.getData('post-title') ?? undefined;
    this.options = {
      lang: 'en_US',
      mode: 'sv',
      tab: '\t',
      toolbar: [
        'emoji',
        'headings',
        'bold',
        'italic',
        'strike',
        'link',
        '|',
        'list',
        'ordered-list',
        'outdent',
        'indent',
        '|',
        'quote',
        'line',
        'code',
        'inline-code',
        'insert-before',
        'insert-after',
        '|',
        'upload',
        'table',
        '|',
        'undo',
        'redo',
        '|',
        'both',
        'preview',
      ],
      cache: {
        enable: true,
        id: 'post',
        after: this.onCached.bind(this),
      },
      preview: {
        transform: this.parse.bind(this),
        actions: [],
      },
    };
  }

  highlight() {
    setTimeout(() => {
      this.markdownService.highlight();
    });
  }

  parse(inputValue: string) {
    const markedOutput = this.markdownService.compile(inputValue.trim());
    this.highlight();

    return markedOutput;
  }

  onCached() {
    this.saved = moment();
  }

  cacheTitle() {
    this.localStorageService.setData('post-title', this.title);
    this.onCached();
  }

  onFileChanged(image?: File) {
    this.cover = image;
  }
}
