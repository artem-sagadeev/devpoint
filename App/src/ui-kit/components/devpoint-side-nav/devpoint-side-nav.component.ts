import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-devpoint-side-nav',
  templateUrl: './devpoint-side-nav.component.html',
  styleUrls: ['./devpoint-side-nav.component.css'],
})
export class DevpointSideNavComponent implements OnInit {
  @Input() pages: string[] = [];
  @Output() pageChange = new EventEmitter<number>();
  @Input() page = 0;

  constructor() {}

  ngOnInit(): void {}

  onClick(index: number) {
    this.page = index;
    this.pageChange.emit(index);
  }
}
