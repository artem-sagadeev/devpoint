import { Component, Input, OnInit } from '@angular/core';
import { Project } from 'src/app/models/project';

@Component({
  selector: 'app-project-preview',
  templateUrl: './project-preview.component.html',
  styleUrls: ['./project-preview.component.css'],
})
export class ProjectPreviewComponent implements OnInit {
  @Input() project: Project = new Project();
  @Input() isOwned: boolean = false;

  private _isLarge: boolean = false;

  @Input()
  set large(value: boolean | '') {
    this._isLarge = value === '' || value;
  }
  get large(): boolean {
    return this._isLarge;
  }

  constructor() {}

  ngOnInit(): void {}
}
