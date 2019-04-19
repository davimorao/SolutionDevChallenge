import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ClienteModel } from '../component/cliente/cliente.model';
import { ToastrService } from 'ngx-toastr';
import { EnderecoModel } from '../component/cliente/endereco.model';

@Injectable()
export class ClienteService {
  private myApiUrl : string
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl : string)
  {
    this.myApiUrl = this.baseUrl + 'Cliente';
  }

  listar(): Observable<ClienteModel[]> {
    return this.http.get<ClienteModel[]>(this.myApiUrl)
  }

  listarPorId(id: string): Observable<ClienteModel> {
    return this.http.get<ClienteModel>(`${this.myApiUrl}/${id}`)
  }

  listarPorNome(nome: string, cpf: string, rg: string): Observable<ClienteModel[]> {
    return this.http.get<ClienteModel[]>(`${this.myApiUrl}/GetByName/${nome}/${cpf}/${rg}`)
  }

  salvar(cliente: ClienteModel, ): Observable<ClienteModel> {
    return this.http.post<ClienteModel>(`${this.myApiUrl}`, cliente)
  }

  editar(id: string, cliente: ClienteModel): Observable<ClienteModel> {
    return this.http.put<ClienteModel>(`${this.myApiUrl}/${id}`, cliente)
  }

  excluir(id: string): Observable<number> {
    return this.http.delete<number>(`${this.myApiUrl}/${id}`);
  }

  buscarCep(cep: string) : Observable<EnderecoModel> {
    cep = cep.replace('-', '')
    return this.http.get<EnderecoModel>('https://viacep.com.br/ws/' + cep + '/json/')
  }
}
