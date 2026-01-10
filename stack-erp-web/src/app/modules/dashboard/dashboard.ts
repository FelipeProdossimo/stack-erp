import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';

@Component({
  selector: 'stack-dashboard',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './dashboard.html',
  styleUrl: './dashboard.scss',
})
export class Dashboard {

  cards: DashboardCard[] = [
    {
      title: 'Faturamento',
      value: '245.389',
      variation: 12.5,
      variationLabel: 'vs período anterior',
      type: 'currency'
    },
    {
      title: 'Clientes',
      value: '1.258',
      variation: 8.2,
      variationLabel: 'últimos 30 dias',
      type: 'number'
    },
    {
      title: 'Pedidos',
      value: '342',
      variation: 5.1,
      variationLabel: 'últimos 30 dias',
      type: 'number'
    },
    {
      title: 'Produtos',
      value: '1.845',
      variation: 3.7,
      variationLabel: 'cadastrados',
      type: 'number'
    }
  ];

  formatValue(card: DashboardCard) {
    if (card.type === 'currency') return `R$ ${card.value}`;
    if (card.type === 'percent') return `${card.value}%`;
    return card.value;
  }

  variationClass(value: number) {
    return value >= 0 ? 'positive' : 'negative';
  }
}

export interface DashboardCard {
  title: string;
  value: string;
  variation: number;
  variationLabel: string;
  type: 'currency' | 'number' | 'percent';
}