import { Component, OnInit } from '@angular/core';
import { ClientService } from '../../../Services/client.service';
import { AccountService } from '../../../Services/account.service';
import { ClientResponse, ClientUpdateRequest } from '../../../Model/client';

@Component({
  selector: 'bcss-get-client',
  templateUrl: './get-client.component.html',
  styleUrl: './get-client.component.scss',
})
export class GetClientComponent implements OnInit {
  clients: ClientResponse[] = [];
  clientRequest:ClientUpdateRequest=new ClientUpdateRequest();
  constructor(
    private clientService: ClientService,
    private accountService: AccountService
  ) {}
  ngOnInit(): void {
   this.getAllClients();
  }
  
  getAllClients() {
    this.clientService.GetAllClient().subscribe({
      next: (res) => {
        console.log(res)
        this.clients = res.result;
        console.log(this.clients)
      },
      error:(err)=>{
        console.log(err)
      }
    });
  }
  openModal() {
    const myModalElement = document.getElementById(
      'UpdateClientModal'
    ) as HTMLDialogElement;
    myModalElement.showModal();
  }

  closeModal() {
    const modal = document.getElementById('UpdateClientModal') as HTMLDialogElement;
    if (modal && modal.open) {
      modal.close();
    }
  }
}
