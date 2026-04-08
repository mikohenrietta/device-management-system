import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Device } from '../../shared/models/device';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  private readonly baseUrl = 'https://localhost:7218/api'
  private http = inject(HttpClient);

  getDevicesWithAssignments(): Observable<Device[]> {
    return this.http.get<Device[]>(`${this.baseUrl}/Devices/with-users`);

  }
}
