import { UserRole } from "../Enums/user-role";

export class UserResponse{
    id!:string;

    UserName!:string;
   
    Email!:string;
  
    Name!:string
  
    ContactNo!:string
 
    UserRole!:UserRole;

    UserStatus!:number;
   
    CreatedAt!:Date;
}


export class UserRequest{
    name!:string;
    email!:string;
    contactNo!:string;
    userRole!:UserRole;
}