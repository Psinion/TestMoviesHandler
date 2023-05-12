
type MethodType = 'GET' | 'POST' | 'PUT' | 'PATCH' | 'DELETE' | 'HEAD' | 'OPTIONS'; 

async function request<TOut>(input: RequestInfo, method: MethodType, config: RequestInit) 
  : Promise<TOut> {
    const request = new Request(input, { method: method, ...config });
    const response = await fetch(request);

    if(!response.ok) {
      throw new Error(response.statusText);
    }

    const data = await response.json() as TOut;
    return data;
}

export async function get<TOut>(input: RequestInfo, config?: RequestInit)
  : Promise<TOut> {
  return await request<TOut>(input, 'GET', { ...config });
}

export async function post<TIn, TOut>(input: RequestInfo, body: TIn, config?: RequestInit)
  : Promise<TOut> {
  const init = { 
    body: JSON.stringify(body), 
    'Content-type': 'application/json', 
    ...config 
  };
  return await request<TOut>(input, 'POST', init);
}