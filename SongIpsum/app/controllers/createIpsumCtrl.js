app.controller("createIpsumCtrl", ["$http", "$scope", function ($http, $scope) {
    $scope.lyricInfo = [];
    $scope.artistSearchInput = "";
    $scope.availableDecades = [1990, 1980, 1970];
    $scope.availableGenres = ["Rock", "Pop", "R&B", "New Wave"];
    $scope.ipsum = [];

    $scope.getDecadeIpsum = () => {
        $http.get("/api/lyric/decade/" + $scope.selectedDecade)
            .then((result) => {
                $scope.ipsum = result.data;
            }).catch((error) => {
                console.log("getDecadeIpsum error", error);
            });
    };

    $scope.getGenreIpsum = () => {
        $http.get("/api/lyric/genre/" + $scope.selectedGenre)
            .then((result) => {
                $scope.ipsum = result.data;
            }).catch((error) => {
                console.log("getGenreIpsum error", error);
            });
    };

    $scope.searchArtistButton = () => {
        $scope.getArtistIpsum();
    };

    $scope.getArtistIpsum = () => {
        $http.get("/api/lyric/artist/" + $scope.artistSearchInput)
            .then((result) => {
                $scope.ipsum = result.data;
            }).catch((error) => {
                console.log("getArtistIpsum error", error);
            });
    };





}]);