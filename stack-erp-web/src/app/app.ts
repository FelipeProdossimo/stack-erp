import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';
import { TranslateModule, TranslateService } from '@ngx-translate/core';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, RouterOutlet, TranslateModule],
  templateUrl: './app.html',
  styleUrls: ['./app.scss']
})
export class App {
  title = 'stack-erp-web';

  constructor(
    private translate: TranslateService,
    private toastr: ToastrService
  ) {
    // Configura idioma padrão
    this.translate.setDefaultLang('pt');
    this.translate.use('pt');
    
    // Mostra mensagem de boas-vindas
    this.showWelcome();
  }

  private showWelcome(): void {
    setTimeout(() => {
      this.toastr.success('Sistema ERP inicializado com sucesso!', 'Bem-vindo');
    }, 1000);
  }
}