app.controller("createIpsumCtrl", ["$http", "$scope", function ($http, $scope) {
    $scope.lyricInfo = [];
    $scope.decadeInfo = [];
    $scope.selectedDecadeInfo = [];
    $scope.artistSearchInput = "";
    $scope.availableDecades = [1990, 1980, 1970];

    $scope.getLyrics = () => {
        $http.get("/api/lyric")
            .then((result) => {
                $scope.lyricInfo = result.data;
            }).catch((error) => {
                console.log("getLyrics error", error);
            });
    };

    $scope.getLyrics();

    $scope.getSelectedDecade = () => {
        $http.get("/api/lyric/decade/" + $scope.selectedDecade)
            .then((result) => {
                $scope.selectedDecadeInfo = result.data;
                console.log($scope.selectedDecadeInfo);
            }).catch((error) => {
                console.log("getSelectedDecade error", error);
            });
    };




}]);