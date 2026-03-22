var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
// src/services/auth.service.ts
import { apiClient } from '../core/api-client';
export const AuthService = {
    login: (loginData) => __awaiter(void 0, void 0, void 0, function* () {
        // এটি সরাসরি আপনার ব্যাকএন্ড এপিআই (https://localhost:7290/api/auth/login) কল করবে
        return yield apiClient.request('/api/auth/login', 'POST', loginData);
    })
};
