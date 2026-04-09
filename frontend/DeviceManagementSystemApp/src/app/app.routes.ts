import { Routes } from '@angular/router';
import { DeviceListComponent } from './features/device-list/device-list.component';
import { DeviceDetailsComponent } from './features/device-details/device-details.component';

export const routes: Routes = [
    { path: 'devices/:id', component: DeviceDetailsComponent},
    { path: 'devices', component: DeviceListComponent},
    { path: '', redirectTo: '/devices', pathMatch: 'full'}
];
