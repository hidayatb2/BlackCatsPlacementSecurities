export class ClientRequest {
    name!:string;
    address!:string;
    contactNo!:string;
    agreementDate!:string;
    securityDeposit!:number;
    userId!:string
}

export class ClientResponse{
    name!:string;
    address!:string;
    contactNo!:string;
    agreementDate!:string;
    securityDeposit!:number;
    DocumentPath!:string;
}

export class ClientUpdateRequest{
    id!:string
    name!:string;
    address!:string;
    contactNo!:string;
    securityDeposit!:number;
}

