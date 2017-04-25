

var app = angular.module("myApp", []);  
app.controller("myRefferralCtrl", function ($scope, $http) {

    $scope.InsertData = function () {
        var Action = document.getElementById("btnSave").getAttribute("value");
        if (Action == "Submit") {
            $scope.Employe = {};
            $scope.Employe.Name = $scope.Name;
            $scope.Employe.Price = $scope.Price;

            $http({
                method: "post",
                url: "/Product/Create",
                datatype: "json",
                data: JSON.stringify($scope.Employe)
            }).then(function (response) {

                $scope.GetAllData();
                $scope.Name = "";
                $scope.Price = "";

            })
        } else {
            $scope.Employe = {};
            $scope.Employe.Name = $scope.Name;
            $scope.Employe.Price = $scope.Price;
          
            $scope.Employe.Id = document.getElementById("Id").value;
            $http({
                method: "post",
                url: "/Product/Update",
                datatype: "json",
                data: JSON.stringify($scope.Employe)
            }).then(function (response) {
               
                $scope.GetAllData();
                $scope.Name = "";
                $scope.Price = "";
            
                document.getElementById("btnSave").setAttribute("value", "Submit");
                document.getElementById("btnSave").style.backgroundColor = "cornflowerblue";
                document.getElementById("spn").innerHTML = "Add New Employee";
            })
        }
    };

    $scope.GetAllData = function () {
        $http({
            method: "get",
            url: "/Product/GetProducts"
        }).then(function (response) {
            $scope.Emp = response.data;
        }, function () {
            alert("Error Occur");
        })

    }




    $scope.UpdateEmp = function (Emp) {
        document.getElementById("Id").value = Emp.Id;
        $scope.Name = Emp.Name;
        $scope.Price = Emp.Price;
       
        document.getElementById("btnSave").setAttribute("value", "Update");
        document.getElementById("btnSave").style.backgroundColor = "Yellow";
        document.getElementById("spn").innerHTML = "Update Employee Information";
    }
    $scope.DeleteEmp = function (Emp) {
        $http({
            method: "post",
            url: "/Product/AngularDelete",
            datatype: "json",
            data: JSON.stringify(Emp)
        }).then(function (response) {
            
            $scope.GetAllData();
        })
    };










   
    });