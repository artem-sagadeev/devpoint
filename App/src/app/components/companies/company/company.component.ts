import { Component, Input, OnInit } from '@angular/core';
import { Company } from 'src/app/models/company';
import { Developer } from '../../../models/developer';
import { plainToTyped } from 'type-transformer';
import { DevpointMiniPreviewProps } from '@ui-kit/components/devpoint-mini-preview/devpoint-mini-preview.props';
import * as moment from 'moment';
import { Observable, of } from 'rxjs';
import { Post } from '../../../models/post';

@Component({
  selector: 'app-company',
  templateUrl: './company.component.html',
  styleUrls: ['./company.component.css'],
})
export class CompanyComponent implements OnInit {
  @Input() isOwned: boolean = true;
  @Input() company: Company = plainToTyped(
    {
      id: '1',
      name: 'Talking Ben Incorporated',
      subscriberCount: 1,
      description: 'Very professional company!',
      tags: [
        { name: 'Tag 1' },
        { name: 'Tag 2' },
        { name: 'Tag 3' },
        { name: 'Tag 4' },
        { name: 'Tag 5' },
      ],
      imgPath: 'assets/img/ben.png',
    },
    Company,
  );

  @Input() projects: DevpointMiniPreviewProps[] = Array(5).fill({
    link: '/project/1',
    name: 'Talking Ben',
    imgSrc: '/assets/img/ben.png',
  });

  @Input() developers: DevpointMiniPreviewProps[] = Array(5).fill({
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
