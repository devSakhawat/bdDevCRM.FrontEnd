// modules/user.module.ts
import { UserService } from '../services/user.service';
import { IUserDto } from '../types/user.types';

export class UserModule {
  private gridElement: JQuery;
    
  constructor(gridId: string) {
    this.gridElement = $(`#${gridId}`);
  }

  /**
   * Initialize Kendo Grid with the new service architecture
   */
  public initGrid(): void {
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
          template: (data: IUserDto) => data.isActive ? '<span class="label label-success">Active</span>' : '<span class="label label-danger">Inactive</span>',
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
  private createDataSource(): kendo.data.DataSource {
    return new kendo.data.DataSource({
      transport: {
        read: async (options) => {
          try {
            const result = await UserService.getUsersForGrid(options.data);
            // Kendo expects { data: [], total: 0 }
            options.success({
              data: result.data.items,
              total: result.data.totalCount
            });
          } catch (error) {
            options.error(error);
          }
        }
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

  private onEdit(e: JQuery.ClickEvent): void {
    e.preventDefault();
    const dataItem = this.gridElement.data("kendoGrid").dataItem($(e.currentTarget).closest("tr"));
    console.log("Editing user:", dataItem.userId);
    // Implement navigation or modal popup logic here
  }
} 