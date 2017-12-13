app.controller("createIpsumCtrl", ["$http", "$scope", function ($http, $scope) {
    $scope.lyricInfo = [];

    let getLyrics = () => {
        $http.get("/api/lyric")
            .then((result) => {
                $scope.lyricInfo = result.data;
            }).catch((error) => {
                console.log("error", error);
            });
    };

    getLyrics();


}]);