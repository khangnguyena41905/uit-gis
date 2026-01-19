import { useEffect, useRef, useState } from "react";
import { ChevronsUpDown } from "lucide-react";

import { Button } from "@/components/ui/button";
import {
  Command,
  CommandEmpty,
  CommandGroup,
  CommandInput,
  CommandItem,
  CommandList,
} from "@/components/ui/command";
import {
  Popover,
  PopoverContent,
  PopoverTrigger,
} from "@/components/ui/popover";

import { unitOfWork } from "~/lib/services/abstractions/unit-of-work";
import type { IDepartment } from "~/lib/interfaces/department.interface";

interface Props {
  value?: number;
  onChange: (value: number) => void;
}

export function DepartmentCombobox({ value, onChange }: Props) {
  const [open, setOpen] = useState(false);
  const [departments, setDepartments] = useState<IDepartment[]>([]);
  const [pageIndex, setPageIndex] = useState(1);
  const [searchStr, setSearchStr] = useState("");
  const [hasMore, setHasMore] = useState(true);
  const [loading, setLoading] = useState(false);

  const listRef = useRef<HTMLDivElement>(null);

  const fetchDepartments = async (
    page: number,
    search: string,
    append = false
  ) => {
    if (loading) return;

    setLoading(true);

    const res = await unitOfWork.departmentService.getPagedDepartments({
      pageIndex: page,
      pageSize: 10,
      searchStr: search,
    });

    if (res) {
      setDepartments((prev) => (append ? [...prev, ...res.items] : res.items));
      setHasMore(res.items.length === 10);
    }

    setLoading(false);
  };

  /** load lần đầu */
  useEffect(() => {
    fetchDepartments(1, "", false);
  }, []);

  /** search */
  const handleSearch = (value: string) => {
    setSearchStr(value);
    setPageIndex(1);
    fetchDepartments(1, value, false);
  };

  /** infinite scroll */
  const handleScroll = () => {
    const el = listRef.current;
    if (!el || loading || !hasMore) return;

    const isBottom = el.scrollTop + el.clientHeight >= el.scrollHeight - 10;

    if (isBottom) {
      const nextPage = pageIndex + 1;
      setPageIndex(nextPage);
      fetchDepartments(nextPage, searchStr, true);
    }
  };

  const selectedDepartment = departments.find((d) => d.id === value);

  return (
    <Popover open={open} onOpenChange={setOpen}>
      <PopoverTrigger asChild>
        <Button
          variant="outline"
          role="combobox"
          className="w-full justify-between"
        >
          {selectedDepartment ? selectedDepartment.tenPB : "Chọn phòng ban"}
          <ChevronsUpDown className="ml-2 h-4 w-4 opacity-50" />
        </Button>
      </PopoverTrigger>

      <PopoverContent className="p-0">
        <Command>
          <CommandInput
            placeholder="Tìm phòng ban..."
            onValueChange={handleSearch}
          />
          <CommandList
            ref={listRef}
            className="max-h-60 overflow-auto"
            onScroll={handleScroll}
          >
            <CommandEmpty>Không tìm thấy phòng ban</CommandEmpty>

            <CommandGroup>
              {departments.map((dept) => (
                <CommandItem
                  key={dept.id}
                  value={dept.tenPB}
                  onSelect={() => {
                    onChange(dept.id);
                    setOpen(false);
                  }}
                >
                  {dept.tenPB}
                </CommandItem>
              ))}

              {loading && (
                <div className="py-2 text-center text-sm text-muted-foreground">
                  Đang tải...
                </div>
              )}
            </CommandGroup>
          </CommandList>
        </Command>
      </PopoverContent>
    </Popover>
  );
}
