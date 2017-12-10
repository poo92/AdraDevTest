(function () {
    "use strict"

    var app = angular.module('adraDevTest', ["ngRoute"])

    app.config(function ($routeProvider) {
        $routeProvider
        .when("/", {
            controller: "loginController",
            templateUrl: "../ApiViews/Login.html"
        })
        .when("/AdminDashboard/", {
            controller: "dashboardController",
            templateUrl: "../ApiViews/AdminDashboard.html"
        })
        .when("/AdminDashboard/UploadBalance", {
            controller:"dashboardController",
            templateUrl: "../ApiViews/UploadBalance.html"
        })
        .when("/blue", {
            templateUrl: "blue.htm"
        }).otherwise({ redirect:"/"})
    });

    app.controller('viewBalanceController', function ($scope, $http, $window) {

        $scope.Search = function () {
            var userRequest = '{year: "' + $scope.year + '" ,month:"' + $scope.month + '" }';
            $http({
                method: "POST",
                url: "../api/AccountBalance/ViewBalance",
                dataType: 'json',
                data: userRequest,
                headers: { "Content-Type": "application/json" }
            }).then(function OnSuccess(response) {
                console.log(response.data)
            }, function OnError(Error) {
                console.log(Error)
            }
            )

        }
    });

    app.controller('viewBalanceChartController', function ($scope, $http, $window) { });


})();