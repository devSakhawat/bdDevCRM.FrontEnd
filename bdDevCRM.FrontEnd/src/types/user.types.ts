// types/user.types.ts

export interface IUserDto {
  userId: number;
  loginId: string;
  userName: string;
  email?: string;
  employeeId?: number;
  hrRecordId?: number;
  isActive: boolean;
  companyId?: number;
  branchId?: number;
  departmentId?: number;
  // Add other fields matching your backend UserDto
}

export interface IUserSaveRequest extends IUserDto {
  password?: string;
  confirmPassword?: string;
}