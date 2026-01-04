export interface IPagedRequest {
  pageIndex: number;
  pageSize: number;
  searchStr?: string;
}
export interface IPagedResponse<T> {
  totalCount: number;
  pageIndex: number;
  pageSize: number;
  totalPages?: number;
  hasPreviousPage?: boolean;
  hasNextPage?: boolean;
  items: T[];
}
