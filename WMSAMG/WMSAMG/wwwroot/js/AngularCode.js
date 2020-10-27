var app = angular.module("myApp", []);
var deptapp = angular.module("myDeptApp", []);



app.controller("myCtrl", function ($scope, $http) {
    //debugger;
    
   
    $scope.CancelData = function () {
        var Action = document.getElementById("btnCancel").getAttribute("value");

        if (Action == "Cancel") {
            $http({
                method: "post",
                url: "https://localhost:44336/Employee/Get_AllEmployee"
            }).then(function (response) {
                
                $scope.GetAllData();
                $scope.EmpName = "";
                $scope.EmpCity = "";
                $scope.EmpAge = "";
                $scope.Dept_Code = null;
                document.getElementById("btnSave").setAttribute("value", "Submit");
                document.getElementById("btnSave").style.backgroundColor = "cornflowerblue";
                document.getElementById("spn").innerHTML = "Add New Employee";
            })
        }
    };


    //Insert Employee
    $scope.InsertData = function () {
        var Action = document.getElementById("btnSave").getAttribute("value");
       
        if (Action == "Submit" && !!$scope.EmpName && !!$scope.EmpCity) {
            $scope.employee = {};
            $scope.employee.Emp_Name = $scope.EmpName;
            $scope.employee.Emp_City = $scope.EmpCity;
            $scope.employee.Emp_Age = $scope.EmpAge;
            $scope.employee.Dept_Code = $scope.DeptCode;
            $http({
                method: "post",
                url: "https://localhost:44336/Employee/Insert_Employee",
                datatype: "json",
                data: JSON.stringify($scope.employee)
            }).then(function (response) {
                alert(response.data);
                $scope.GetAllData();
                $scope.EmpName = "";
                $scope.EmpCity = "";
                $scope.EmpAge = "0";
                $scope.Dept_Code = null;

            })
        } else if (!!$scope.EmpName && !!$scope.EmpCity){
            $scope.employee = {};
            $scope.employee.Emp_Name = $scope.EmpName;
            $scope.employee.Emp_City = $scope.EmpCity;
            $scope.employee.Emp_Age = $scope.EmpAge;
            $scope.employee.Dept_Code = $scope.selectedDept.Dept_Code;
            $scope.employee.Emp_Id = document.getElementById("EmpID_").value;

            $http({
                method: "post",
                url: "https://localhost:44336/Employee/Update_Employee",
                datatype: "json",
                data: JSON.stringify($scope.employee)
            }).then(function (response) {
                alert(response.data);
                $scope.GetAllData();
                $scope.EmpName = "";
                $scope.EmpCity = "";
                $scope.EmpAge = "0";
                $scope.Dept_Code = null;
                document.getElementById("btnSave").setAttribute("value", "Submit");
                document.getElementById("btnSave").style.backgroundColor = "cornflowerblue";
                document.getElementById("spn").innerHTML = "Add New Employee";
            })
        }
        
    }
    //Get All Employee
    $scope.GetAllData = function () {
        $http({
            method: "post",
            url: "https://localhost:44336/Employee/Get_AllEmployee"
        }).then(function (response) {
            $scope.Employee = response.data;
        }, function () {
            alert("Error Occur");
        })

        $http.get('https://localhost:44336/Department/Get_AllDepartment').then(function (response) {
            $scope.Department = response.data;
            if ($scope.Department.length > 0) {
                $scope.selectedDept = $scope.Department[0];
            }
        });
    };

    //GetAllDepartments
    $scope.getDepartments = function () {
        if ($scope.selectedDept.DeptCode != null) {
            console.log($scope.selectedDept.DeptCode);
            http({
                method: 'POST',
                url: 'https://localhost:44336/Department/Get_DepartmentById',
                data: { DeptCode: $scope.selectedDept.DeptCode }
            }).success(function (data, status, headers, config) {
                //assign departments data to scope
                $scope.Department = data;
                //setting default value
                if ($scope.Department.length > 0) {
                    $scope.selectedDept = $scope.Department[0];
                }
            }).error(function (data, status, headers, config) {
                alert("Error occured");
            });
        }
        else {
            $scope.Department = null;
        }
    }

    //Delete Employee Information
    $scope.DeleteEmp = function (employee) {
        $http({
            method: "post",
            url: "https://localhost:44336/Employee/Delete_Employee",
            datatype: "json",
            data: JSON.stringify(employee)
        }).then(function (response) {
            alert(response.data);
            $scope.GetAllData();
        })
    };

    //Set Employee Information for Update
    $scope.UpdateEmp = function (employee) {
        document.getElementById("EmpID_").value = employee.EmpId;
        $scope.EmpName = employee.EmpName;
        $scope.EmpCity = employee.EmpCity;
        $scope.EmpAge = employee.EmpAge;
        $scope.selectedDept.DeptCode = employee.DeptCode;
        
        document.getElementById("btnSave").setAttribute("value", "Update");
        document.getElementById("btnSave").style.backgroundColor = "Yellow";
        document.getElementById("spn").innerHTML = "Update Employee Information";
    };

    
})

deptapp.controller("myCtrl", function ($scope, $http) {
    //debugger;
    

    $scope.CancelData = function () {
        var Action = document.getElementById("btnCancel").getAttribute("value");

        if (Action == "Cancel") {
            $http({
                method: "post",
                url: "https://localhost:44336/Department/Get_AllDepartment"
            }).then(function (response) {

                $scope.GetAllData();
                $scope.DeptName = "";
               
                document.getElementById("btnSave").setAttribute("value", "Submit");
                document.getElementById("btnSave").style.backgroundColor = "cornflowerblue";
                document.getElementById("spn").innerHTML = "Add New Department";
            })
        }
    };


    //Insert Department
    $scope.InsertData = function () {
        var Action = document.getElementById("btnSave").getAttribute("value");

        if (Action == "Submit" && !!$scope.DeptName) {
            $scope.department = {};
            $scope.department.Dept_Name = $scope.DeptName;
           
            $http({
                method: "post",
                url: "https://localhost:44336/Department/Insert_Department",
                datatype: "json",
                data: JSON.stringify($scope.department)
            }).then(function (response) {
                alert(response.data);
                $scope.GetAllData();
                $scope.DeptName = "";
            })
        } else if (!!$scope.DeptName) {
            $scope.department = {};
            $scope.department.Dept_Name = $scope.DeptName;
            $scope.department.Dept_Code = document.getElementById("DeptCode_").value;

            $http({
                method: "post",
                url: "https://localhost:44336/Department/Update_Department",
                datatype: "json",
                data: JSON.stringify($scope.department)
            }).then(function (response) {
                alert(response.data);
                $scope.GetAllData();
                $scope.DeptName = "";
                document.getElementById("btnSave").setAttribute("value", "Submit");
                document.getElementById("btnSave").style.backgroundColor = "cornflowerblue";
                document.getElementById("spn").innerHTML = "Add New Department";
            })
        }

    }
    //Get All Department
    $scope.GetAllData = function () {
        $http({
            method: "post",
            url: "https://localhost:44336/Department/Get_AllDepartment"
        }).then(function (response) {
            $scope.departments = response.data;
        }, function () {
            alert("Error Occur");
        })
    };

    //Delete Department Information
    $scope.DeleteDept = function (department) {
        $http({
            method: "post",
            url: "https://localhost:44336/Department/Delete_Department",
            datatype: "json",
            data: JSON.stringify(department)
        }).then(function (response) {
            alert(response.data);
            $scope.GetAllData();
        })
    };

    //Set Department Information for Update
    $scope.UpdateDept = function (department) {
        document.getElementById("DeptCode_").value = department.Dept_Code;
        $scope.DeptName = department.Dept_Name;
        document.getElementById("btnSave").setAttribute("value", "Update");
        document.getElementById("btnSave").style.backgroundColor = "Yellow";
        document.getElementById("spn").innerHTML = "Update Department Information";
    };


})