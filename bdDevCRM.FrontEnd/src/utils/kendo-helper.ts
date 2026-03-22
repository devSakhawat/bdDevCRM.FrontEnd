export const transformKendoRequest = (options: any) => {
    // Flattening the Kendo object for bdDevCRM backend
    return {
        page: options.page || 1,
        pageSize: options.pageSize || 10,
        skip: options.skip || 0,
        take: options.take || 10,
        sort: options.sort ? options.sort.map((s: any) => ({
            field: s.field,
            dir: s.dir
        })) : [],
        filter: options.filter ? transformFilter(options.filter) : null
    };
};

const transformFilter = (filter: any): any => {
    if (!filter) return null;
    if (filter.filters) {
        return {
            logic: filter.logic,
            filters: filter.filters.map((f: any) => transformFilter(f))
        };
    }
    return {
        field: filter.field,
        operator: filter.operator,
        value: filter.value?.toString()
    };
};