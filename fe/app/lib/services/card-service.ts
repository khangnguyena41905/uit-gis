import type {
  IPagedRequest,
  IPagedResponse,
} from "../interfaces/paged.interface";
import type { ICard } from "../interfaces/card.interface";
import { BaseService } from "./abstractions/base-service";

export interface ICardService {
  getPagedCards(request: IPagedRequest): Promise<IPagedResponse<ICard>>;
  getById(id: string): Promise<ICard>;
  create(request: ICard): Promise<ICard>;
  delete(id: number): Promise<ICard>;
}

export class CardService extends BaseService implements ICardService {
  public constructor() {
    super("thetu");
  }

  public async getPagedCards(
    request: IPagedRequest,
  ): Promise<IPagedResponse<ICard>> {
    const result = await this.GET<IPagedResponse<ICard>>({
      url: "",
      params: request,
    });
    return result;
  }

  public async getById(id: string): Promise<ICard> {
    const result = await this.GET<ICard>({ url: `${id}` });
    return result;
  }

  public async create(request: ICard): Promise<ICard> {
    const result = await this.POST<ICard>({ url: ``, body: request });
    return result;
  }

  public async delete(id: number): Promise<ICard> {
    const result = await this.DELETE<ICard>({ url: `${id}` });
    return result;
  }
}
