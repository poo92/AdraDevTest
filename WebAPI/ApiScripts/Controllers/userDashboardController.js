angular.module('adraDevTest')
.controller('userDashboardController', ['$scope', '$http', '$window', '$location', 'loginService', 'sessionService', function ($scope, $http, $window, $location, $timeout, loginService, sessionService) {

    // make the result panel invisible
    $scope.isVisibleCurrentBalancePanel = false;


    $scope.ViewCurrentBalance = function () {
        var UserRequest = '{accountType: "' + $scope.accountType + '"}';
        // call the controller method
        $http({
            method: "POST",
            url: "../api/AccountBalance/ViewCurrentBalance",
            dataType: 'json',
            data: UserRequest,
            headers: { "Content-Type": "application/json" }
        }).then(function OnSuccess(response) {
            console.log(response.data);
            isEmptyDb = response.data[0];
            // if db is empty
            if (isEmptyDb == 1) {
                $window.alert("no account balances are uploaded yet");
            } else {
                // show current balance
                $scope.currentBalance = response.data[1];
                $scope.isVisibleCurrentBalancePanel = true;
            }


        }, function OnError(Error) {
            console.log(Error)
        })

    }

    $scope.Logout = function () {
        loginService.Logout();
    }


}]);












