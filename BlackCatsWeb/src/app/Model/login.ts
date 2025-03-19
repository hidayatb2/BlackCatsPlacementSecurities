import { UserRole } from "../Enums/user-role";

export class LoginResponse {
   Id!: string;
   Name!:string
   Email!:string
   ContactNo!:string
   User!:UserRole
   Token!:string
}

export class LoginRequest{
   email!:string
   password!:string
}
