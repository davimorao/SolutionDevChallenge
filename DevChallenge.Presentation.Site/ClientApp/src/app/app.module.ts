import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './component/app.component';
import { HttpModule } from '@angular/http';
import { ClienteService } from './service/cliente.service';
import { ClienteCadastroComponent } from './component/cliente/cliente-cadastro/cliente-cadastro.component';
import { ClientePesquisaComponent } from './component/cliente/cliente-pesquisa/cliente-pesquisa.component';
import { CommonModule } from '@angular/common';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { NgxMaskModule } from 'ngx-mask';

@NgModule({
  declarations: [
    AppComponent,
    ClienteCadastroComponent,
    ClientePesquisaComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    HttpModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule, // required animations module
    ToastrModule.forRoot(), // ToastrModule added
    NgxMaskModule.forRoot(),
    RouterModule.forRoot([
      { path: '', redirectTo: 'Cliente', pathMatch: 'full' },
      { path: 'Cliente', component: ClientePesquisaComponent, pathMatch: 'full' },
      { path: 'Cliente/Novo', component: ClienteCadastroComponent, pathMatch: 'full' },
      { path: 'Cliente/Editar/:id', component: ClienteCadastroComponent, pathMatch: 'full' },
    ])
  ],
  providers: [ClienteService],
  bootstrap: [AppComponent]
})
export class AppModule { }
