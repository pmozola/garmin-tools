import { Routes } from '@angular/router';
import { Home } from './pages/home/home';
import { Login } from './pages/login/login';
import { authGuard } from './guards/auth-guard';
import { Courses } from './pages/courses/courses';

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
        ],
    },
];
