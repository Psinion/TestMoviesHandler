import { mainConfig } from '@/main.config';
import { useAuthStore } from '@/modules/auth/authStore';
import { Notify } from 'quasar';

type BodyMethodType = 'POST' | 'PUT' | 'PATCH' | 'DELETE' | 'HEAD' | 'OPTIONS';
type MethodType = BodyMethodType | 'GET';

export interface IHeader {
  key: string;
  value: string;
}

export interface IRequestGetParams {
  extraHeaders?: IHeader[];
  withCredentials?: boolean;
}

export interface IRequestPostParams {
  extraHeaders?: IHeader[];
  withCredentials?: boolean;
  body?: any;
}

export class requestor {
  private baseUrl: string;

  constructor(apiUrl?: string) {
    this.baseUrl = apiUrl ?? mainConfig.apiBaseUrl;
  }

  async get<TResponse>(input: RequestInfo, params: IRequestGetParams = {}): Promise<TResponse> {
    if (!params.extraHeaders) {
      params.extraHeaders = [];
    }

    return await this.request<TResponse>(
      input,
      'GET',
      undefined,
      params.extraHeaders,
      params.withCredentials
    );
  }

  async post<TResponse>(
    input: RequestInfo,
    method: BodyMethodType,
    params: IRequestPostParams = {}
  ): Promise<TResponse> {
    const bodyParam = JSON.stringify(params.body);

    if (!params.extraHeaders) {
      params.extraHeaders = [];
    }

    params.extraHeaders.push({ key: 'Content-type', value: 'application/json' });

    return await this.request<TResponse>(
      input,
      method,
      bodyParam,
      params.extraHeaders,
      params.withCredentials
    );
  }

  private async request<TResponse>(
    input: RequestInfo,
    method: MethodType,
    body?: string,
    extraHeaders?: IHeader[],
    withCredentials: boolean = false,
    canRefreshToken: boolean = true
  ): Promise<TResponse> {
    const headers: Record<string, string> = {};

    if (extraHeaders) {
      extraHeaders.forEach(x => (headers[x.key] = x.value));
    }

    const authStore = useAuthStore();
    const accessToken = authStore.accessToken;
    if (accessToken) {
      headers['AuthToken'] = accessToken;
    }

    const params: RequestInit = {
      method,
      headers,
      credentials: withCredentials ? 'include' : 'omit',
      body
    };

    const request = new Request(`${this.baseUrl}/${input}`, params);
    let response: Response | null = null;
    try {
      response = await fetch(request);
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

    if (!response.ok) {
      if (response.status == 400) {
        const msg = await response.text();
        throw new Error(msg);
      } else if (response.status == 401 && canRefreshToken) {
        const userStore = useAuthStore();
        userStore.checkAuth().then(() => {
          return this.request<TResponse>(input, method, body, extraHeaders, true, false);
        });
      }
    }

    const data = (await response.json()) as TResponse;
    return data;
  }
}

export const mainRequestor = new requestor();
