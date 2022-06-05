import { Component, Input, OnInit } from '@angular/core';
import { Developer } from 'src/app/models/developer';
import { DevpointMiniPreviewProps } from '@ui-kit/components/devpoint-mini-preview/devpoint-mini-preview.props';
import * as moment from 'moment';
import { plainToTyped } from 'type-transformer';
import { map, Observable, of, pipe, timeout, timer } from 'rxjs';
import { Post } from '../../../models/post';

@Component({
  selector: 'app-developer',
  templateUrl: './developer.component.html',
  styleUrls: ['./developer.component.css'],
})
export class DeveloperComponent implements OnInit {
  @Input() isProfile: boolean = false;

  @Input() developer: Developer = plainToTyped(
    {
      id: '1',
      name: 'Ben',
      subscriberCount: 22000,
      description: 'Ho-ho-ho!\nNo...',
      tags: [
        { name: 'Tag 1' },
        { name: 'Tag 2' },
        { name: 'Tag 3' },
        { name: 'Tag 4' },
        { name: 'Tag 5' },
      ],
      imgPath: 'assets/img/ben.png',
    },
    Developer,
  );

  @Input() projects: DevpointMiniPreviewProps[] = Array(5).fill({
    link: '/project/1',
    name: 'Talking Ben',
    imgSrc: '/assets/img/ben.png',
  });

  constructor() {}

  ngOnInit(): void {}

  getPostsRequest(take: number, skip: number): Observable<Post[]> {
    return timer(1000).pipe(
      map((_) => [
        {
          id: '1',
          title: 'Talking Ben on PC!',
          content:
            '**Talking Ben** just released on PC for *Windows* and *Linux* on *Steam*! Only for **399$**!\n ### LIST\n - one\n - two\n - **three**\n\r```css\n.projects-container {\n' +
            '    margin-top: 20px;\n' +
            '    margin-bottom: 20px;\n' +
            '    position: relative;\n' +
            '}\n```',
          tags: [{ name: 'News' }],
          hasUserAccess: true,
          date: moment().format('DD.MM.YYYY'),
        },
        {
          hasUserAccess: false,
        },
      ]),
    );
  }
}
