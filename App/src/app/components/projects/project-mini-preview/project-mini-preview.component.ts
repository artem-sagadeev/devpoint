import { Component, Input, OnInit } from '@angular/core';
import { Project } from 'src/app/models/project';

@Component({
  selector: 'app-project-mini-preview',
  templateUrl: './project-mini-preview.component.html',
  styleUrls: ['./project-mini-preview.component.css']
})
export class ProjectMiniPreviewComponent implements OnInit {
  @Input() project: Project | null = null;

  constructor() { }

  ngOnInit(): void {
  }

}
