import { Component, Input, OnInit } from '@angular/core';
import { Developer } from 'src/app/models/developer';

@Component({
  selector: 'app-developer',
  templateUrl: './developer.component.html',
  styleUrls: ['./developer.component.css']
})
export class DeveloperComponent implements OnInit {
  developer: Developer = new Developer()

  constructor() { }

  ngOnInit(): void {
  }
}
