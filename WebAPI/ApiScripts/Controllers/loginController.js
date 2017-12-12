angular.module('adraDevTest')
.controller('loginController', function ($scope, $http, loginService) {

    $scope.Login = function () {        
        loginService.Login($scope.username,$scope.password);
    }
    
});