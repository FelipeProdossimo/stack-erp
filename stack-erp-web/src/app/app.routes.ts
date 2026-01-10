import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: '',
    loadComponent: () => import('./layouts/main-layout/main-layout').then(m => m.MainLayout),
    children: [
      {
        path: '',
        redirectTo: 'dashboard',
        pathMatch: 'full'
      },
      {
        path: 'dashboard',
        loadComponent: () => import('./modules/dashboard/dashboard').then(m => m.Dashboard)
      },
      {
        path: 'vendas',
        loadComponent: () => import('./modules/vendas/vendas').then(m => m.Vendas)
      },
      /*{
        path: 'estoque',
        loadComponent: () => import('./modules/estoque/estoque').then(m => m.EstoqueComponent)
      },
      {
        path: 'clientes',
        loadComponent: () => import('../modules/clientes/clientes').then(m => m.Clientes)
      },
      {
        path: 'financeiro',
        loadComponent: () => import('../modules/financeiro/financeiro').then(m => m.Financeiro)
      }*/
    ]
  },
  {
    path: 'auth',
    loadComponent: () => import('./layouts/auth-layout/auth-layout').then(m => m.AuthLayout),
    children: [
      /*{
        path: 'login',
        loadComponent: () => import('./modules/auth/login/login').then(m => m.Login)
      }*/
    ]
  },
  {
    path: '**',
    redirectTo: '/dashboard'
  }
];