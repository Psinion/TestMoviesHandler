import { mainConfig } from '@/mainConfig';

type BodyMethodType = 'POST' | 'PUT' | 'PATCH' | 'DELETE' | 'HEAD' | 'OPTIONS';
type MethodType = BodyMethodType | 'GET';

export interface IHeader {
  key: string;
  value: string;
}

export class requestor {
  private baseUrl: string;

  constructor(apiUrl?: string) {
    this.baseUrl = apiUrl ?? mainConfig.apiBaseUrl;
  }

  private async request<TResponse>(
    input: RequestInfo,
    method: MethodType,
    extraHeaders?: IHeader[],
    body?: string
  ): Promise<TResponse> {
    const headers: Record<string, string> = {};

    if (extraHeaders) {
      extraHeaders.forEach(x => (headers[x.key] = x.value));
    }

    const params = {
      method,
      headers,
      body
    };

    const request = new Request(`${this.baseUrl}/${input}`, params);
    const response = await fetch(request);

    if (!response.ok) {
      if (response.status == 400) {
        const msg = await response.text();
        throw new Error(msg);
      }
    }

    const data = (await response.json()) as TResponse;
    return data;
  }

  async get<TResponse>(input: RequestInfo, extraHeaders?: IHeader[]): Promise<TResponse> {
    return await this.request<TResponse>(input, 'GET', extraHeaders);
  }

  async post<TRequest, TResponse>(
    input: RequestInfo,
    method: BodyMethodType,
    body: TRequest,
    extraHeaders?: IHeader[]
  ): Promise<TResponse> {
    const bodyParam = JSON.stringify(body);

    if (!extraHeaders) {
      extraHeaders = [];
    }

    extraHeaders.push({ key: 'Content-type', value: 'application/json' });

    return await this.request<TResponse>(input, method, extraHeaders, bodyParam);
  }
}

export const mainRequestor = new requestor();
