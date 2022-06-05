import { Component, OnInit } from '@angular/core';
import { Developer } from 'src/app/models/developer';
import { Project } from 'src/app/models/project';
import { PageEvent } from '@angular/material/paginator';
import { map, Observable, startWith, take } from 'rxjs';
import { FormControl } from '@angular/forms';
import { plainToTyped } from 'type-transformer';
import { Company } from '../../models/company';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css'],
})
export class SearchComponent implements OnInit {
  search?: string;

  control = new FormControl();
  names: string[] = ['sas', 'ses', 'kek'];
  filteredNames?: Observable<string[]>;

  developers = [
    plainToTyped(
      {
        id: '1',
        name: 'Developer 1',
        tags: [{ name: 'Tag 1' }],
      },
      Developer,
    ),
    plainToTyped(
      {
        id: '2',
        name: 'Developer 2',
        tags: [{ name: 'Tag 2' }],
      },
      Developer,
    ),
    plainToTyped(
      {
        id: '3',
        name: 'Developer 3',
        tags: [{ name: 'Tag 3' }],
      },
      Developer,
    ),
  ];
  projects = [
    plainToTyped(
      {
        id: '1',
        name: 'Project 1',
        tags: [{ name: 'Tag 1' }],
      },
      Project,
    ),
    plainToTyped(
      {
        id: '2',
        name: 'Project 2',
        tags: [{ name: 'Tag 2' }],
      },
      Project,
    ),
    plainToTyped(
      {
        id: '3',
        name: 'Project 3',
        tags: [{ name: 'Tag 3' }],
      },
      Project,
    ),
  ];
  companies = [
    plainToTyped(
      {
        id: '1',
        name: 'Company 1',
        tags: [{ name: 'Tag 1' }],
      },
      Company,
    ),
    plainToTyped(
      {
        id: '2',
        name: 'Company 2',
        tags: [{ name: 'Tag 2' }],
      },
      Company,
    ),
    plainToTyped(
      {
        id: '3',
        name: 'Company 3',
        tags: [{ name: 'Tag 3' }],
      },
      Company,
    ),
  ];

  searchingDevelopers: boolean = true;
  searchingProjects: boolean = true;
  searchingCompanies: boolean = true;

  totalCount: number = 90;
  take: number = 10;
  page: number = 0;

  constructor() {}

  ngOnInit(): void {
    this.filteredNames = this.control.valueChanges.pipe(
      startWith(''),
      map((value) => this._filter(value)),
    );
  }

  private _filter(value: string): string[] {
    const filterValue = this._normalizeValue(value);
    return this.names.filter((name) =>
      this._normalizeValue(name).includes(filterValue),
    );
  }

  private _normalizeValue(value: string): string {
    return value.toLowerCase().replace(/\s/g, '');
  }

  onSearchChange() {
    console.log(this.searchingDevelopers);
    console.log(this.searchingProjects);
    console.log(this.searchingCompanies);
  }

  toggleDevelopersSearch() {
    this.searchingDevelopers = !this.searchingDevelopers;
    this.onSearchChange();
  }

  toggleProjectsSearch() {
    this.searchingProjects = !this.searchingProjects;
    this.onSearchChange();
  }

  toggleCompaniesSearch() {
    this.searchingCompanies = !this.searchingCompanies;
    this.onSearchChange();
  }

  onPageChange(event: PageEvent) {
    this.take = event.pageSize;
    this.page = event.pageIndex;
    this.onSearchChange();
  }
}
