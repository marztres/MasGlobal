import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class EmployeesService {
    private employees: any = [];
    private url = "http://localhost:64341/api/employees/"; 

    constructor(private http: Http) {}

    getEmployees(): Observable<any> {
        return this.http.get(`${ this.url }`);
    }

    getEmployee(identification: number): Observable<any> {
        return this.http.get(this.url + identification);
    }

}

export interface Employee {
    Id: number;
    Name: string;
    ContractTypeName: string;
    RoleName: string;
    RoleDescription: string;
    hourlySalary: string;
    monthlySalary: string;
    AnualSalary: string;
}

