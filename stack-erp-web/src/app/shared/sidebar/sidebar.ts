import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-sidebar',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './sidebar.html',
  styleUrls: ['./sidebar.scss']
})
export class Sidebar {
  @Input() collapsed = false;

  menuItems = [
    { path: '/dashboard', icon: 'bi-speedometer2', label: 'Dashboard' },
    { path: '/vendas', icon: 'bi-cart-check', label: 'Vendas' },
    { path: '/estoque', icon: 'bi-box-seam', label: 'Estoque' },
    { path: '/clientes', icon: 'bi-people', label: 'Clientes' },
    { path: '/financeiro', icon: 'bi-cash-stack', label: 'Financeiro' },
    { path: '/relatorios', icon: 'bi-bar-chart', label: 'Relatórios' },
  ];
}