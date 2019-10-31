import { Component } from '@angular/core';
import { EmployeesService, Employee } from '../../services/employees.services';


@Component({
    selector: 'home',
    templateUrl: './home.component.html'
})
export class HomeComponent {

    employees: Employee[] = [];
    identification:number;

    constructor(private _employeesService: EmployeesService) { }

    getEmployees() {
        if (this.identification > 0) {
            this.employees = [];
            this._employeesService.getEmployee(this.identification).subscribe((result: any) => {
                this.employees.push(JSON.parse(result._body));
            });
        } else {
            this._employeesService.getEmployees().subscribe((result: any) => {
                this.employees = JSON.parse(result._body);
            });
        }
    }

}


