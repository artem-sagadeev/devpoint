import {
  Component,
  EventEmitter,
  Input,
  OnInit,
  Output,
  ViewChild,
} from '@angular/core';

@Component({
  selector: 'app-devpoint-upload-image',
  templateUrl: './devpoint-upload-image.component.html',
  styleUrls: ['./devpoint-upload-image.component.css'],
})
export class DevpointUploadImageComponent implements OnInit {
  dragover: boolean = false;
  image?: File;
  coverUrl?: string;
  bgImageUrl?: string;
  @ViewChild('fileDropRef') fileDropRef?: HTMLInputElement;
  @ViewChild('fileDropRef2') fileDropRef2?: HTMLInputElement;

  @Input() background: boolean = true;
  @Input() label?: string;
  @Input() description?: string;
  @Input() buttonLabel?: string;
  @Input() currentImagePath?: string;

  _noMargin = false;

  @Input()
  set noMargin(value: boolean | '') {
    this._noMargin = value === '' || value;
  }
  get noMargin(): boolean {
    return this._noMargin;
  }

  private _fullWidth: boolean = false;

  @Input()
  set fullWidth(value: boolean | '') {
    this._fullWidth = value === '' || value;
  }
  get fullWidth(): boolean {
    return this._fullWidth;
  }

  @Output() fileChange = new EventEmitter<File>();

  constructor() {}

  ngOnInit(): void {}

  onFileDropped(event: FileList) {
    this.image = event[0];
    const reader = new FileReader();
    this.dragover = false;

    reader.onload = (event: any) => {
      this.coverUrl = event.target.result;
      this.bgImageUrl = `url(${this.coverUrl})`;
      this.fileChange.emit(this.image);
    };

    reader.onerror = (event: any) => {
      console.log('File could not be read: ' + event.target.error.code);
    };

    reader.readAsDataURL(this.image);
  }

  onFileChanged(event?: HTMLInputElement) {
    if (event?.files) this.onFileDropped(event.files);
  }
}
