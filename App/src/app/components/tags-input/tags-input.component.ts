import {
  Component,
  ElementRef,
  EventEmitter,
  Input,
  OnInit,
  Output,
  ViewChild,
} from '@angular/core';
import { COMMA, ENTER } from '@angular/cdk/keycodes';
import { FormControl } from '@angular/forms';
import { map, Observable, startWith } from 'rxjs';
import { Tag } from '../../models/tag';
import { MatChipInputEvent } from '@angular/material/chips';
import { MatAutocompleteSelectedEvent } from '@angular/material/autocomplete';

@Component({
  selector: 'app-tags-input',
  templateUrl: './tags-input.component.html',
  styleUrls: ['./tags-input.component.css'],
})
export class TagsInputComponent implements OnInit {
  separatorKeysCodes: number[] = [ENTER, COMMA];
  tagsCtrl = new FormControl('');
  filteredTags?: Observable<Tag[]>;
  @Input() tags: Tag[] = [];
  allTags: Tag[] = [
    {
      name: 'tag 1',
    },
    {
      name: 'sas',
    },
    {
      name: 'ses',
    },
    {
      name: 'kek',
    },
  ];

  @Output() tagsChange = new EventEmitter<Tag[]>();

  @ViewChild('tagsInput') tagsInput?: ElementRef<HTMLInputElement>;

  constructor() {}

  add(event: MatChipInputEvent): void {
    const value = (event.value || '').trim();

    if (value) {
      this.tags.push({ name: value });
      this.tagsChange.emit(this.tags);
    }

    event.chipInput!.clear();
    this.tagsCtrl.setValue(null);
  }

  remove(index: number): void {
    if (index >= 0) {
      this.tags.splice(index, 1);
      this.tagsChange.emit(this.tags);
    }
  }

  selected(event: MatAutocompleteSelectedEvent): void {
    this.tags.push({ name: event.option.viewValue });
    this.tagsChange.emit(this.tags);
    this.tagsInput!.nativeElement.value = '';
    this.tagsCtrl.setValue(null);
  }

  private _filter(value: string): Tag[] {
    const filterValue = value.toLowerCase();

    return this.allTags.filter((tag) =>
      tag.name.toLowerCase().includes(filterValue),
    );
  }

  ngOnInit(): void {
    this.filteredTags = this.tagsCtrl.valueChanges.pipe(
      startWith(null),
      map((tag: string | null) =>
        tag ? this._filter(tag) : this.allTags.slice(),
      ),
    );
  }
}
