import Axios, {
  AxiosError,
  type AxiosInstance,
  type AxiosResponse,
} from "axios";
import { StorageKey } from "../../constants/local-storage";
import type { ILoginData } from "../../types/login";

export class BaseService {
  private axiosClient: AxiosInstance;
  private get tokenKey(): string {
    if ([null, undefined].indexOf(localStorage[StorageKey.LOGIN_INFO]) > -1) {
      return "";
    }
    const loginInfo = JSON.parse(
      localStorage[StorageKey.LOGIN_INFO],
    ) as ILoginData;
    return `${loginInfo.tokenType} ${loginInfo.token}`;
  }

  protected constructor(baseAPI: string, hasPrefix: boolean = true) {
    let baseURL = import.meta.env.VITE_BASE_URL as string;
    const prefixApi = import.meta.env.VITE_PREFIX_API as string;
    if (baseAPI) {
      baseURL += `${hasPrefix ? String(prefixApi) : ""}${baseAPI}/`;
    }
    this.axiosClient = Axios.create({ baseURL });
  }

  protected async GET<T>(options: IOptions): Promise<T> {
    try {
      const response: AxiosResponse<T> = await this.axiosClient.request<T>({
        method: "GET",
        url: options.url,
        params: options.params,
        headers: {
          Authorization: this.tokenKey,
          "Content-Type": "application/json; charset=utf-8",
        },
      });
      return response.data;
    } catch (error) {
      if (error instanceof AxiosError) {
        this.handleAxiosError(error);
      }
      throw error;
    }
  }

  protected async GET_TRACKING<T>(options: IOptions) {
    const response: AxiosResponse = await this.axiosClient.request({
      method: "GET",
      url: options.url,
      params: options.params,
      headers: {
        Authorization: this.tokenKey,
        "Content-Type": "application/json; charset=utf-8",
      },
    });
    return response.data;
  }

  protected async GET_WITHOUT_TOKEN<T>(options: IOptions): Promise<T> {
    return await this.axiosClient
      .request<T>({
        method: "GET",
        url: options.url,
        params: options.params,
        headers: {
          "Content-Type": "application/json; charset=utf-8",
        },
      })
      .then(({ data }) => data);
  }

  protected async POST<T>(options: IOptions): Promise<T> {
    try {
      const response: AxiosResponse<T> = await this.axiosClient.request<T>({
        method: "POST",
        url: options.url,
        params: options.params,
        data: JSON.stringify(options.body),
        headers: {
          Authorization: this.tokenKey,
          "Content-Type": "application/json; charset=utf-8",
        },
      });
      return response.data;
    } catch (error) {
      if (error instanceof AxiosError) {
        this.handleAxiosError(error);
      }
      throw error;
    }
  }

  protected async POST_WITHOUT_TOKEN<T>(options: IOptions): Promise<T> {
    try {
      const response: AxiosResponse<T> = await this.axiosClient.request<T>({
        method: "POST",
        url: options.url,
        params: options.params,
        data: JSON.stringify(options.body),
        headers: {
          "Content-Type": "application/json; charset=utf-8",
        },
      });
      return response.data;
    } catch (error) {
      if (error instanceof AxiosError) {
        this.handleAxiosError(error);
      }
      throw error;
    }
  }

  protected async POST_FORMDATA<T>(
    options: IOptions,
    onUploadProgress?: any,
  ): Promise<T> {
    try {
      const response: AxiosResponse<T> = await this.axiosClient.request<T>({
        method: "POST",
        url: options.url,
        params: options.params,
        data: options.body,
        headers: {
          Authorization: this.tokenKey,
          // "Content-Type": "application/json; charset=utf-8",
        },
        onUploadProgress,
      });

      return response.data;
    } catch (error) {
      if (error instanceof AxiosError) {
        this.handleAxiosError(error);
      }
      throw error;
    }
  }
  protected async POST_BLOB<T>(options: IOptions): Promise<any> {
    try {
      const response: AxiosResponse<T> = await this.axiosClient.request<any>({
        method: "POST",
        url: options.url,
        params: options.params,
        data: JSON.stringify(options.body),
        headers: {
          Authorization: this.tokenKey,
          "Content-Type": "application/json; charset=utf-8",
        },
        responseType: "blob",
      });

      return response.data;
    } catch (error) {
      if (error instanceof AxiosError) {
        this.handleAxiosError(error);
      }
      throw error;
    }
  }

  protected async GET_BLOB<T>(options: IOptions): Promise<any> {
    try {
      const response: AxiosResponse<T> = await this.axiosClient.request<any>({
        method: "GET",
        url: options.url,
        params: options.params,
        headers: {
          Authorization: this.tokenKey,
          "Content-Type": "application/json; charset=utf-8",
        },
        responseType: "blob",
      });

      return response.data;
    } catch (error) {
      if (error instanceof AxiosError) {
        this.handleAxiosError(error);
      }
      throw error;
    }
  }

  protected async PUT<T>(options: IOptions): Promise<T> {
    try {
      const response: AxiosResponse<T> = await this.axiosClient.request<T>({
        method: "PUT",
        url: options.url,
        params: options.params,
        data: JSON.stringify(options.body),
        headers: {
          Authorization: this.tokenKey,
          "Content-Type": "application/json; charset=utf-8",
        },
      });
      return response.data;
    } catch (error) {
      if (error instanceof AxiosError) {
        this.handleAxiosError(error);
      }
      throw error;
    }
  }

  protected async DELETE<T>(options: IOptions): Promise<T> {
    try {
      const response: AxiosResponse<T> = await this.axiosClient.request<T>({
        method: "DELETE",
        url: options.url,
        params: options.params,
        data: JSON.stringify(options.body),
        headers: {
          Authorization: this.tokenKey,
          "Content-Type": "application/json; charset=utf-8",
        },
      });
      return response.data;
    } catch (error) {
      if (error instanceof AxiosError) {
        this.handleAxiosError(error);
      }
      throw error;
    }
  }

  private handleAxiosError(error: AxiosError) {
    if (
      error.response &&
      (error.response.status === 403 || error.response.status === 401)
    ) {
      window.localStorage.removeItem(StorageKey.LOGIN_INFO);
      window.localStorage.removeItem(StorageKey.ROLE);
      window.location.href = "/login";
    }
  }
}

interface IParams {
  [key: string]: any;
}

interface IOptions {
  url: string;
  params?: IParams;
  body?: any;
}
