import { Injectable } from '@angular/core';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root',
})
export class AppService {
  constructor(private apiService: ApiService) {}
}
