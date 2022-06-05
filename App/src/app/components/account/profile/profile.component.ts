import { Component, OnInit, ViewChild } from '@angular/core';
import { Developer } from 'src/app/models/developer';
import { Post } from 'src/app/models/post';
import { Project } from 'src/app/models/project';
import { SwiperComponent } from 'swiper/angular';
import { DevpointMiniPreviewProps } from '@ui-kit/components/devpoint-mini-preview/devpoint-mini-preview.props';
import * as moment from 'moment';
import { plainToTyped } from 'type-transformer';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css'],
})
export class ProfileComponent implements OnInit {
  developer: Developer = plainToTyped(
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

  projects: DevpointMiniPreviewProps[] = Array(5).fill({
    link: '/project/1',
    name: 'Talking Ben',
    imgSrc: '/assets/img/ben.png',
  });

  constructor() {}

  ngOnInit(): void {}
}
