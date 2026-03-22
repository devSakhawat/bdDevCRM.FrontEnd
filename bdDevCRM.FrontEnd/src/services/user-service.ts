import { apiClient } from '../core/api-client';
import { IApiResponse, IGridEntity } from '../types/api-response';
import { IUserDto } from '../types/user.types';
import { transformKendoRequest } from '../utils/kendo-helper';

export const UserService = {
  getUsersForGrid: async (options: any): Promise<IApiResponse<IGridEntity<IUserDto>>> => {
    const payload = transformKendoRequest(options);
    return await apiClient.request<IGridEntity<IUserDto>>('/api/user/get-grid', 'POST', payload);
  }
};