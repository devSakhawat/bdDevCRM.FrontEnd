// src/services/auth.service.ts
import { apiClient } from '../core/api-client';
import { IApiResponse } from '../types/api-response';

export const AuthService = {
  login: async (loginData: any): Promise<IApiResponse<any>> => {
    // এটি সরাসরি আপনার ব্যাকএন্ড এপিআই (https://localhost:7290/api/auth/login) কল করবে
    return await apiClient.request<any>('/api/auth/login', 'POST', loginData);
  }
};