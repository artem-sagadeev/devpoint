import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProjectMiniPreviewComponent } from './project-mini-preview.component';

describe('ProjectMiniPreviewComponent', () => {
  let component: ProjectMiniPreviewComponent;
  let fixture: ComponentFixture<ProjectMiniPreviewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProjectMiniPreviewComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ProjectMiniPreviewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
