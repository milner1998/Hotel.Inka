import { Route } from '@angular/router';
import { initialDataResolver } from 'app/app.resolvers';
import { LayoutComponent } from 'app/shared/components/layout/layout.component';

export const appRoutes: Route[] = [

    { path: '', pathMatch: 'full', redirectTo: 'admin' },

    { path: 'signed-in-redirect', pathMatch: 'full', redirectTo: 'admin' },

    {
        path: '',

        component: LayoutComponent,
        data: {
            layout: 'empty'
        },

    },

    // // Auth routes for authenticated users
    {
        path: '',

        component: LayoutComponent,
        data: {
            layout: 'empty'
        },
    

    },

    // // Landing routes
    {
        path: '',
        component: LayoutComponent,
        data: {
            layout: 'empty'
        },

    },

    // Admin routes
    {
        path: 'admin',
        
        component: LayoutComponent,
        resolve: {
            initialData: initialDataResolver,
  
        },
        children: [
            {
                path: '',
                loadChildren: () => import('./modules/admin/admin.module').then(m => m.AdminModule)
            },
        ]
    },
    {
        path: '**',
        pathMatch: 'full',
        redirectTo: 'admin',
    },
];
