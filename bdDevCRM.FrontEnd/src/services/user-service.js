var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
import { apiClient } from '../core/api-client';
import { transformKendoRequest } from '../utils/kendo-helper';
export const UserService = {
    getUsersForGrid: (options) => __awaiter(void 0, void 0, void 0, function* () {
        const payload = transformKendoRequest(options);
        return yield apiClient.request('/api/user/get-grid', 'POST', payload);
    })
};
