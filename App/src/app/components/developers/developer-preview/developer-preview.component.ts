import { Component, Input, OnInit } from '@angular/core';
import { Developer } from 'src/app/models/developer';

@Component({
  selector: 'app-developer-preview',
  templateUrl: './developer-preview.component.html',
  styleUrls: ['./developer-preview.component.css']
})
export class DeveloperPreviewComponent implements OnInit {
  @Input() developer: Developer = new Developer();

  constructor() { }

  ngOnInit(): void {
  }
}
