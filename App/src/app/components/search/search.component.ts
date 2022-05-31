import { Component, OnInit } from '@angular/core';
import { Developer } from 'src/app/models/developer';
import { Project } from 'src/app/models/project';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css'],
})
export class SearchComponent implements OnInit {
  developers = [
    {
      id: '1',
      name: 'Developer 1',
      tags: [{ name: 'Tag 1' }],
    } as Developer,
    {
      id: '2',
      name: 'Developer 2',
      tags: [{ name: 'Tag 2' }],
    } as Developer,
    {
      id: '3',
      name: 'Developer 3',
      tags: [{ name: 'Tag 3' }],
    } as Developer,
  ] as any;
  projects = [
    {
      id: '1',
      name: 'Project 1',
      tags: [{ name: 'Tag 1' }],
    } as Project,
    {
      id: '2',
      name: 'Project 2',
      tags: [{ name: 'Tag 2' }],
    } as Project,
    {
      id: '3',
      name: 'Project 3',
      tags: [{ name: 'Tag 3' }],
    } as Project,
  ];
  companies = [
    {
      id: '1',
      name: 'Company 1',
      tags: [{ name: 'Tag 1' }],
    },
    {
      id: '2',
      name: 'Company 2',
      tags: [{ name: 'Tag 2' }],
    },
    {
      id: '3',
      name: 'Company 3',
      tags: [{ name: 'Tag 3' }],
    },
  ];

  data = this.developers;

  searchingDevelopers: boolean = true;
  searchingProjects: boolean = true;
  searchingCompanies: boolean = true;

  constructor() {}

  ngOnInit(): void {}

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
}
