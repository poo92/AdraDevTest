angular.module('adraDevTest')
.factory('loginService', ['$http', '$window', '$location', 'sessionService', function ($http, $window, $location, sessionService) {
    return {
        Login: function (username, password) {
            var user = '{username: "' + username + '" ,password:"' + password + '" }';
            return $http({
                method: "POST",
                url: "../api/User/login",
                dataType: 'json',
                data: user,
                headers: { "Content-Type": "application/json" }
            }).then(function OnSuccess(response) {
                if (response.data == 0) {
                    $window.alert("Invalid Credentials. Plese check again.")
                } else if (response.data == 1) {
                    sessionService.set("usertypeAdmin", true);
                    sessionService.set("loggedin", true);
                    sessionService.set("username", username);
                    $window.location.href = "#!AdminDashboard/";
                } else if (response.data == 2) {
                    sessionService.set("usertypeNormalUser", true);
                    sessionService.set("loggedin", true);
                    sessionService.set("username", username);
                    $window.location.href = "#!UserDashboard/";
                } else {
                    $window.alert("Error occured. Plese try again later.")
                }
            }, function OnError(Error) {
                return Error;
            })
        },

        Logout: function () {
            sessionService.destroy("loggedin");
            sessionService.destroy("username");
            sessionService.destroy("usertypeNormalUser");
            sessionService.destroy("usertypeAdmin");
            $window.location.href = "/";
        },

        isLoggedIn: function () {
            if (sessionService.get('loggedin')) {
                return true;
            }
        },
        isAdmin: function () {
            if (sessionService.get('usertypeAdmin')) {
                return true;
            }
        },
        isNormalUser: function () {
            if (sessionService.get('usertypeNormalUser')) {
                return true;
            }
        }


    }


}]);