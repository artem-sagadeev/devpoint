import { Component, Input, OnInit } from '@angular/core';
import { Project } from 'src/app/models/project';

@Component({
  selector: 'app-project-preview',
  templateUrl: './project-preview.component.html',
  styleUrls: ['./project-preview.component.css'],
})
export class ProjectPreviewComponent implements OnInit {
  @Input() project: Project = new Project();

  constructor() {}

  ngOnInit(): void {}
}
