angular.module('adraDevTest')
.factory('sessionService', ['$http', function ($http) {
    return {
        set: function (key, value) {
            return sessionStorage.setItem(key,value);
        },
        get: function (key, value) {
            return sessionStorage.getItem(key);
        },
        destroy: function (key, value) {
            return sessionStorage.removeItem(key);
        }
    }




}]);