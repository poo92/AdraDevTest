angular.module('adraDevTest')
.controller('loginController', function ($scope, $http, $window, $location) {
    $scope.Login = function () {        
        var user = '{username: "' + $scope.username + '" ,password:"' + $scope.password + '" }';
        $http({
            method: "POST",
            url: "../api/User/login",
            dataType: 'json',
            data: user,
            headers: { "Content-Type": "application/json" }
        }).then(function OnSuccess(response) {
            if (response.data == "success") {              
                $window.location.href = "#!AdminDashboard/";
            }
        }, function OnError(Error) {
            console.log(Error)
        }
        )

    }
});