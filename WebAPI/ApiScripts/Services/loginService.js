angular.module('adraDevTest')
.factory('loginService', ['$http', '$window', '$location', 'sessionService', function ($http, $window, $location, sessionService) {
    return {
        // login function
        Login: function (username, password) {
            var user = '{username: "' + username + '" ,password:"' + password + '" }';
            // call controller method
            return $http({
                method: "POST",
                url: "../api/User/login",
                dataType: 'json',
                data: user,
                headers: { "Content-Type": "application/json" }
            }).then(function OnSuccess(response) {
                if (response.data == 0) {
                    // if credentials are invalid
                    $window.alert("Invalid Credentials. Plese check again.")
                } else if (response.data == 1) {
                    // if user is an admin
                    sessionService.set("usertypeAdmin", true);
                    sessionService.set("loggedin", true);
                    sessionService.set("username", username);
                    // redirect to the admin dashboard
                    $window.location.href = "#!AdminDashboard/";
                } else if (response.data == 2) {
                    //if user is a normal user
                    sessionService.set("usertypeNormalUser", true);
                    sessionService.set("loggedin", true);
                    sessionService.set("username", username);
                    // redirect to user dashboard
                    $window.location.href = "#!UserDashboard/";
                } else {
                    $window.alert("Error occured. Plese try again later.")
                }
            }, function OnError(Error) {
                $window.alert("Error occured. Plese try again later.")
            })
        },

        // logout function
        Logout: function () {
            // remove session variables
            sessionService.destroy("loggedin");
            sessionService.destroy("username");
            sessionService.destroy("usertypeNormalUser");
            sessionService.destroy("usertypeAdmin");
            // redirect to login page
            $window.location.href = "/";
        },
        
        // check if user is logged in
        isLoggedIn: function () {
            if (sessionService.get('loggedin')) {
                return true;
            }
        },

        // check if user is an admin
        isAdmin: function () {
            if (sessionService.get('usertypeAdmin')) {
                return true;
            }
        },

        // check if user is a normal user
        isNormalUser: function () {
            if (sessionService.get('usertypeNormalUser')) {
                return true;
            }
        }


    }


}]);