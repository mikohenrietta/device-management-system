import { CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';
import { ApiService } from '../../core/services/api.service';
import { Device } from '../../shared/models/device';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-device-list',
  imports: [CommonModule,RouterLink],
  templateUrl: './device-list.component.html',
  styleUrl: './device-list.component.css'
})
export class DeviceListComponent {
  private apiService = inject(ApiService);
  devices: Device[] = [];

  ngOnInit(): void {
    this.loadDevices();
  }

  loadDevices(): void {
    this.apiService.getDevicesWithAssignments().subscribe({
      next: (data) => {
        this.devices = data;
      },
      error: (err) => console.error('API Error: ', err)
    });
  }
}
