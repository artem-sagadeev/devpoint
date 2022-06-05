import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { Developer } from '../../../models/developer';
import { plainToTyped } from 'type-transformer';
import { COMMA, ENTER } from '@angular/cdk/keycodes';
import { FormControl } from '@angular/forms';
import { map, Observable, startWith } from 'rxjs';
import { Tag } from '../../../models/tag';
import { MatChipInputEvent } from '@angular/material/chips';
import { MatAutocompleteSelectedEvent } from '@angular/material/autocomplete';

@Component({
  selector: 'app-profile-edit',
  templateUrl: './profile-edit.component.html',
  styleUrls: ['./profile-edit.component.css'],
})
export class ProfileEditComponent implements OnInit {
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

  page: number = 0;

  image?: File;
  tags: Tag[] = [];

  constructor() {}

  ngOnInit() {
    this.tags = this.developer.tags;
  }

  onFileChanged(image?: File) {
    this.image = image;
  }
}
