var app = angular.module("SoftplanApp", ["ngRoute"]);
app.config(function ($routeProvider) {
    $routeProvider
        .when("/", {
            templateUrl: "../views/main.html"
        })
        .when("/viewProjectCode", {
            templateUrl: "../views/projectCode.html"
        });
});