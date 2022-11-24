import { Component, inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MAT_DATE_FORMATS } from '@angular/material/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import * as moment from 'moment';
import { Department } from 'src/app/Interfaces/department';
import { Employee } from 'src/app/Interfaces/employee';
import { DepartmentService } from 'src/app/Services/department.service';
import { EmployeeService } from 'src/app/Services/employee.service';
import { ThisReceiver } from "@angular/compiler";

export const MY_DATE_FORMATS = {
    parse: {
        dateInput: 'DD/MM/YYYY'
    },
    display: {
        dateInput: 'DD/MM/YYYY',
        monthYearLabel: 'MMMM YYYY',
        dataA11yLabel: 'LL',
        monthYearA11yLabel: 'MMMM YYYY'
    }
};

@Component({
    selector: 'app-dialog-add-edit',
    templateUrl: './dialog-add-edit.component.html',
    styleUrls: ['./dialog-add-edit.component.css'],
    providers: [
        {
            provide: MAT_DATE_FORMATS,
            useValue: MY_DATE_FORMATS
        }
    ]
})
export class DialogAddEditComponent implements OnInit {

    formEmployee: FormGroup;
    action: string = "Add";
    actionButton: string = "Save";
    listDepartment: Department[] = [];

    constructor(
        @inject(MAT_DIALOG_DATA) public employeeData: Employee,
        private dialogReference: MatDialogRef<DialogAddEditComponent>,
        private fb: FormBuilder,
        private _snackBar: MatSnackBar,
        private _departmentService: DepartmentService,
        private _employeeService: EmployeeService
    ) {
        this.formEmployee = fb.group({
            fullName: ['', Validators.required],
            departmentId: ['', Validators.required],
            salary: ['', Validators.required],
            hireDate: ['', Validators.required],
        });

        this._departmentService.getList().subscribe({
            next: (data) => {
                if (data.status) {
                    this.listDepartment = data.value
                }
            },
            error: (err) => { }
        });
    }
        
    ngOnInit(): void {
        
    }

    showAlert(msg: string, title: string) {
        this._snackBar.open(msg, title, {
            horizontalPosition: 'end',
            verticalPosition: 'top',
            duration: 3000
        });
    }

    addEditEmployee() {
        const model: Employee = {
            id: 0,
            fullName: this.formEmployee.value.fullName,
            departmentId: this.formEmployee.value.departmentId,
            salary: this.formEmployee.value.salary,
            hireDate: moment(this.formEmployee.value.hireDate).format('DD/MM/YYYY')
        }

        this._employeeService.add(model).subscribe({
            next: (data) => {
                if (data.status) {
                    this.showAlert("Employee was created!", "success");
                    this.dialogReference.close('created');
                } else {
                    this.showAlert("could not create", 'Error');
                }
            },
            error: (err) => { }
        });
    }

}
