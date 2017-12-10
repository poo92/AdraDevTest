angular.module('adraDevTest')
.controller('dashboardController', function ($scope, $http, $window, $location) {
    console.log("inside");
    $scope.HandleButtonPress = function (event) {
        buttonid = event.target.id;
        if (buttonid == "uploadBalance") {
            $scope.viewPage = "../ApiViews/UploadBalance.html";

        } else if (buttonid == "viewBalance") {
            $scope.viewPage = "../ApiViews/ViewBalance.html";

        } else if (buttonid == "viewBalanceChart") {
            $scope.viewPage = "../ApiViews/ViewBalanceChart.html";
        }
    }

    $scope.UploadBalance = function () {
        console.log("UploadBalance");
        //$window.location.href = "#!AdminDashboard/UploadBalance";
    }

    $scope.ViewBalance = function () {
        console.log("ViewBalance");
        //$window.location.href = "#!AdminDashboard/UploadBalance";
    }

    $scope.ViewBalanceChart = function () {
        console.log("ViewBalanceChart");
        //$window.location.href = "#!AdminDashboard/UploadBalance";
    }
});