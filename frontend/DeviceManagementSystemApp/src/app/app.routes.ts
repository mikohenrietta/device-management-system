import { Routes } from '@angular/router';
import { DeviceListComponent } from './features/device-list/device-list.component';

export const routes: Routes = [
    { path: 'devices', component: DeviceListComponent},
    { path: '', redirectTo: '/devices', pathMatch: 'full'}
];
