import { Component, inject } from '@angular/core';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { ApiService } from '../../core/services/api.service';
import { Device } from '../../shared/models/device';

@Component({
  selector: 'app-device-details',
  imports: [RouterLink],
  templateUrl: './device-details.component.html',
  styleUrl: './device-details.component.css'
})
export class DeviceDetailsComponent{
  private route = inject(ActivatedRoute);
  private apiService = inject(ApiService);
  device: Device | null = null;

  ngOnInit(): void{
    const id = Number(this.route.snapshot.paramMap.get('id'));
    if(id){
      this.apiService.getDeviceById(id).subscribe({
        next: (data) => this.device = data,
        error: (err) => console.error('Could not load device', err)
      });
    }
  }
}
