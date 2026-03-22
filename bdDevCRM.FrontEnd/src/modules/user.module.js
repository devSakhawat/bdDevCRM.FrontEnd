var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
// modules/user.module.ts
import { UserService } from '../services/user.service';
export class UserModule {
    constructor(gridId) {
        this.gridElement = $(`#${gridId}`);
    }
    /**
     * Initialize Kendo Grid with the new service architecture
     */
    initGrid() {
        this.gridElement.kendoGrid({
            dataSource: this.createDataSource(),
            sortable: true,
            pageable: { refresh: true, pageSizes: [10, 20, 50, 100] },
            filterable: true,
            columns: [
                { field: "loginId", title: "Login ID", width: "120px" },
                { field: "userName", title: "User Name", width: "200px" },
                { field: "email", title: "Email", width: "150px" },
                {
                    field: "isActive",
                    title: "Status",
                    template: (data) => data.isActive ? '<span class="label label-success">Active</span>' : '<span class="label label-danger">Inactive</span>',
                    width: "100px"
                },
                {
                    command: [
                        { name: "edit", click: (e) => this.onEdit(e) },
                        { name: "destroy", text: "Delete" }
                    ],
                    title: "Actions",
                    width: "180px"
                }
            ]
        });
    }
    /**
     * Bridge Kendo DataSource with our TypeScript UserService
     */
    createDataSource() {
        return new kendo.data.DataSource({
            transport: {
                read: (options) => __awaiter(this, void 0, void 0, function* () {
                    try {
                        const result = yield UserService.getUsersForGrid(options.data);
                        // Kendo expects { data: [], total: 0 }
                        options.success({
                            data: result.data.items,
                            total: result.data.totalCount
                        });
                    }
                    catch (error) {
                        options.error(error);
                    }
                })
            },
            serverPaging: true,
            serverFiltering: true,
            serverSorting: true,
            pageSize: 10,
            schema: {
                data: "data",
                total: "total",
                model: { id: "userId" }
            }
        });
    }
    onEdit(e) {
        e.preventDefault();
        const dataItem = this.gridElement.data("kendoGrid").dataItem($(e.currentTarget).closest("tr"));
        console.log("Editing user:", dataItem.userId);
        // Implement navigation or modal popup logic here
    }
}
