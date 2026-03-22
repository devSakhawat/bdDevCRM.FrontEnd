import { IApiResponse } from '../types/api-response';

class ApiClient {
  private static instance: ApiClient;
  private readonly BASE_URL = "https://localhost:7290";

  private constructor() { }

  public static getInstance(): ApiClient {
    if (!ApiClient.instance) ApiClient.instance = new ApiClient();
    return ApiClient.instance;
  }

  /**
   * Generic request handler that returns a full IApiResponse object
   */
  public async request<T>(endpoint: string, method: string = 'GET', body: any = null): Promise<IApiResponse<T>> {
    const url = endpoint.startsWith('http') ? endpoint : `${this.BASE_URL}${endpoint}`;
        
    const headers = new Headers({
      'Content-Type': 'application/json',
      'X-Correlation-ID': crypto.randomUUID()
    });

    const config: RequestInit = { method, headers };
    if (body && method !== 'GET') config.body = JSON.stringify(body);

    const response = await fetch(url, config);
    return await response.json();
  }

  /*
  public async request<T>(url: string, method: string = 'GET', body: any = null): Promise<IApiResponse<T>> {
    const headers = new Headers({
      'Content-Type': 'application/json',
      'X-Correlation-ID': crypto.randomUUID()
    });

    const token = localStorage.getItem('accessToken');
    if (token) headers.append('Authorization', `Bearer ${token}`);

    const config: RequestInit = { method, headers };
    if (body && method !== 'GET') config.body = JSON.stringify(body);

    const response = await fetch(url, config);
        
    // Parsing the full response object from your .NET backend
    const result: IApiResponse<T> = await response.json();

    if (!response.ok || !result.success) {
      throw result; // Managed by your Global Exception Middleware in C#
    }

    return result;
  }
  */

}

export const apiClient = ApiClient.getInstance();