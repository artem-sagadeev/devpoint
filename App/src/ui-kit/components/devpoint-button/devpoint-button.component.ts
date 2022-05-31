import { Attribute, Component, Input, OnInit } from '@angular/core';

export enum DevpointButtonStyle {
  Main = 'main',
  White = 'white',
  Black = 'black',
  TransparentWhite = 'transparent-white',
  TransparentBlack = 'transparent-black',
}

@Component({
  selector: 'app-devpoint-button',
  templateUrl: './devpoint-button.component.html',
  styleUrls: ['./devpoint-button.component.css'],
})
export class DevpointButtonComponent implements OnInit {
  @Input() bold?: boolean = true;

  @Input() maxWidth?: number;
  
  private _autoWidth: boolean = false;

  @Input()
  set autoWidth(value: boolean | '') {
    this._autoWidth = value === '' || value;
  }
  get autoWidth(): boolean {
    return this._autoWidth;
  }

  devpointStyleClassMap?: Record<string, boolean>;

  constructor(
    @Attribute('type') public type: string = 'submit',
    @Attribute('devpoint-style')
    public devpointStyle?: `${DevpointButtonStyle}`,
  ) {}

  ngOnInit(): void {
    if(!this.devpointStyle)
    this.devpointStyle = DevpointButtonStyle.Main;

    this.devpointStyleClassMap = {};
    for (const value of Object.values(DevpointButtonStyle)) {
      this.devpointStyleClassMap[`style-${value}`] =
        this.devpointStyle === value;
    }
  }
}
