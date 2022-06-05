import { Component, Input, OnInit } from '@angular/core';
import { Entity, EntityType } from 'src/app/models/entity';

@Component({
  selector: 'app-preview-base',
  templateUrl: './preview-base.component.html',
  styleUrls: ['./preview-base.component.css'],
})
export class PreviewBaseComponent implements OnInit {
  @Input() link = '';
  loading: boolean = true;

  @Input() isOwned: boolean = true;

  private _isLarge: boolean = false;
  entityTypes = EntityType;

  @Input()
  set large(value: boolean | '') {
    this._isLarge = value === '' || value;
  }
  get large(): boolean {
    return this._isLarge;
  }

  @Input() entity?: Entity;

  constructor() {}

  ngOnInit(): void {}

  onLoad() {
    this.loading = false;
  }
}
