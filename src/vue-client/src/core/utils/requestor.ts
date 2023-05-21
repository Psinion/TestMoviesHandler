import { mainConfig } from '@/mainConfig';
import { useAuthStore } from '@/modules/auth/authStore';
import { Notify } from 'quasar';

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

  async get<TResponse>(input: RequestInfo, extraHeaders?: IHeader[]): Promise<TResponse> {
    if (!extraHeaders) {
      extraHeaders = [];
    }

    extraHeaders = this.pushAuthHeader(extraHeaders);

    return await this.request<TResponse>(input, 'GET', extraHeaders);
  }

  async post<TResponse>(
    input: RequestInfo,
    method: BodyMethodType,
    // eslint-disable-next-line @typescript-eslint/no-explicit-any
    body?: any,
    extraHeaders?: IHeader[]
  ): Promise<TResponse> {
    const bodyParam = JSON.stringify(body);

    if (!extraHeaders) {
      extraHeaders = [];
    }

    extraHeaders.push({ key: 'Content-type', value: 'application/json' });
    extraHeaders = this.pushAuthHeader(extraHeaders);

    return await this.request<TResponse>(input, method, extraHeaders, bodyParam);
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
    try {
      const response = await fetch(request);

      if (!response.ok) {
        if (response.status == 400) {
          const msg = await response.text();
          throw new Error(msg);
        }
      }

      const data = (await response.json()) as TResponse;
      return data;
    } catch (error) {
      Notify.create({
        type: 'negative',
        message: 'Не удалось получить ответ от сервера',
        position: 'top',
        timeout: 15000,
        progress: true
      });
      throw error;
    }
  }

  private pushAuthHeader(extraHeaders: IHeader[]): IHeader[] {
    const userStore = useAuthStore();
    const token = userStore.token;
    if (token) {
      extraHeaders.push({ key: 'AuthToken', value: token });
    }
    return extraHeaders;
  }
}

export const mainRequestor = new requestor();
