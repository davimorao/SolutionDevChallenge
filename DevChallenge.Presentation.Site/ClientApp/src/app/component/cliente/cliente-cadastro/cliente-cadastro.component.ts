import { Component } from '@angular/core';
import { ClienteService } from '../../../../app/service/cliente.service';
import { FormGroup, FormControl, FormBuilder, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { ClienteModel } from '../cliente.model';

@Component({
  selector: 'app-cliente-cadastro',
  templateUrl: './cliente-cadastro.component.html'
})
/** cliente-cadastro component*/
export class ClienteCadastroComponent {
  id: string;
  public cadastroCliente: FormGroup;

  constructor(private formBuilder: FormBuilder,
    private clienteService: ClienteService,
    private router: Router,
    private toastr: ToastrService,
    private route: ActivatedRoute) {

    this.id = this.route.snapshot.paramMap.get('id');
    this.cadastroCliente = this.formBuilder.group({
      id: this.id,
      nome: ['', Validators.required],
      dataNascimento: ['', Validators.required],
      cpf: ['', Validators.required],
      rg: ['', Validators.required],
      facebook: ['', Validators.required],
      linkedin: ['', Validators.required],
      twitter: ['', Validators.required],
      instagram: ['', Validators.required],
      endereco: this.formBuilder.group({
        cep: ['', Validators.required],
        logradouro: ['', Validators.required],
        numero: ['', Validators.required],
        bairro: ['', Validators.required],
        cidade: ['', Validators.required],
        estado: ['', Validators.required],
      }),
      telefone: this.formBuilder.group({
        residencial: ['', Validators.required],
        celular: ['', Validators.required],
      })
    });


    if(this.id !== null){
      this.clienteService.listarPorId(this.id).subscribe(x => {
        this.atualizaFormulario(x);
      });
    }
  }

  salvar(): void {
    console.log(this.cadastroCliente.value)
    debugger
    if (this.id == null) {
      this.cadastroCliente.get('id').setValue('0')
      this.clienteService.salvar(this.cadastroCliente.value).subscribe(x => {
        this.router.navigate(['/Cliente']);
        this.toastr.success('Cliente adicionado com êxito.');

      }, error => {
        console.log(error)
        this.toastr.error(`Ocorreu uma exceção: ${error.error}`)
      })
    }
    else {
      this.clienteService.editar(this.id, this.cadastroCliente.value).subscribe(x => {
        this.router.navigate(['/Cliente']);
        this.toastr.success('Cliente editado com êxito.');

      }, error => {
        this.toastr.error(`Ocorreu uma exceção: ${error.error}`)
      });
    }
  }

  buscarCep() {
    this.clienteService.buscarCep(this.cadastroCliente.get('endereco').get('cep').value).subscribe(x => {
      this.cadastroCliente.get('endereco').patchValue({
        logradouro: x.logradouro,
        bairro: x.bairro,
        cidade: x.localidade,
        estado: x.uf,
      });
      this.toastr.success('Endereço carregado com êxito.');
    }, error => {
      this.toastr.error(`Ocorreu uma exceção: ${error.error}`)
    });
  }

  atualizaFormulario(cliente: any): void {
    this.cadastroCliente.patchValue({
      nome: cliente.nome,
      dataNascimento: cliente.dataNascimento,
      cpf: cliente.cpf,
      rg: cliente.rg,
      facebook: cliente.facebook,
      linkedin: cliente.linkedin,
      twitter: cliente.twitter,
      instagram: cliente.instagram,
      endereco: {
        cep: cliente.endereco.cep,
        logradouro: cliente.endereco.logradouro,
        numero: cliente.endereco.numero,
        bairro: cliente.endereco.bairro,
        cidade: cliente.endereco.cidade,
        estado: cliente.endereco.estado
      },
      telefone: {
        residencial: cliente.telefone.residencial,
        celular: cliente.telefone.celular
      }
    });
  }

  // listarCliente(id: string): void {
  //   debugger;
  //   this.clienteService.listarPorId(id).subscribe(x => {
  //     console.log(x);
  //     this.clienteViewModel = x;
  //     this.clienteID = x.id;
  //   });
  // }
}
