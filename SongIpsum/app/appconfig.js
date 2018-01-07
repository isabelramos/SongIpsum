app.config(["$routeProvider", function ($routeProvider) {
    $routeProvider
        .when("/createipsum",
        {
            templateUrl: "/app/views/create-ipsum.html",
            controller: "createIpsumCtrl"
        })
        .otherwise(
        {
            redirectTo: "/createipsum"
        });
}]);