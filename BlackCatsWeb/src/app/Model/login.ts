import { UserRole } from "../Enums/user-role";

export class LoginResponse {
   id!: string;
   name!:string
   email!:string
   contactNo!:string
   user!:UserRole
   token!:string
}

export class LoginRequest{
   email!:string
   password!:string
}
