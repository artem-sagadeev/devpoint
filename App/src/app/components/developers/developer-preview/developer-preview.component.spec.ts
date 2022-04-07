import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeveloperPreviewComponent } from './developer-preview.component';

describe('DeveloperPreviewComponent', () => {
  let component: DeveloperPreviewComponent;
  let fixture: ComponentFixture<DeveloperPreviewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DeveloperPreviewComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DeveloperPreviewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
