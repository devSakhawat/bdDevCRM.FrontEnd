export const transformKendoRequest = (options) => {
    // Flattening the Kendo object for bdDevCRM backend
    return {
        page: options.page || 1,
        pageSize: options.pageSize || 10,
        skip: options.skip || 0,
        take: options.take || 10,
        sort: options.sort ? options.sort.map((s) => ({
            field: s.field,
            dir: s.dir
        })) : [],
        filter: options.filter ? transformFilter(options.filter) : null
    };
};
const transformFilter = (filter) => {
    var _a;
    if (!filter)
        return null;
    if (filter.filters) {
        return {
            logic: filter.logic,
            filters: filter.filters.map((f) => transformFilter(f))
        };
    }
    return {
        field: filter.field,
        operator: filter.operator,
        value: (_a = filter.value) === null || _a === void 0 ? void 0 : _a.toString()
    };
};
