import { UserRole } from '../Enums/user-role';

export interface User {
  id: string;
  name: string;
  email: string;
  contactNo: string;
  userRole: UserRole;
  createdAt: Date
}
