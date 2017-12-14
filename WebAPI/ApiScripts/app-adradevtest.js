"use strict"
// fedine the angular app
var app = angular.module('adraDevTest', ['ngRoute'])

// configure the routes
app.config(['$routeProvider', function ($routeProvider) {
    $routeProvider
    .when("/", {
        controller: "loginController",
        templateUrl: "ApiViews/Login.html"
    })
    .when("/AdminDashboard/", {
        controller: "dashboardController",
        templateUrl: "ApiViews/AdminDashboard.html",
        resolve: {
            "check": function (loginService, $location) {   //function to be resolved, accessFac and $location Injected
                if (!loginService.isLoggedIn()) {    //check if the user has permission -- This happens before the page loads
                    $location.path('/');
                } else if (!loginService.isAdmin() && loginService.isLoggedIn()) {
                    $location.path('/UserDashboard');
                }
            }
        }
    })
    .when("/UserDashboard", {
        controller: "dashboardController",
        templateUrl: "ApiViews/UserDashboard.html",
        resolve: {
            "check": function (loginService, $location) {   //function to be resolved, accessFac and $location Injected
                if (!loginService.isLoggedIn()) {    //check if the user has permission -- This happens before the page loads
                    $location.path('/');
                } else if (!loginService.isNormalUser() && loginService.isLoggedIn()) {
                    $location.path('/AdminDashboard');
                }
            }
        }
    }).otherwise({ redirect: "/" })
}]);



// months dropdown
app.directive('monthOptions', function () {
    return {
        template:
            '<option disabled selected value> -- select a  month -- </option>' +
            '<option value=1 >January</option>' +
            '<option value=2 >February</option>' +
            '<option value=3 >March</option>' +
            '<option value=4 >April</option>' +
            '<option value=5 >May</option>' +
            '<option value=6 >June</option>' +
            '<option value=7 >July</option>' +
            '<option value=8 >August</option>' +
            '<option value=9 >September</option>' +
            '<option value=10 >October</option>' +
            '<option value=11 >November</option>' +
            '<option value=12 >December</option>'
    }
});
