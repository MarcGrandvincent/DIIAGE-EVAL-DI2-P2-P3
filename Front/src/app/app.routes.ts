import { Routes } from '@angular/router';
import {PasswordListComponent} from './password-list/password-list.component';
import {ApplicationListComponent} from './application-list/application-list.component';
import {AddPasswordComponent} from './add-password/add-password.component';

export const routes: Routes = [
  {
    path: 'passwords',
    component: PasswordListComponent,
  },
  {
    path: 'applications',
    component: ApplicationListComponent,
  },
  {
    path: 'passwords/create',
    component: AddPasswordComponent
  },
  {
    path: '',
    redirectTo: 'applications',
    pathMatch: 'full'
  }
];
