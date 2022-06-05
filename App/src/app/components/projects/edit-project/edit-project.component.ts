import { Component, OnInit } from '@angular/core';
import { Company } from '../../../models/company';
import { plainToTyped } from 'type-transformer';
import { Developer } from '../../../models/developer';
import { Tag } from '../../../models/tag';
import { ActivatedRoute } from '@angular/router';
import { Project } from '../../../models/project';

@Component({
  selector: 'app-edit-project',
  templateUrl: './edit-project.component.html',
  styleUrls: ['./edit-project.component.css'],
})
export class EditProjectComponent implements OnInit {
  project: Project = plainToTyped(
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
    Project,
  );

  developers: Developer[] = [
    plainToTyped(
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
        email: 'ben@gmail.com',
      },
      Developer,
    ),
    plainToTyped(
      {
        id: '1',
        name: '4el',
        subscriberCount: 22000,
        description: '4E/\\ XaPow',
        tags: [{ name: '4El' }, { name: 'XaPow' }],
        imgPath: '/assets/img/avatar.png',
        email: '1337@stud.kpfu.ru',
      },
      Developer,
    ),
  ];

  page: number = 0;

  image?: File;
  tags: Tag[] = [];

  constructor(private route: ActivatedRoute) {}

  ngOnInit() {
    this.route.queryParams.subscribe((params) => {
      this.page = Number(params['page'] ?? 0);
    });
    this.tags = this.project.tags;
  }

  onFileChanged(image?: File) {
    this.image = image;
  }

  onDeveloperRemove(developer: Developer) {}
  onDeveloperAdd() {}
}
