var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
class ApiClient {
    constructor() {
        this.BASE_URL = "https://localhost:7290";
    }
    static getInstance() {
        if (!ApiClient.instance)
            ApiClient.instance = new ApiClient();
        return ApiClient.instance;
    }
    /**
     * Generic request handler that returns a full IApiResponse object
     */
    request(endpoint_1) {
        return __awaiter(this, arguments, void 0, function* (endpoint, method = 'GET', body = null) {
            const url = endpoint.startsWith('http') ? endpoint : `${this.BASE_URL}${endpoint}`;
            const headers = new Headers({
                'Content-Type': 'application/json',
                'X-Correlation-ID': crypto.randomUUID()
            });
            const config = { method, headers };
            if (body && method !== 'GET')
                config.body = JSON.stringify(body);
            const response = yield fetch(url, config);
            return yield response.json();
        });
    }
}
export const apiClient = ApiClient.getInstance();
