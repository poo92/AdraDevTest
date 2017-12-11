﻿(function () {
    "use strict"

    var app = angular.module('adraDevTest', ["ngRoute","ngFileUpload"])

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
        .when("/UserDashboard", {
            controller: "dashboardController",
            templateUrl: "../ApiViews/UserDashboard.html"
        })
        .when("/ViewAccountBalances", {
            controller: "dashboardController",
            templateUrl: "../ApiViews/ViewBalanceResult.html"
        })
        .when("/ViewAccountBalancesSummary", {
            templateUrl: "../ApiViews/ViewBalanceSummaryResult.html"
        }).otherwise({ redirect: "/" })
    });




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


    app.directive('hcChart', function () {
        return {
            restrict: 'E',
            template: '<div></div>',
            scope: {
                options: '='
            },
            link: function (scope, element) {
                Highcharts.chart(element[0], scope.options);
            }
        };
    });

    app.directive('validFile', function () {
        return {
            require: 'ngModel',
            link: function (scope, el, attrs, ngModel) {
                el.bind('change', function () {
                    scope.$apply(function () {
                        ngModel.$setViewValue(el.val());
                        ngModel.$render();
                    });
                });
            }
        }
    });




})();