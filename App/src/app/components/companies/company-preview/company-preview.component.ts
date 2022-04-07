import { Component, Input, OnInit } from '@angular/core';
import { Company } from 'src/app/models/company';

@Component({
  selector: 'app-company-preview',
  templateUrl: './company-preview.component.html',
  styleUrls: ['./company-preview.component.css']
})
export class CompanyPreviewComponent implements OnInit {
  @Input() company: Company = new Company();

  constructor() { }

  ngOnInit(): void {
  }

}
