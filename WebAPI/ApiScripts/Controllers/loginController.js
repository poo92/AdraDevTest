angular.module('adraDevTest')
.controller('loginController', ['$scope', '$http', 'loginService', function ($scope, $http, loginService) {

    $scope.Login = function () {        
        loginService.Login($scope.username, $scope.password);        
    }
    
}]);