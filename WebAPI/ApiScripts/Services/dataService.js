angular.module('adraDevTest')
.service('dataService',[ function () {
    accountBalance = {};
    function setAccountBalances(data) {
        accountBalance = data;
    }

    function getAccountBalances() {
        return accountBalance;
    }
}])