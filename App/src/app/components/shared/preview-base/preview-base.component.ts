import { Component, Input, OnInit } from '@angular/core';
import { Entity } from 'src/app/models/entity';

@Component({
  selector: 'app-preview-base',
  templateUrl: './preview-base.component.html',
  styleUrls: ['./preview-base.component.css']
})
export class PreviewBaseComponent implements OnInit {
  @Input() link = '';

  private _isLarge: boolean = false;

  @Input('large')
  set isLarge(value: boolean | '') {
    this._isLarge = value === '' || value;
  }
  get isLarge(): boolean {
    return this._isLarge;
  }

  @Input() entity?: Entity;

  constructor() { }

  ngOnInit(): void {
  }

}
