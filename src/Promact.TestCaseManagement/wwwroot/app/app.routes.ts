import { Routes } from '@angular/router';
import { NotFoundComponent } from './notfound.component';

export const appRoutes: Routes = [
    { path: '', redirectTo: '/dashboard', pathMatch: 'full' },
    { path: '404', component: NotFoundComponent },
    { path: '**', redirectTo: '/404' }
]