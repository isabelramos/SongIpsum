app.controller("createIpsumCtrl", ["$http", "$scope", "ngClipboard", function ($http, $scope, ngClipboard) {
    $scope.artistSearchInput = "";
    $scope.availableDecades = [1990, 1980, 1970];
    $scope.availableGenres = ["Rock", "Pop", "R&B", "New Wave"];
    $scope.ipsum = [];
    $scope.decadeSelectorClicked = true;
    $scope.genreSelectorClicked = false;
    $scope.artistSelectorClicked = false;

    $scope.copyIpsum = () => {
        ngClipboard.toClipboard($scope.ipsum);
    };

    $scope.openDecadeSelector = () => {
        $scope.decadeSelectorClicked = true;
        $scope.genreSelectorClicked = false;
        $scope.artistSelectorClicked = false;
    };

    $scope.openGenreSelector = () => {
        $scope.decadeSelectorClicked = false;
        $scope.genreSelectorClicked = true;
        $scope.artistSelectorClicked = false;
    };

    $scope.openArtistSelector = () => {
        $scope.decadeSelectorClicked = false;
        $scope.genreSelectorClicked = false;
        $scope.artistSelectorClicked = true;
    };

    $scope.searchDecadeButton = () => {
        $scope.getDecadeIpsum();
    };

    $scope.searchGenreButton = () => {
        $scope.getGenreIpsum();
    };

    $scope.searchArtistButton = () => {
        $scope.getArtistIpsum();
    };

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

    $scope.getArtistIpsum = () => {
        $http.get("/api/lyric/artist/" + $scope.artistSearchInput)
            .then((result) => {
                $scope.ipsum = result.data;
            }).catch((error) => {
                console.log("getArtistIpsum error", error);
            });
    };





}]);