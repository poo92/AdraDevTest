angular.module('adraDevTest')
.controller('dashboardController', ['$scope', '$http', '$window', '$location', '$timeout', 'loginService', 'sessionService', function ($scope, $http, $window, $location, $timeout, loginService, sessionService) {
    // variables which control visibility of modals which shows results
    $scope.showViewBalanceModal = false;
    $scope.showViewBalanceChartModal = false;
    $scope.isVisibleCurrentBalancePanel = false;
    $scope.showDeletePopup = false;
    $scope.usernameFiltered = [];

    // username of logged user
    $scope.username = sessionService.get("username");
    console.log($scope.username);
    // months array
    var months = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];

    // load relevent page according to button press
    $scope.HandleButtonPress = function (event) {
        buttonid = event.target.id;
        if (buttonid == "uploadBalance") {
            $scope.viewPage = "../ApiViews/UploadBalance.html";


        } else if (buttonid == "viewBalance") {
            $scope.showViewBalanceModal = false;
            $scope.showViewBalanceChartModal = false;
            $scope.viewPage = "../ApiViews/ViewBalance.html";


        } else if (buttonid == "viewBalanceChart") {
            $scope.viewPage = "../ApiViews/ViewBalanceChart.html";

        } else if (buttonid == "addUser") {
            $scope.viewPage = "../ApiViews/AddUser.html";

        } else if (buttonid == "deleteUser") {
            this.GetAllUsers();
            $scope.viewPage = "../ApiViews/DeleteUser.html";
        }
    }


    // add user function
    $scope.AddUser = function () {
        var user = '{username:"' + $scope.username + '",password: "' + $scope.password + '",userType: "' + $scope.userType + '",fname: "' + $scope.fname + '",lname: "' + $scope.lname + '"}';
        $http({
            method: "POST",
            url: "../api/User/AddUser",
            dataType: 'json',
            data: user,
            headers: { "Content-Type": "application/json" }
        }).then(function OnSuccess(response) {
            $window.alert(response.data);
            if (response.data == "User Added succesfully") {
                $window.location.href = "#!AdminDashboard/";
            }
        }, function OnError(Error) {
            alert("An error occured. Please try again later.")
        })
    }

    $scope.GetAllUsers = function () {       
        $http({
            method: "POST",
            url: "../api/User/GetAllUSers",
            dataType: 'json',            
            headers: { "Content-Type": "application/json" }
        }).then(function OnSuccess(response) {            
            $scope.usernames = response.data;                      
            for (var i = 0; i < response.data.length; i++) {
               if($scope.usernames[i] != $scope.username){
                   $scope.usernameFiltered.push($scope.usernames[i]);
                }
            }

            console.log($scope.usernameFiltered)
        }, function OnError(Error) {
            alert("An error occured while loading usernames.")
        })
    }

    $scope.ShowDeletePopup = function () {
        $scope.showDeletePopup = true;
    }

    $scope.HandleNoButton = function () {
        $scope.showDeletePopup = false;       
        $window.location.href = "#!AdminDashboard/";
        $window.alert("User is not deleted.");

    }
    // delete user function
    $scope.DeleteUser = function () {
        $scope.showDeletePopup = false;
        var user = '{username:"' + $scope.usernameDelete + '"}';
        $http({
            method: "POST",
            url: "../api/User/DeleteUser",
            dataType: 'json',
            data: user,
            headers: { "Content-Type": "application/json" }
        }).then(function OnSuccess(response) {
            $window.alert(response.data);
            if (response.data == "deleted successfully") {
                $window.location.href = "#!AdminDashboard/";
            }
        }, function OnError(Error) {
            alert("An error occured. Please try again later.")
        })
       
    }


    // upload account balance
    $scope.UploadBalance = function () {
        // get year
        var year = document.getElementById("year").value;
        // get file content
        var file = document.getElementById("file").files[0];


        if (file) {
            // extention if the file
            var extention = file.name.split('.').pop();
            // if text file
            if (extention == "txt") {
                var reader = new FileReader();
                reader.readAsText(file, "UTF-8");
                reader.onload = function (evt) {
                    var userRequest = '{year:"' + year + '",fileContent: "' + evt.target.result + '"}';
                    // call controller method
                    $http({
                        method: "POST",
                        url: "../api/AccountBalance/UploadBalance",
                        dataType: 'json',
                        data: userRequest,
                        headers: { "Content-Type": "application/json" }
                    }).then(function OnSuccess(response) {
                        $window.alert(response.data);
                        $window.location.href = "#!AdminDashboard/";

                    }, function OnError(Error) {
                        console.log(Error)
                    })
                }
                reader.onerror = function (evt) {
                    $window.alert("An error occured while reading file. Please try again later.");
                }
            } else if (extention == "xlsx" || extention == "xls") {
                $window.alert("Not yet developed for excel files");
                $window.location.href = "#!AdminDashboard/";
                //console.log("inside");
                //var reader = new FileReader();

                //reader.onload = function (e) {
                //    var data = e.target.result;
                //    var workbook = XLSX.read(data, {
                //        type: 'binary'
                //    });

                //    workbook.SheetNames.forEach(function (sheetName) {
                //        // Here is your object
                //        var XL_row_object = XLSX.utils.sheet_to_row_object_array(workbook.Sheets[sheetName]);
                //        var json_object = JSON.stringify(XL_row_object);
                //        console.log(json_object);

                //    })

                //};

                //reader.onerror = function (ex) {
                //    console.log(ex);
                //};

                //reader.readAsBinaryString(file);

            } else {
                $window.alert("Please upload text or excel file");
            }

        } else {
            // if file is not selected
            $window.alert("Please upload a file");
        }
    }


    // view balance of a month
    $scope.ViewBalance = function () {
        // get the month
        var month = parseInt($scope.month);
        var UserRequest = '{year: "' + $scope.year + '" ,month:"' + month + '" }';
        // call controller mrthod
        $http({
            method: "POST",
            url: "../api/AccountBalance/ViewBalance",
            dataType: 'json',
            data: UserRequest,
            headers: { "Content-Type": "application/json" }
        }).then(function OnSuccess(response) {
            if (response.data.year == 0) {
                // if balance for the selected month is not in db
                $window.alert("No account balances are available for this month");
                $window.location.href = "#!AdminDashboard/";
            } else {
                // set response to scope variable
                $scope.$parent.accountBalance = response.data;
                // select relevent month from months array
                $scope.$parent.accountBalance.month = months[response.data.month - 1];
                // make the result modal visible
                $scope.showViewBalanceModal = true;
            }

        }, function OnError(Error) {
            console.log(Error)
        }
        )
    }
    // handle the close button of the modal popup
    $scope.HandleViewBalanceModal = function () {
        $scope.showViewBalanceModal = true;
        $window.location.href = "#!AdminDashboard/";
    }

    // view the balances of a time period
    $scope.ViewBalanceChart = function () {

        // get the variables
        var startMonth = parseInt($scope.startMonth);
        var endMonth = parseInt($scope.endMonth);
        var startYear = $scope.startYear;
        var endYear = $scope.endYear;

        // check for validity of the parameteres
        if (startYear > endYear) {
            $window.alert(" Start Year must be eqal or less than the End Year. \n Please enter valid values.");
        } else if (startYear == endYear) {
            if (startMonth > endMonth) {
                $window.alert(" Start Month must be eqal or less than End Month. \n Please enter valid values.");
            } else {
                // startYear == endYear && startMonth <= endMonth
                this.getChart(startYear, startMonth, endYear, endMonth);
            }
        } else {
            // startYear < endYear
            this.getChart(startYear, startMonth, endYear, endMonth);
        }
    }

    // function to generate the chart
    $scope.getChart = function (startYear, startMonth, endYear, endMonth) {
        var UserRequest = '{startYear: "' + startYear + '" ,startMonth:"' + startMonth + '",endYear:"' + endYear + '",endMonth:"' + endMonth + '" }';
        // call controller method
        $http({
            method: "POST",
            url: "../api/AccountBalance/ViewBalanceChart",
            dataType: 'json',
            data: UserRequest,
            headers: { "Content-Type": "application/json" }
        }).then(function OnSuccess(response) {

            // if balances are available for the time period
            if (!(response.data.length == 0)) {
                $scope.$parent.year = [];
                $scope.$parent.month = [];
                $scope.$parent.rnd = [];
                $scope.$parent.canteen = [];
                $scope.$parent.ceocar = [];
                $scope.$parent.marketing = [];
                $scope.$parent.parking = [];

                // generate the balance arrays for data points of the chart
                angular.forEach(response.data, function (value) {
                    $scope.$parent.year.push(value.year);
                    $scope.$parent.month.push(months[value.month - 1]);
                    $scope.$parent.rnd.push(value.rnd);
                    $scope.$parent.canteen.push(value.canteen);
                    $scope.$parent.ceocar.push(value.ceocar);
                    $scope.$parent.marketing.push(value.marketing);
                    $scope.$parent.parking.push(value.parking);
                });

                // create the chart using balance arrays
                Highcharts.chart('chartContainer', {

                    title: {
                        text: 'Account balance summary'
                    },

                    subtitle: {
                        text: 'From ' + $scope.$parent.month[0] + ' ' + $scope.$parent.year[0] + ' To ' + $scope.$parent.month[$scope.$parent.month.length - 1] + '  ' + $scope.$parent.year[$scope.$parent.year.length - 1] + ''
                    },

                    yAxis: {
                        title: {
                            text: 'Amount'
                        }
                    },

                    xAxis: {
                        title: {
                            text: 'Time Period'
                        },
                        categories: $scope.$parent.month
                    },
                    legend: {
                        layout: 'vertical',
                        align: 'right',
                        verticalAlign: 'middle'
                    },
                    series: [{
                        name: 'R&D',
                        data: $scope.$parent.rnd
                    }, {
                        name: 'Canteen',
                        data: $scope.$parent.canteen
                    }, {
                        name: 'Ceo\'s car',
                        data: $scope.$parent.ceocar
                    }, {
                        name: 'Marketing',
                        data: $scope.$parent.marketing
                    }, {
                        name: 'Parking Fines',
                        data: $scope.$parent.parking
                    }],

                    responsive: {
                        rules: [{
                            condition: {
                                maxWidth: 500
                            },
                            chartOptions: {
                                legend: {
                                    layout: 'horizontal',
                                    align: 'center',
                                    verticalAlign: 'bottom'
                                }
                            }
                        }]
                    }

                });
                // make the chart visible
                $scope.showViewBalanceChartModal = true;

            } else {
                // if account balances are not available
                $window.alert("No account balances are available for this time period");

            }
        }, function OnError(Error) {
            console.log(Error)
        })
    }

    // handle the close button press of chart modal
    $scope.HandleViewBalanceChartModal = function () {
        $scope.showViewBalanceChartModal = true;
        $window.location.href = "#!AdminDashboard/";

    }




    $scope.ViewCurrentBalance = function () {
        var UserRequest = '{accountType: "' + $scope.accountType + '"}';
        // call the controller method
        $http({
            method: "POST",
            url: "../api/AccountBalance/ViewCurrentBalance",
            dataType: 'json',
            data: UserRequest,
            headers: { "Content-Type": "application/json" }
        }).then(function OnSuccess(response) {
            console.log(response.data);
            isEmptyDb = response.data[0];
            // if db is empty
            if (isEmptyDb == 1) {
                $window.alert("no account balances are uploaded yet");
            } else {
                // show current balance
                $scope.currentBalance = response.data[1];
                $scope.isVisibleCurrentBalancePanel = true;
            }


        }, function OnError(Error) {
            console.log(Error)
        })

    }

    $scope.Logout = function () {
        loginService.Logout();
    }


}]);