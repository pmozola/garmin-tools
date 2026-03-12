import { Routes } from '@angular/router';
import { Login } from './pages/login/login';
import { authGuard } from './guards/auth-guard';
import { Courses } from './pages/courses/courses';
import { ChangeDevice } from './pages/change-device/change-device';

export const routes: Routes = [
    {
        path: 'login',
        component: Login,
    },
    {
        path: '',
        canActivateChild: [authGuard],
        children: [
            {path: 'courses', component: Courses},
            {path: 'fitfile/change-device', component: ChangeDevice},
        ],
    },
];
