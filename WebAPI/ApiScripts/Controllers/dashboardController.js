angular.module('adraDevTest')
.controller('dashboardController', ['$scope', '$http', '$window', '$location', '$timeout', 'loginService', 'sessionService', function ($scope, $http, $window, $location, $timeout, loginService, sessionService) {
    $scope.showViewBalanceModal = false;
    $scope.showViewBalanceChartModal = false;

    $scope.username = sessionService.get("username");
    var months = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];
    $scope.isVisibleCurrentBalancePanel = false;

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
        }
    }

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
            console.log(Error)
        })
    }

    $scope.UploadBalance = function () {
        var year = document.getElementById("year").value;
        var file = document.getElementById("file").files[0];


        if (file) {
            var extention = file.name.split('.').pop();
            if (extention == "txt") {
                var reader = new FileReader();
                reader.readAsText(file, "UTF-8");
                reader.onload = function (evt) {
                    //console.log(evt.target.result);
                    var userRequest = '{year:"' + year + '",fileContent: "' + evt.target.result + '"}';
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
                    console.log("error reading file");
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
            $window.alert("Please upload a file");
        }
    }






    //////////////////////////////////////////////////////////////////////////////////////////////

    $scope.ViewBalance = function () {
        var month = parseInt($scope.month);
        var UserRequest = '{year: "' + $scope.year + '" ,month:"' + month + '" }';
        $http({
            method: "POST",
            url: "../api/AccountBalance/ViewBalance",
            dataType: 'json',
            data: UserRequest,
            headers: { "Content-Type": "application/json" }
        }).then(function OnSuccess(response) {
            if (response.data.year == 0) {
                $window.alert("No account balances are available for this month");
                $window.location.href = "#!AdminDashboard/";
            } else {
                $scope.$parent.accountBalance = response.data;
                $scope.$parent.accountBalance.month = months[response.data.month - 1];
                $scope.showViewBalanceModal = true;

            }

        }, function OnError(Error) {
            console.log(Error)
        }
        )
    }
    $scope.HandleViewBalanceModal = function () {
        $scope.showViewBalanceModal = true;
        $window.location.href = "#!AdminDashboard/";
    }

    $scope.ViewBalanceChart = function () {

        var startMonth = parseInt($scope.startMonth);
        var endMonth = parseInt($scope.endMonth);
        var startYear = $scope.startYear;
        var endYear = $scope.endYear;

        if (startYear > endYear) {
            $window.alert(" Start Year must be eqal or less than the End Year. \n Please enter valid values.");
        } else if (startYear == endYear) {
            if (startMonth > endMonth) {
                $window.alert(" Start Month must be eqal or less than End Month. \n Please enter valid values.");
            } else {
                this.getChart(startYear, startMonth, endYear, endMonth);
            }
        } else {
            this.getChart(startYear, startMonth, endYear, endMonth);
        }
    }


    $scope.getChart = function (startYear, startMonth, endYear, endMonth) {
        var UserRequest = '{startYear: "' + startYear + '" ,startMonth:"' + startMonth + '",endYear:"' + endYear + '",endMonth:"' + endMonth + '" }';
        $http({
            method: "POST",
            url: "../api/AccountBalance/ViewBalanceChart",
            dataType: 'json',
            data: UserRequest,
            headers: { "Content-Type": "application/json" }
        }).then(function OnSuccess(response) {

            if (!(response.data.length == 0)) {

                $scope.$parent.year = [];
                $scope.$parent.month = [];
                $scope.$parent.rnd = [];
                $scope.$parent.canteen = [];
                $scope.$parent.ceocar = [];
                $scope.$parent.marketing = [];
                $scope.$parent.parking = [];

                angular.forEach(response.data, function (value) {
                    $scope.$parent.year.push(value.year);
                    $scope.$parent.month.push(months[value.month - 1]);
                    $scope.$parent.rnd.push(value.rnd);
                    $scope.$parent.canteen.push(value.canteen);
                    $scope.$parent.ceocar.push(value.ceocar);
                    $scope.$parent.marketing.push(value.marketing);
                    $scope.$parent.parking.push(value.parking);
                });

                console.log($scope.$parent.month);

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

                    //plotOptions: {
                    //    series: {
                    //        label: {
                    //            connectorAllowed: false
                    //        },
                    //        pointStart: 2010
                    //    }
                    //},

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
                $scope.showViewBalanceChartModal = true;

            } else {
                $window.alert("No account balances are available for this time period");
                
            }



        }, function OnError(Error) {
            console.log(Error)
        })
    }

    $scope.HandleViewBalanceChartModal = function () {
        $scope.showViewBalanceChartModal = true;
        $window.location.href = "#!AdminDashboard/";

    }


    $scope.ViewCurrentBalance = function () {
        var UserRequest = '{accountType: "' + $scope.accountType + '"}';
        $http({
            method: "POST",
            url: "../api/AccountBalance/ViewCurrentBalance",
            dataType: 'json',
            data: UserRequest,
            headers: { "Content-Type": "application/json" }
        }).then(function OnSuccess(response) {
            console.log(response.data);
            isEmptyDb = response.data[0];
            if (isEmptyDb == 1) {
                $window.alert("no account balances are uploaded yet");
            } else {
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