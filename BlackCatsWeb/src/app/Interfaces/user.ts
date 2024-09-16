import { UserRole } from '../Enums/user-role';

export interface User {
  Id: string;
  Name: string;
  Email: string;
  ContactNo: string;
  User: UserRole;
  Token: string;
}
