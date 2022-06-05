import { Component, Input, OnInit } from '@angular/core';
import { Project } from 'src/app/models/project';
import { Developer } from '../../../models/developer';
import { plainToTyped } from 'type-transformer';
import { DevpointMiniPreviewProps } from '@ui-kit/components/devpoint-mini-preview/devpoint-mini-preview.props';
import * as moment from 'moment';
import { Observable, of } from 'rxjs';
import { Post } from '../../../models/post';

@Component({
  selector: 'app-project',
  templateUrl: './project.component.html',
  styleUrls: ['./project.component.css'],
})
export class ProjectComponent implements OnInit {
  @Input() isOwned: boolean = true;

  project: Project = plainToTyped(
    {
      id: '1',
      name: 'Talking Ben',
      subscriberCount: 220000000,
      description: 'Best mobile game in existence!',
      tags: [
        { name: 'Tag 1' },
        { name: 'Tag 2' },
        { name: 'Tag 3' },
        { name: 'Tag 4' },
        { name: 'Tag 5' },
      ],
      imgPath: 'assets/img/ben.png',
    },
    Project,
  );

  developers: DevpointMiniPreviewProps[] = Array(5).fill({
    link: '/developer/1',
    name: 'Ben',
    imgSrc: '/assets/img/ben.png',
  });

  constructor() {}

  ngOnInit(): void {}

  getPostsRequest(take: number, skip: number): Observable<Post[]> {
    return of([
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
    ]);
  }
}
