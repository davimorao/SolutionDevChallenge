import { Component, ViewChild, ElementRef } from '@angular/core';
import { ClienteService } from '../../../../app/service/cliente.service';
import { ClienteModel } from '../cliente.model';

@Component({
  selector: 'app-cliente-pesquisa',
  templateUrl: './cliente-pesquisa.component.html'
})
/** cliente-pesquisa component*/
export class ClientePesquisaComponent {
  @ViewChild('nome') nomeInput: ElementRef;
  public cliente: ClienteModel[]
  /** cliente-pesquisa ctor */
  constructor(private clienteService: ClienteService) {
    this.listar();
  }

  listar(): void {
    let nome: string = 'null'
    let cpf: string = 'null'
    let rg: string = 'null'
    if ((document.getElementById("txtNome") as HTMLInputElement) != undefined && (document.getElementById("txtNome") as HTMLInputElement).value != '') {
      nome = (document.getElementById("txtNome") as HTMLInputElement).value
    }
    if ((document.getElementById("txtCpf") as HTMLInputElement) != undefined && (document.getElementById("txtCpf") as HTMLInputElement).value != '') {
      cpf = (document.getElementById("txtCpf") as HTMLInputElement).value
    }
    if ((document.getElementById("txtRg") as HTMLInputElement) != undefined && (document.getElementById("txtRg") as HTMLInputElement).value != '') {
      rg = (document.getElementById("txtRg") as HTMLInputElement).value
    }
    this.clienteService.listarPorNome(nome, cpf, rg).subscribe(x => {
      this.cliente = x;
    });
  }

  excluirCliente(id: string){
    this.clienteService.excluir(id).subscribe(x => {
      this.listar();
    });
  }
}
