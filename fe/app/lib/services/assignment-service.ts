import type {
  IPagedRequest,
  IPagedResponse,
} from "../interfaces/paged.interface";
import type { IAssignment } from "../interfaces/shift.interface";
import { BaseService } from "./abstractions/base-service";

export interface IAssignmentService {
  getPagedAssignments(
    request: IPagedRequest
  ): Promise<IPagedResponse<IAssignment>>;
  getById(id: number): Promise<IAssignment>;
  create(
    assignment: Omit<IAssignment, "id" | "createdAt" | "createdBy">
  ): Promise<IAssignment>;
  update(id: number, assignment: Partial<IAssignment>): Promise<IAssignment>;
  delete(id: number): Promise<void>;
}

export class AssignmentService
  extends BaseService
  implements IAssignmentService
{
  public constructor() {
    super("phanca");
  }

  public async getPagedAssignments(
    request: IPagedRequest
  ): Promise<IPagedResponse<IAssignment>> {
    const result = await this.GET<IPagedResponse<IAssignment>>({
      url: "",
      params: request,
    });
    return result;
  }

  public async getById(id: number): Promise<IAssignment> {
    const result = await this.GET<IAssignment>({ url: `${id}` });
    return result;
  }

  public async create(
    assignment: Omit<IAssignment, "id" | "createdAt" | "createdBy">
  ): Promise<IAssignment> {
    const result = await this.POST<IAssignment>({
      url: "",
      body: assignment,
    });
    return result;
  }

  public async update(
    id: number,
    assignment: Partial<IAssignment>
  ): Promise<IAssignment> {
    const result = await this.PUT<IAssignment>({
      url: `${id}`,
      body: assignment,
    });
    return result;
  }

  public async delete(id: number): Promise<void> {
    await this.DELETE({ url: `${id}` });
  }
}
