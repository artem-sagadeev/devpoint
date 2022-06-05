import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Developer } from '../../../models/developer';

@Component({
  selector: 'app-developer-entry',
  templateUrl: './developer-entry.component.html',
  styleUrls: ['./developer-entry.component.css'],
})
export class DeveloperEntryComponent implements OnInit {
  @Input() developer?: Developer;
  @Output() remove = new EventEmitter<Developer>();
  loading: boolean = true;
  constructor() {}

  ngOnInit(): void {}

  onLoad() {
    this.loading = false;
  }
}
