angular.module('adraDevTest')
.factory('sessionService', ['$http', function ($http) {
    return {
        // set session variables
        set: function (key, value) {
            return sessionStorage.setItem(key,value);
        },
        // get session variables
        get: function (key, value) {
            return sessionStorage.getItem(key);
        },

        // remove session variables
        destroy: function (key, value) {
            return sessionStorage.removeItem(key);
        }
    }




}]);