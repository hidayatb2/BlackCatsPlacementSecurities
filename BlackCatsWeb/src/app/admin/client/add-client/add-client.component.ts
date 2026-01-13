import { Component } from '@angular/core';
import { ClientRequest } from '../../../Model/client';
import { AccountService } from '../../../Services/account.service';
import { ClientService } from '../../../Services/client.service';
import { ToasterService } from '../../../Services/toaster-service';
import { LoginResponse } from '../../../Model/login';

@Component({
  selector: 'bcss-add-client',
  templateUrl: './add-client.component.html',
  styleUrl: './add-client.component.scss',
})
export class AddClientComponent {
  clientRequest: ClientRequest = new ClientRequest();
  user!:LoginResponse 
  constructor(private accountService: AccountService,private clientService:ClientService,private toasterService:ToasterService) {}

  openModal() {
    const myModalElement = document.getElementById(
      'my_modal_7'
    ) as HTMLDialogElement;
    myModalElement.showModal();
  }

  closeModal() {
    const modal = document.getElementById('my_modal_7') as HTMLDialogElement;
    if (modal && modal.open) {
      modal.close();
    }
  }
  addClient() {
    this.user=this.accountService.getCurrentUser()
    if (this.user.id !==null) {
      console.log(this.user.id)
      let formData = new FormData();
      formData.append('name', this.clientRequest.name);
      formData.append('contactNo', this.clientRequest.contactNo);
      formData.append('address', this.clientRequest.address);
      formData.append('agreementDate', this.clientRequest.agreementDate);
      formData.append(
        'securityDeposit',
        this.clientRequest.securityDeposit.toString()
      );
      formData.append('userId', this.user.id);
      const fileInput = document.querySelector(
        '#fileUpload'
      ) as HTMLInputElement;
      if (fileInput.files && fileInput.files[0]) {
        formData.append('agreementDocument', fileInput.files[0]);
      }
      this.clientService.AddClient(formData).subscribe({
        next:(res)=>{
          this.toasterService.fireSuccessSwal('Client Added Successfully');
          this.clientService.GetAllClient()
        },
        error:(err)=>{
          this.toasterService.fireErrorSwal(err.message);
        }
      })
    }

  }
}
