export interface IErrorDetails {
    message: string;
    code: string;
    validationErrors?: Record<string, string[]>;
    stackTrace?: string;
}

export interface IApiResponse<T> {
  statusCode: number;
  success: boolean;
  message: string;
  version: string;
  timestamp: string;
  data: T;
  error?: IErrorDetails;
}

export interface IGridEntity<T> {
  items: T[];
  totalCount: number;
  totalPages: number;
  startIndex: number;
  endIndex: number;
}